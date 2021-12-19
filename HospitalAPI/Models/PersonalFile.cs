using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class PersonalFile
    {
        public PersonalFile()
        {
            Employees = new HashSet<Employee>();
        }

        public int IdPersonalFile { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Inn { get; set; }
        public string Snils { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string EmploymentHistory { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public int? IdStatement { get; set; }
        public string Requisites { get; set; }
        public string MilitaryId { get; set; }

        public virtual EmploymentApplication IdStatementNavigation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
