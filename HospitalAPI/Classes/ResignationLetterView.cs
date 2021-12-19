using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class ResignationLetterView
    {
        public int IdResignationLetter { get; set; }
        public DateTime DateOfDismissal { get; set; }
        public int IdReasonOfDismissal { get; set; }
        public int IdEmployee { get; set; }
        public ResignationLetterView()
        {

        }
    }
}
