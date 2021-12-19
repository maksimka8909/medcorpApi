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
    public class CheckupByRecordController : ControllerBase
    {
        private readonly hospital_DBContext _context;

        public CheckupByRecordController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from checkup in _context.CheckupByRecords
                          select new
                          {
                              Id = checkup.IdCheckup,
                              Date = checkup.Date,
                              PatientComplaints = checkup.PatientComplaints,
                              ResultOfPatientCheckup = checkup.ResultOfPatientCheckup,
                              Presciption = checkup.Prescription,
                              Conclusion = checkup.Conclusion,
                              IdRecord = checkup.IdRecord
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from checkup in _context.CheckupByRecords
                          where checkup.IdRecord == id
                          select new
                          {
                              Id = checkup.IdCheckup,
                              Date = checkup.Date,
                              PatientComplaints = checkup.PatientComplaints,
                              ResultOfPatientCheckup = checkup.ResultOfPatientCheckup,
                              Prescription = checkup.Prescription,
                              Conclusion = checkup.Conclusion,
                              IdRecord = checkup.IdRecord
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(CheckupByRecordView checkupByRecordView)
        {
            CheckupByRecord checkupByRecord = new CheckupByRecord()
            {
                Date = checkupByRecordView.Date,
                PatientComplaints = checkupByRecordView.PatientComplaints,
                ResultOfPatientCheckup = checkupByRecordView.ResultOfPatientCheckup,
                Prescription = checkupByRecordView.Prescription,
                Conclusion = checkupByRecordView.Conclusion,
                IdRecord = checkupByRecordView.IdRecord
            };
            _context.CheckupByRecords.Add(checkupByRecord);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(CheckupByRecordView checkupByRecordView)
        {
            _context.CheckupByRecords.Remove(_context.CheckupByRecords.Where(p => p.IdCheckup == checkupByRecordView.IdCheckup).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(CheckupByRecordView checkupByRecordView)
        {
            var result = (from checkupSelect in _context.CheckupByRecords
                          where checkupSelect.IdCheckup == checkupByRecordView.IdCheckup
                          select checkupSelect).FirstOrDefault();
            result.Date = checkupByRecordView.Date;
            result.PatientComplaints = checkupByRecordView.PatientComplaints;
            result.ResultOfPatientCheckup = checkupByRecordView.ResultOfPatientCheckup;
            result.Prescription = checkupByRecordView.Prescription;
            result.Conclusion = checkupByRecordView.Conclusion;
            result.IdRecord = checkupByRecordView.IdRecord;
            _context.SaveChanges();
        }
    }
}
