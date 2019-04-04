using PharmacyX.Infrastructure.Foreign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyX.Infrastructure.Members
{
    public class ForeignDataMember : DataMember
    {
        private readonly ComboBox _comboBox;

        public ForeignDataMember(object entity, PropertyInfo property, ForeignBinding[] foreigns) : base(entity, property)
        {
            _comboBox = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            int index = -1;
            for (int i = 0; i < foreigns.Length; i++)
            {
                _comboBox.Items.Add(foreigns[i]);

                if (foreigns[i].Key.Equals(PropertyValue))
                {
                    index = i;
                }
            }

            _comboBox.SelectedIndex = index == -1 && foreigns.Any() ? 0 : index;
            View = GenerateDataControl(_property.Name, _comboBox);
        }

        public override Control View { get; }

        public override void SaveChanges()
        {
            PropertyValue = ((ForeignBinding)_comboBox.SelectedItem).Key;
        }
    }
}
