using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class SupplyOfEquipmentView
    {
        public int IdSupply { get; set; }
        public int Number { get; set; }
        public int IdEquipment { get; set; }

        public SupplyOfEquipmentView()
        {

        }
    }
}
