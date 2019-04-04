using Pharmacy;
using PharmacyX.Expert;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyX.Views
{
    public partial class ExpertViewForm : Form
    {
        private readonly ExpertSystem<Drug, Symptom> _expert;
        private readonly IEnumerable<SymptomChecking> _symptoms;

        public ExpertViewForm(ExpertSystem<Drug, Symptom> expert)
        {
            InitializeComponent();
            _expert = expert ?? throw new ArgumentNullException(nameof(expert));
            _symptoms = _expert.GetSigns().Select(x => new SymptomChecking
            {
                Symptom = x,
                Having = false
            }).ToArray();
        }

        private void ExpertViewForm_Load(object sender, EventArgs e)
        {
            symptomCheckingBindingSource.DataSource = _symptoms;
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            IEnumerable<Symptom> having = _symptoms.Where(x => x.Having).Select(x => x.Symptom).ToArray();
            drugBindingSource.DataSource = _expert.GetSolutions(having);
        }
    }
}
