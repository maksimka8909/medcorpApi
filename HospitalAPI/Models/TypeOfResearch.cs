using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class TypeOfResearch
    {
        public TypeOfResearch()
        {
            RecordForExaminations = new HashSet<RecordForExamination>();
        }

        public int IdTypeOfResearch { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RecordForExamination> RecordForExaminations { get; set; }
    }
}
