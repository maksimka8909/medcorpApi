using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class EmployeeTimeLog
    {
        public int IdRecord { get; set; }
        public DateTime StartDateOfShift { get; set; }
        public DateTime? EndDateOfShift { get; set; }
        public int? IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
