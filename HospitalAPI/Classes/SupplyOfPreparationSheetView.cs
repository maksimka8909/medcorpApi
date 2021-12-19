using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class SupplyOfPreparationSheetView
    {
        public int IdSheet { get; set; }
        public DateTime DateOfSupply { get; set; }
        public int IdProvider { get; set; }
        public int IdSupply { get; set; }
        public int IdEmployee { get; set; }

        public SupplyOfPreparationSheetView()
        {

        }
    }
}
