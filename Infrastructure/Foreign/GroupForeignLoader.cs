using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyX.Infrastructure.Foreign
{
    public class GroupForeignLoader : ForeignLoader
    {
        public override IEnumerable<ForeignBinding> GetForeigns()
        {
            return _context.Groups.Select(x => new ForeignBinding(x.Id, x.Name)).ToArray();
        }
    }

}
