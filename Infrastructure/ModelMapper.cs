using PharmacyX.Infrastructure.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyX.Infrastructure
{

    public class ModelMapper
    {
        private readonly DataMemberFactory _factory = new DataMemberFactory();

        public IEnumerable<DataMember> CreateModel(Type type, object value, bool updating)
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                if (_factory.TryCreate(prop, value, updating, out DataMember member))
                    yield return member;
            }
        }
    }
}
