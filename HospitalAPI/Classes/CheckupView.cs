using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class CheckupView
    {
        public int IdCheckup { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string PatientComplaints { get; set; }
        public string ResultOfPatientCheckup { get; set; }
        public string Prescription { get; set; }
        public string Conclusion { get; set; }
        public int IdPatient { get; set; }
        public int IdEmployee { get; set; }

        public CheckupView()
        {

        }
    }
}
