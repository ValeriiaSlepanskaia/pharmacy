

using PharmacyX.Infrastructure.Attributes;
using PharmacyX.Infrastructure.Foreign;
using System.ComponentModel;

namespace Pharmacy
{
    public class Ordered
    {
        [Foreign(typeof(OrderForeignLoader)), NoUpdate]
        public int OrderId { get; set; }

        [Foreign(typeof(DrugForeignLoader)), NoUpdate]
        public int DrugId { get; set; }

        [Browsable(false)]
        public Order Order { get; set; }

        [Browsable(false)]
        public Drug Drug { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }

    }
}
