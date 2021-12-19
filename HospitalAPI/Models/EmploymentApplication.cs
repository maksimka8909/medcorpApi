using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class EmploymentApplication
    {
        public EmploymentApplication()
        {
            PersonalFiles = new HashSet<PersonalFile>();
        }

        public int IdStatement { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PersonalFile> PersonalFiles { get; set; }
    }
}
