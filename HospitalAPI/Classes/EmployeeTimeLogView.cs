using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class EmployeeTimeLogView
    {
        public int IdRecord { get; set; }
        public DateTime StartDateOfShift { get; set; }
        public DateTime EndDateOfShift { get; set; }
        public int IdEmployee { get; set; }
        public EmployeeTimeLogView()
        {

        }
    }
}
