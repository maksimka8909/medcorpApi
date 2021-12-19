using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class PreparationView
    {
        public int IdPreparation { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public int IdProvider { get; set; }

        public PreparationView()
        {

        }
    }
}
