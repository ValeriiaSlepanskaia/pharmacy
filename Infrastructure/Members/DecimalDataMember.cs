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
    class DecimalDataMember : DataMember
    {
        private readonly NumericUpDown _numericUpDown;

        public DecimalDataMember(object entity, PropertyInfo property) : base(entity, property)
        {
            _numericUpDown = new NumericUpDown()
            {
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Value = (decimal)PropertyValue,
                Increment = 0.01m,
                DecimalPlaces = 2
            };

            View = GenerateDataControl(_property.Name, _numericUpDown);
        }

        public override Control View { get; }

        public override void SaveChanges()
        {
            PropertyValue = _numericUpDown.Value;
        }
    }
}
