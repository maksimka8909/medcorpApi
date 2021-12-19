using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Checkups = new HashSet<Checkup>();
            RecordForExaminations = new HashSet<RecordForExamination>();
            RecordForInspections = new HashSet<RecordForInspection>();
        }

        public int IdPatient { get; set; }
        public string Policy { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Snils { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string IssuedBy { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public string Phonenumber { get; set; }
        public string Status { get; set; }
        public int? IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Checkup> Checkups { get; set; }
        public virtual ICollection<RecordForExamination> RecordForExaminations { get; set; }
        public virtual ICollection<RecordForInspection> RecordForInspections { get; set; }
    }
}
