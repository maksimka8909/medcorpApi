using HospitalAPI.Classes;
using HospitalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {

        private hospital_DBContext _context;

        public ExaminationController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from examination in _context.Examinations
                          select new
                          {
                              Id = examination.IdExamination,
                              ResultOfExamination = examination.ResultOfExamination,
                              Conclusion = examination.Conclusion,
                              IdRecord = examination.IdRecord
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from examination in _context.Examinations
                          where examination.IdExamination == id
                          select new
                          {
                              Id = examination.IdExamination,
                              ResultOfExamination = examination.ResultOfExamination,
                              Conclusion = examination.Conclusion,
                              IdRecord = examination.IdRecord
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(ExaminationView examinationView)
        {
            Examination examination = new Examination()
            {
                ResultOfExamination = examinationView.ResultOfExamination,
                Conclusion = examinationView.Conclusion,
                IdRecord = examinationView.IdRecord
            };
            _context.Examinations.Add(examination);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(ExaminationView examinationView)
        {
            _context.Examinations.Remove(_context.Examinations.Where(p => p.IdExamination == examinationView.IdExamination).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(ExaminationView examinationView)
        {
            var result = (from examinationSelect in _context.Examinations
                          where examinationSelect.IdExamination == examinationView.IdExamination
                          select examinationSelect).FirstOrDefault();
            result.ResultOfExamination = examinationView.ResultOfExamination;
            result.Conclusion = examinationView.Conclusion;
            result.IdRecord = examinationView.IdRecord;
            _context.SaveChanges();
        }


    }
}
