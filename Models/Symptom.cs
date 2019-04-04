using PharmacyX.Infrastructure.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy
{
    public class Symptom : IEquatable<Symptom>
    {
        [Ignore]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Equals(Symptom other)
        {
            return Id == other?.Id;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
