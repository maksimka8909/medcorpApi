using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class Examination
    {
        public int IdExamination { get; set; }
        public string ResultOfExamination { get; set; }
        public string Conclusion { get; set; }
        public int? IdRecord { get; set; }

        public virtual RecordForExamination IdRecordNavigation { get; set; }
    }
}
