using PharmacyX.Infrastructure;
using PharmacyX.Infrastructure.Members;
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
    public partial class ModelViewForm : Form
    {
        private readonly DataMember[] _members;

        public ModelViewForm(DataMember[] members)
        {
            InitializeComponent();
            _members = members ?? throw new ArgumentNullException(nameof(members));
        }

        private void ModelViewForm_Load(object sender, EventArgs e)
        {
            foreach (DataMember member in _members)
            {
                flowLayoutPanel.Controls.Add(member.View);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            foreach (DataMember member in _members)
            {
                member.SaveChanges();
            }
        }
    }
}
