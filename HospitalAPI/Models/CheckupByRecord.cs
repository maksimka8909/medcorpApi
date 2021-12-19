using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class CheckupByRecord
    {
        public int IdCheckup { get; set; }
        public DateTime Date { get; set; }
        public string PatientComplaints { get; set; }
        public string ResultOfPatientCheckup { get; set; }
        public string Prescription { get; set; }
        public string Conclusion { get; set; }
        public int? IdRecord { get; set; }

        public virtual RecordForInspection IdRecordNavigation { get; set; }
    }
}
