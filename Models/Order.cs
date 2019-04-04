using PharmacyX.Infrastructure.Attributes;
using PharmacyX.Infrastructure.Foreign;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace Pharmacy
{
    public class Order
    {
        [Ignore]
        public int Id { get; set; }

        [Foreign(typeof(ClientForeignLoader))]
        public int ClientId { get; set; }

        [Browsable(false)]
        public Client Client { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeSurname { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime DeliveryDate { get; set; } = DateTime.Now;

        public DateTime ExecutionDate { get; set; } = DateTime.Now;

        public decimal DeliveryCost { get; set; }

        public string AddressDelivery { get; set; }

        public string CityDelivery { get; set; }

        public string CountryDelivery { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
