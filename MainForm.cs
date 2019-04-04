using Pharmacy;
using PharmacyX.Expert;
using PharmacyX.Infrastructure;
using PharmacyX.Infrastructure.Members;
using PharmacyX.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyX
{
    public partial class MainForm : Form
    {
        private readonly IDataModel[] _models;

        public MainForm(IDataModel[] models)
        {
            InitializeComponent();
            _models = models ?? throw new ArgumentNullException(nameof(models));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (IDataModel model in _models)
            {
                tabControl.TabPages.Add(new TabPage
                {
                    Text = model.Name,
                    Tag = model
                });
            }

            SelectTab(0);
        }

        private void SelectTab(int index)
        {
            IDataModel model = _models[index];
            dataGridView.DataSource = model.Data;
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTab(tabControl.SelectedIndex);
        }

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            if (_models[tabControl.SelectedIndex].ReadOnly) return;

            ModelMapper mapper = new ModelMapper();
            IDataModel model = _models[tabControl.SelectedIndex];

            object entity = model.CreateNew();
            DataMember[] members = mapper.CreateModel(model.DataType, entity, false).ToArray();

            if (members.Any() && new ModelViewForm(members).ShowDialog() == DialogResult.OK)
            {
                model.Store(entity);
                model.SaveChanges();

                dataGridView.DataSource = null;
                dataGridView.DataSource = model.Data;
            }
        }

        private void UpdateMenuItem_Click(object sender, EventArgs e)
        {
            if (_models[tabControl.SelectedIndex].ReadOnly) return;

            ModelMapper mapper = new ModelMapper();
            IDataModel model = _models[tabControl.SelectedIndex];

            if (dataGridView.SelectedRows.Count == 0) return;
            int index = dataGridView.SelectedRows[0].Index;

            object entity = model.Data[index];
            DataMember[] members = mapper.CreateModel(model.DataType, entity, true).ToArray();

            if (members.Any() && new ModelViewForm(members).ShowDialog() == DialogResult.OK)
            {
                model.SaveChanges();

                dataGridView.DataSource = null;
                dataGridView.DataSource = model.Data;
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (_models[tabControl.SelectedIndex].ReadOnly) return;

            ModelMapper mapper = new ModelMapper();
            IDataModel model = _models[tabControl.SelectedIndex];

            if (dataGridView.SelectedRows.Count == 0) return;
            int index = dataGridView.SelectedRows[0].Index;

            object entity = model.Data[index];

            model.Delete(entity);
            model.SaveChanges();

            dataGridView.DataSource = null;
            dataGridView.DataSource = model.Data;
        }

        private void SearchMenuItem_Click(object sender, EventArgs e)
        {
            new Search().ShowDialog();
        }

        private void ExpertMenuItem_Click(object sender, EventArgs e)
        {
            PharmacyExpertFactory expertFactory = new PharmacyExpertFactory();
            ExpertSystem<Drug, Symptom> expert = expertFactory.GetExpert();
            new ExpertViewForm(expert).ShowDialog();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
