using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class WorkScheduleView
    {
        public int IdWorkSchedule { get; set; }
        public string Name { get; set; }
        public string TypeOfWorkSchedule { get; set; }

        public WorkScheduleView()
        {

        }
    }
}
