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
    public class IntDataMember : DataMember
    {
        private readonly NumericUpDown _numericUpDown;

        public IntDataMember(object entity, PropertyInfo property) : base(entity, property)
        {
            _numericUpDown = new NumericUpDown()
            {
                Minimum = int.MinValue,
                Maximum = int.MaxValue,
                Value = (int)PropertyValue,
                Increment = 1,
                DecimalPlaces = 0
            };

            View = GenerateDataControl(_property.Name, _numericUpDown);
        }

        public override Control View { get; }

        public override void SaveChanges()
        {
            PropertyValue = (int)_numericUpDown.Value;
        }
    }
}
