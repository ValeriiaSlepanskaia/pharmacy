using System;

namespace PharmacyX.Infrastructure
{
    public interface IDataModel
    {
        bool ReadOnly { get; }
        object[] Data { get; }
        Type DataType { get; }
        string Name { get; }

        void Delete(object entity);
        object CreateNew();
        void SaveChanges();
        void Store(object entity);
    }
}