using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyX.Expert
{
    public class Solution<TSolution, TSign> where TSign : IEquatable<TSign>
    {
        public TSolution SolutionValue { get; set; }
        public IEnumerable<TSign> Signs { get; set; }
    }
}
