using Microsoft.EntityFrameworkCore;
using Pharmacy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyX.Infrastructure
{
    public class DataModel : IDataModel
    {
        private readonly PharmacyContext _context = new PharmacyContext();

        public DataModel(Type type, string name, Func<PharmacyContext, object[]> loader, Func<object> factory)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Loader = loader ?? throw new ArgumentNullException(nameof(loader));
            Factory = factory ?? throw new ArgumentNullException(nameof(factory));
            DataType = type;
        }

        public bool ReadOnly => false;
        public Func<PharmacyContext, object[]> Loader { get; }
        public Func<object> Factory { get; }

        public Type DataType { get; }
        public string Name { get; }
        public object[] Data => Loader.Invoke(_context);

        public void Store(object entity)
        {
            _context.Add(entity);
        }

        public void Delete(object entity)
        {
            _context.Remove(entity);
        }

        public object CreateNew() => Factory.Invoke();
        public void SaveChanges() => _context.SaveChanges();
    }
}
