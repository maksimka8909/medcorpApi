using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class PayoutJournal
    {
        public int IdRecord { get; set; }
        public int? IdWaybill { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdPayType { get; set; }
        public string Status { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual PayType IdPayTypeNavigation { get; set; }
        public virtual Waybill IdWaybillNavigation { get; set; }
    }
}
