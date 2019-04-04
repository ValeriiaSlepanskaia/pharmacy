using System.Collections.Generic;
using System.Linq;

namespace PharmacyX.Infrastructure.Foreign
{
    public class SymptomForeignLoader : ForeignLoader
    {
        public override IEnumerable<ForeignBinding> GetForeigns()
        {
            return _context.Symptoms.Select(x => new ForeignBinding(x.Id, x.Name)).ToArray();
        }
    }

}
