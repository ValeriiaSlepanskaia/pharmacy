using PharmacyX.Infrastructure.Attributes;
using PharmacyX.Infrastructure.Foreign;
using PharmacyX.Infrastructure.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PharmacyX.Infrastructure
{
    public class DataMemberFactory
    {
        private static readonly Dictionary<Type, Func<PropertyInfo, object, DataMember>> _factories = new Dictionary<Type, Func<PropertyInfo, object, DataMember>>
        {
            { typeof(string), (p, e) => new StringDataMember(e, p) },
            { typeof(DateTime), (p, e) => new DateTimeDataMember(e, p) },
            { typeof(int), (p, e) => new IntDataMember(e, p) },
            { typeof(decimal), (p, e) => new DecimalDataMember(e, p) }
        };

        public bool TryCreate(PropertyInfo property, object entity, bool updating, out DataMember member)
        {
            if (property.GetCustomAttribute<IgnoreAttribute>() is IgnoreAttribute)
            {
                member = null;
                return false;
            }

            if (updating && property.GetCustomAttribute<NoUpdateAttribute>() is NoUpdateAttribute)
            {
                member = null;
                return false;
            }

            if (property.GetCustomAttribute<ForeignAttribute>() is ForeignAttribute foreign)
            {
                IForeignLoader foreignLoader = Activator.CreateInstance(foreign.Type) as IForeignLoader
                    ?? throw new InvalidOperationException("Can't create IForeignLoader");

                ForeignBinding[] foreigns = foreignLoader.GetForeigns().ToArray();

                member = new ForeignDataMember(entity, property, foreigns);
                return true;
            }

            if (_factories.TryGetValue(property.PropertyType, out var factory))
            {
                member = factory.Invoke(property, entity);
                return true;
            }
            else
            {
                member = null;
                return false;
            }
        }
    }
}
