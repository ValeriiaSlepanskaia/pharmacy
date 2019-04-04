using Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyX.Expert
{
    public class SymptomChecking
    {
        [Browsable(false)]
        public Symptom Symptom { get; set; }

        public string Name => Symptom.Name;

        public bool Having { get; set; }
    }
}
