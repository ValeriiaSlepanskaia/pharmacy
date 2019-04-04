using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyX.Infrastructure.Members
{
    public class StringDataMember : DataMember
    {
        private readonly TextBox _textBox;

        public StringDataMember(object entity, PropertyInfo property) : base(entity, property)
        {
            _textBox = new TextBox()
            {
                Text = PropertyValue?.ToString() ?? ""
            };

            View = GenerateDataControl(_property.Name, _textBox);
        }

        public override Control View { get; }

        public override void SaveChanges()
        {
            PropertyValue = _textBox.Text;
        }
    }
}
