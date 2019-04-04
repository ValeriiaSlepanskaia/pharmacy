using System.Collections.Generic;
using System.Linq;

namespace PharmacyX.Infrastructure.Foreign
{
    public class OrderForeignLoader : ForeignLoader
    {
        public override IEnumerable<ForeignBinding> GetForeigns()
        {
            return _context.Orders.Select(x => new ForeignBinding(x.Id, x.Id)).ToArray();
        }
    }

}
