using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class WaybillView
    {
        public int IdWaybill { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfEnrollment { get; set; }
        public int IdEmployee { get; set; }

        public WaybillView()
        {

        }
    }
}
