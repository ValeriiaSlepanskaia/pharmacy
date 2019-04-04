using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyX.Expert
{
    public class ExpertSystem<TSolution, TSign> where TSign : IEquatable<TSign>
    {
        private readonly IEnumerable<Solution<TSolution, TSign>> _solutions;

        public ExpertSystem(IEnumerable<Solution<TSolution, TSign>> solutions)
        {
            _solutions = solutions ?? throw new ArgumentNullException(nameof(solutions));
        }

        public IEnumerable<TSign> GetSigns()
        {
            return _solutions.SelectMany(x => x.Signs).Distinct();
        }

        public IEnumerable<TSolution> GetSolutions(IEnumerable<TSign> signs)
        {
            if (signs.Any() == false) return Enumerable.Empty<TSolution>();
            return _solutions.Where(x => signs.Except(x.Signs).Any() == false).Select(x => x.SolutionValue);
        }
    }
}
