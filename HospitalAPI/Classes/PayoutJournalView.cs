using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class PayoutJournalView
    {
        public int IdRecord { get; set; }
        public int IdWaybill { get; set; }
        public int IdEmployee { get; set; }
        public int IdPayType { get; set; }
        public string Status { get; set; }

        public PayoutJournalView()
        {

        }
    }
}
