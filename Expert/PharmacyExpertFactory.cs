using Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyX.Expert
{
    public class PharmacyExpertFactory
    {
        private readonly PharmacyContext _context = new PharmacyContext();

        public ExpertSystem<Drug, Symptom> GetExpert()
        {
            var joined = from drug in _context.Drugs
                         join indication in _context.Indications on drug.Id equals indication.DrugId
                         join symptom in _context.Symptoms on indication.SymptomId equals symptom.Id
                         select new { drug, symptom };

            var solutions = joined.GroupBy(x => x.drug)
                    .Select(x => new Solution<Drug, Symptom>()
                    {
                        SolutionValue = x.Key,
                        Signs = x.Select(i => i.symptom)
                    }).ToArray();

            return new ExpertSystem<Drug, Symptom>(solutions);
        }
    }
}
