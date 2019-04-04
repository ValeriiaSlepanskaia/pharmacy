

using PharmacyX.Infrastructure.Attributes;
using PharmacyX.Infrastructure.Foreign;
using System.ComponentModel;

namespace Pharmacy
{
    public class Indication
    {
        [Foreign(typeof(SymptomForeignLoader)), NoUpdate]
        public int SymptomId { get; set; }

        [Foreign(typeof(DrugForeignLoader)), NoUpdate]
        public int DrugId { get; set; }

        [Browsable(false)]
        public Symptom Symtom { get; set; }

        [Browsable(false)]
        public Drug Drug { get; set; }
    }
}
