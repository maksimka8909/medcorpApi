using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class ReasonOfDismissal
    {
        public ReasonOfDismissal()
        {
            ResignationLetters = new HashSet<ResignationLetter>();
        }

        public int IdReasonOfDismissal { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ResignationLetter> ResignationLetters { get; set; }
    }
}
