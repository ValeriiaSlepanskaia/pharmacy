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
    public abstract class DataMember
    {
        protected readonly object _entity;
        protected readonly PropertyInfo _property;

        protected object PropertyValue
        {
            get => _property.GetValue(_entity);
            set => _property.SetValue(_entity, value);
        }

        public DataMember(object entity, PropertyInfo property)
        {
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
            _property = property ?? throw new ArgumentNullException(nameof(property));
        }

        protected Control GenerateDataControl(string caption, Control control)
        {
            TableLayoutPanel panel = new TableLayoutPanel()
            {
                Size = new Size(174, 26),
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 1
            };

            panel.Controls.Add(new Label
            {
                Text = caption,
                Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
            }, 0, 0);

            panel.Controls.Add(control, 1, 0);

            return panel;
        }

        public abstract Control View { get; }
        public abstract void SaveChanges();
    }
}
