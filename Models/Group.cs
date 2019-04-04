using PharmacyX.Infrastructure.Attributes;

namespace Pharmacy
{
    public class Group
    {
        [Ignore]
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

}
