using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class Checkup
    {
        public int IdCheckup { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string PatientComplaints { get; set; }
        public string ResultOfPatientCheckup { get; set; }
        public string Prescription { get; set; }
        public string Conclusion { get; set; }
        public int? IdPatient { get; set; }
        public int? IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Patient IdPatientNavigation { get; set; }
    }
}
