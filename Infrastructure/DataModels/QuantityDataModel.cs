using System;
using System.Linq;

namespace PharmacyX.Infrastructure
{
    public class QuantityDataModel : ReadOnlyDataModel
    {
        public QuantityDataModel(string name) : base(typeof(Type), name)
        {
        }

        protected override object[] OnLoad()
        {
            var data = from drug in _context.Drugs
                       let qty = _context.Ordered.Where(x => x.DrugId == drug.Id).Sum(x => x.Quantity)
                       let sum = _context.Ordered.Where(x => x.DrugId == drug.Id).Sum(x => x.TotalPrice)
                       orderby qty descending
                       select new { Id = drug.Id, Quantity = qty, Name = drug.Name, Amount = sum };

            return data.ToArray();
        }
    }
}
