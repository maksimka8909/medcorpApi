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
    public class RecordForExaminationController : ControllerBase
    {
        private readonly hospital_DBContext _context;

        public RecordForExaminationController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from record in _context.RecordForExaminations
                          select new
                          {
                              Id = record.IdRecord,
                              Date = record.Date,
                              Address = record.Address,
                              Status = record.Status,
                              DateOfUpdate = record.DateOfUpdate,
                              IdPatient = record.IdPatient,
                              IdEmployee = record.IdEmployee,
                              TypeOfResearch = record.IdTypeOfResearchNavigation.Name
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from record in _context.RecordForExaminations
                          where record.IdRecord == id
                          select new
                          {
                              Id = record.IdRecord,
                              Date = record.Date,
                              Address = record.Address,
                              Status = record.Status,
                              DateOfUpdate = record.DateOfUpdate,
                              IdPatient = record.IdPatient,
                              IdEmployee = record.IdEmployee,
                              TypeOfResearch = record.IdTypeOfResearchNavigation.Name
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(RecordForExaminationView recordForExaminationView)
        {
            RecordForExamination recordForExamination = new RecordForExamination()
            {
                Date = recordForExaminationView.Date,
                Address = recordForExaminationView.Address,
                Status = recordForExaminationView.Status,
                DateOfUpdate = recordForExaminationView.DateOfUpdate,
                IdPatient = recordForExaminationView.IdPatient,
                IdEmployee = recordForExaminationView.IdEmployee,
                IdTypeOfResearch = recordForExaminationView.IdTypeOfResearch
            };
            _context.RecordForExaminations.Add(recordForExamination);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(RecordForExaminationView recordForExaminationView)
        {
            _context.RecordForExaminations.Remove(_context.RecordForExaminations.Where(p => p.IdRecord == recordForExaminationView.IdRecord).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(RecordForExaminationView recordForExaminationView)
        {
            var result = (from recordSelect in _context.RecordForExaminations
                          where recordSelect.IdRecord == recordForExaminationView.IdRecord
                          select recordSelect).FirstOrDefault();
            result.Date = recordForExaminationView.Date;
            result.Address = recordForExaminationView.Address;
            result.Status = recordForExaminationView.Status;
            result.DateOfUpdate = recordForExaminationView.DateOfUpdate;
            result.IdPatient = recordForExaminationView.IdPatient;
            result.IdEmployee = recordForExaminationView.IdEmployee;
            result.IdTypeOfResearch = recordForExaminationView.IdTypeOfResearch;
            _context.SaveChanges();
        }
    }
}
