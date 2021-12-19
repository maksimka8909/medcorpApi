using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class PayType
    {
        public PayType()
        {
            PayoutJournals = new HashSet<PayoutJournal>();
        }

        public int IdPayType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PayoutJournal> PayoutJournals { get; set; }
    }
}
