using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class LaborContract
    {
        public LaborContract()
        {
            Employees = new HashSet<Employee>();
        }

        public int IdLaborContract { get; set; }
        public int? IdPost { get; set; }
        public DateTime DateOfBeginingWork { get; set; }
        public int? IdWorkSchedule { get; set; }
        public string Rate { get; set; }
        public string Description { get; set; }

        public virtual Post IdPostNavigation { get; set; }
        public virtual WorkSchedule IdWorkScheduleNavigation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
