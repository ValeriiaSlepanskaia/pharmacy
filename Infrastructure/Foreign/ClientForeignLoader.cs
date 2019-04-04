using System.Collections.Generic;
using System.Linq;

namespace PharmacyX.Infrastructure.Foreign
{
    public class ClientForeignLoader : ForeignLoader
    {
        public override IEnumerable<ForeignBinding> GetForeigns()
        {
            return _context.Clients.Select(x => new ForeignBinding(x.Id, x.Id)).ToArray();
        }
    }

}
