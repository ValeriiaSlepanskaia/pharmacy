using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class Search : Form
    {
        private readonly PharmacyContext db = new PharmacyContext();

        public Search()
        {
            InitializeComponent();
        }

        private void IdClientOrder()
        {
            if (Int32.TryParse(textBox3.Text, out int idClient) == false) return;

            var query = from drug in db.Drugs
                        join ordered in db.Ordered on drug.Id equals ordered.DrugId
                        join order in db.Orders on ordered.OrderId equals order.Id
                        where order.ClientId == idClient
                        select new { drug.Id, drug.Name, drug.PriceBuy, order.StartDate, order.ExecutionDate };

            dataGridView2.DataSource = query.Distinct().ToList();

            if (query.Count() == 0)
            {
                MessageBox.Show("Заказы не найдены!");
            }

        }

        private void IdDrugSymptom()
        {
            if (Int32.TryParse(textBox5.Text, out int idDrug) == false) return;

            var query = from symptom in db.Symptoms
                        join indication in db.Indications on symptom.Id equals indication.SymptomId
                        join drug in db.Drugs on indication.DrugId equals drug.Id
                        where drug.Id == idDrug
                        select symptom;

            dataGridView3.DataSource = query.ToList();

            if (query.Count() == 0)
            {
                MessageBox.Show("Симптомы не указаны!");
            }
        }

        private void NameDrugSymptom()
        {
            string nameDrug = textBox4.Text;
            var query = from symptom in db.Symptoms
                        join indication in db.Indications on symptom.Id equals indication.SymptomId
                        join drug in db.Drugs on indication.DrugId equals drug.Id
                        where drug.Name == nameDrug
                        select symptom;
            dataGridView3.DataSource = query.ToList();
            if (query.Count() == 0)
            {
                MessageBox.Show("Симптомы не указаны!");
            }
        }

        private void IdDrug()
        {
            int id = 0;
            bool converted = Int32.TryParse(textBox1.Text, out id);

            if (converted == false)
                return;

            db.Drugs.Load();

            var request = (from drug in db.Drugs
                           where drug.Id == id
                           select drug).ToList();

            IBindingList list = new BindingList<Drug>(request);

            if (request.Count() == 0)
            {
                MessageBox.Show("Данный препарат не найден!");
            }

            dataGridView1.DataSource = list;
        }


        private void NameDrug()
        {
            string name = textBox2.Text;

            db.Drugs.Load();

            var request = (from drug in db.Drugs
                           where drug.Name == name
                           select drug).ToList();

            IBindingList list = new BindingList<Drug>(request);

            if (request.Count() == 0)
            {
                MessageBox.Show("Данный препарат не найден!");
            }

            dataGridView1.DataSource = list;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Columns.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            IdDrug();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NameDrug();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IdClientOrder();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IdDrugSymptom();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            NameDrugSymptom();
        }
    }
}
