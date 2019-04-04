using PharmacyX.Infrastructure.Attributes;
using PharmacyX.Infrastructure.Foreign;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy
{
    public class Drug
    {
        [Ignore]
        public int Id { get; set; }

        [Foreign(typeof(GroupForeignLoader))]
        public int GroupId { get; set; }

        [ForeignKey("GroupId"), Browsable(false)]
        public Group Group { get; set; }

        public string Name { get; set; }

        public string Units { get; set; }

        public decimal PriceBuy { get; set; }

        public decimal PriceSold { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
