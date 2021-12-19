using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class VacationApplication
    {
        public int IdVacationApplication { get; set; }
        public DateTime BeginingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int? IdTypeOfVacation { get; set; }
        public int? IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual TypeOfVacation IdTypeOfVacationNavigation { get; set; }
    }
}
