using Microsoft.EntityFrameworkCore;
using Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyX.Infrastructure.Foreign
{
    public abstract class ForeignLoader : IForeignLoader
    {
        protected readonly PharmacyContext _context = new PharmacyContext();
        public abstract IEnumerable<ForeignBinding> GetForeigns();
    }
}
