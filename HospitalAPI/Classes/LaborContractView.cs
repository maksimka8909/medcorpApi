using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class LaborContractView
    {
        public int IdLaborContract { get; set; }
        public int IdPost { get; set; }
        public DateTime DateOfBeginingWork { get; set; }
        public int IdWorkSchedule { get; set; }
        public string Rate { get; set; }
        public string Description { get; set; }

        public LaborContractView()
        {

        }

    }
}
