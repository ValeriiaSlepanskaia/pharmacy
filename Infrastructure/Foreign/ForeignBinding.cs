using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyX.Infrastructure.Foreign
{
    public class ForeignBinding
    {
        public ForeignBinding(object key, object caption)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Caption = caption ?? throw new ArgumentNullException(nameof(caption));
        }

        public object Key { get; }
        public object Caption { get; }

        public override string ToString()
        {
            return Caption.ToString();
        }
    }
}
