using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyX.Infrastructure.Attributes
{
    public class ForeignAttribute : Attribute
    {
        public ForeignAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; }
    }
}
