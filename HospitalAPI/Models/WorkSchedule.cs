using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class WorkSchedule
    {
        public WorkSchedule()
        {
            LaborContracts = new HashSet<LaborContract>();
        }

        public int IdWorkSchedule { get; set; }
        public string Name { get; set; }
        public string TypeOfWorkSchedule { get; set; }

        public virtual ICollection<LaborContract> LaborContracts { get; set; }
    }
}
