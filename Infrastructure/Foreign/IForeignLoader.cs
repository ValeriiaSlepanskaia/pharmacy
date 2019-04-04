using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyX.Infrastructure.Foreign
{
    public interface IForeignLoader
    {
        IEnumerable<ForeignBinding> GetForeigns();
    }
}
