using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class CheckupByRecordView
    {
        public int IdCheckup { get; set; }
        public DateTime Date { get; set; }
        public string PatientComplaints { get; set; }
        public string ResultOfPatientCheckup { get; set; }
        public string Prescription { get; set; }
        public string Conclusion { get; set; }
        public int IdRecord { get; set; }

        public CheckupByRecordView()
        {

        }
    }
}
