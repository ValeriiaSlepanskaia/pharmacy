using PharmacyX.Infrastructure.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy
{
    public class Client
    {
        [Ignore]
        public int Id { get; set; }

        public string ClientName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }
    }
}
