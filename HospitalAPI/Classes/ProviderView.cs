using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class ProviderView
    {
        public int IdProvider { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string Address { get; set; }

        public ProviderView()
        {

        }
    }
}
