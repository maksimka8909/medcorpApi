using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class RecordForExaminationView
    {
        public int IdRecord { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public int IdPatient { get; set; }
        public int IdEmployee { get; set; }
        public DateTime DateOfUpdate { get; set; }
        public int IdTypeOfResearch { get; set; }

        public RecordForExaminationView()
        {

        }
    }
}
