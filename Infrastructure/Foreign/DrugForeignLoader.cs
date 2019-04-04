using System.Collections.Generic;
using System.Linq;

namespace PharmacyX.Infrastructure.Foreign
{
    public class DrugForeignLoader : ForeignLoader
    {
        public override IEnumerable<ForeignBinding> GetForeigns()
        {
            return _context.Drugs.Select(x => new ForeignBinding(x.Id, x.Name)).ToArray();
        }
    }

}
