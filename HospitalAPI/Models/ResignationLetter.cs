using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class ResignationLetter
    {
        public int IdResignationLetter { get; set; }
        public DateTime DateOfDismissal { get; set; }
        public int? IdReasonOfDismissal { get; set; }
        public int? IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual ReasonOfDismissal IdReasonOfDismissalNavigation { get; set; }
    }
}
