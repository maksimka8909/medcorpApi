using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class Waybill
    {
        public Waybill()
        {
            PayoutJournals = new HashSet<PayoutJournal>();
        }

        public int IdWaybill { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfEnrollment { get; set; }
        public int? IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual ICollection<PayoutJournal> PayoutJournals { get; set; }
    }
}
