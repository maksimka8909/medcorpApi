using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class VacationApplicationView
    {
        public int IdVacationApplication { get; set; }
        public DateTime BeginingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int IdTypeOfVacation { get; set; }
        public int IdEmployee { get; set; }

        public VacationApplicationView()
        {

        }
    }
}
