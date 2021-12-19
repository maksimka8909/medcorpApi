using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class ExaminationView
    {
        public int IdExamination { get; set; }
        public string ResultOfExamination { get; set; }
        public string Conclusion { get; set; }
        public int IdRecord { get; set; }

        public ExaminationView()
        {

        }

    }
}
