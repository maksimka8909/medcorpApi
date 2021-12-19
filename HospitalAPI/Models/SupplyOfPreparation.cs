using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class SupplyOfPreparation
    {
        public SupplyOfPreparation()
        {
            SupplySheetOfPreparations = new HashSet<SupplySheetOfPreparation>();
        }

        public int IdSupply { get; set; }
        public int Number { get; set; }
        public int? IdPreparation { get; set; }

        public virtual Preparation IdPreparationNavigation { get; set; }
        public virtual ICollection<SupplySheetOfPreparation> SupplySheetOfPreparations { get; set; }
    }
}
