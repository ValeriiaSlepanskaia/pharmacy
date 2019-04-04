using Pharmacy;
using System;

namespace PharmacyX.Infrastructure
{
    public abstract class ReadOnlyDataModel : IDataModel
    {
        protected readonly PharmacyContext _context = new PharmacyContext();

        protected ReadOnlyDataModel(Type type, string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DataType = type;
        }

        protected abstract object[] OnLoad();

        public bool ReadOnly => true;

        public object[] Data => OnLoad();

        public Type DataType { get; }

        public string Name { get; }

        public object CreateNew() => throw new NotSupportedException();

        public void Delete(object entity) => throw new NotSupportedException();

        public void SaveChanges() => throw new NotSupportedException();

        public void Store(object entity) => throw new NotSupportedException();
    }
}
