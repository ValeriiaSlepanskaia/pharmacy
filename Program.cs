using Pharmacy;
using PharmacyX.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyX
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IDataModel[] models = new IDataModel[]
            {
                new DataModel(typeof(Drug), nameof(Drug), cntx => cntx.Drugs.ToArray(), () => new Drug()),
                new DataModel(typeof(Client), nameof(Client), cntx => cntx.Clients.ToArray(), () => new Client()),
                new DataModel(typeof(Group), nameof(Group), cntx => cntx.Groups.ToArray(), () => new Group()),
                new DataModel(typeof(Indication), nameof(Indication), cntx => cntx.Indications.ToArray(), () => new Indication()),
                new DataModel(typeof(Order), nameof(Order), cntx => cntx.Orders.ToArray(), () => new Order()),
                new DataModel(typeof(Ordered), nameof(Ordered), cntx => cntx.Ordered.ToArray(), () => new Ordered()),
                new DataModel(typeof(Symptom), nameof(Symptom), cntx => cntx.Symptoms.ToArray(), () => new Symptom()),
                new QuantityDataModel("Analytics")
            };

            Application.Run(new MainForm(models));
        }
    }
}
