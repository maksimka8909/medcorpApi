using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class TypeOfVacation
    {
        public TypeOfVacation()
        {
            VacationApplications = new HashSet<VacationApplication>();
        }

        public int IdTypeOfVacation { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VacationApplication> VacationApplications { get; set; }
    }
}
