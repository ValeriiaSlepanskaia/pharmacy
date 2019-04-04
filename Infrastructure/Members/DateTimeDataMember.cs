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
    public class DateTimeDataMember : DataMember
    {
        private readonly DateTimePicker _dateTimePicker;

        public DateTimeDataMember(object entity, PropertyInfo property) : base(entity, property)
        {
            _dateTimePicker = new DateTimePicker
            {
                MinDate = DateTime.MinValue,
                MaxDate = DateTime.MaxValue,
                Value = (DateTime)PropertyValue
            };

            View = GenerateDataControl(_property.Name, _dateTimePicker);
        }

        public override Control View { get; }

        public override void SaveChanges()
        {
            PropertyValue = _dateTimePicker.Value;
        }
    }
}
