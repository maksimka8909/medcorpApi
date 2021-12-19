using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class EquipmentView
    {
        public int IdEquipment { get; set; }
        public string Name { get; set; }
        public int IdTypeOfEquipment { get; set; }
        public string Manufacturer { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }

        public EquipmentView()
        {

        }
    }
}
