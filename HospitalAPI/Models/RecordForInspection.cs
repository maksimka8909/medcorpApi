using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class RecordForInspection
    {
        public RecordForInspection()
        {
            CheckupByRecords = new HashSet<CheckupByRecord>();
        }

        public int IdRecord { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public DateTime DateOfUpdate { get; set; }
        public int? IdPatient { get; set; }
        public int? IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Patient IdPatientNavigation { get; set; }
        public virtual ICollection<CheckupByRecord> CheckupByRecords { get; set; }
    }
}
