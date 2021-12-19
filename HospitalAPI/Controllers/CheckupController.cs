using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalAPI.Models;
using HospitalAPI.Classes;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckupController : ControllerBase
    {
        private readonly hospital_DBContext _context;

        public CheckupController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from checkup in _context.Checkups
                          select new
                          {
                              Id = checkup.IdCheckup,
                              Date = checkup.Date,
                              Address = checkup.Address,
                              PatientComplaints = checkup.PatientComplaints,
                              ResultOfPatientCheckup = checkup.ResultOfPatientCheckup,
                              Presciption = checkup.Prescription,
                              Conclusion = checkup.Conclusion,
                              IdPatient = checkup.IdPatient,
                              IdEmployee = checkup.IdEmployee
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from checkup in _context.Checkups
                          where checkup.IdCheckup == id
                          select new
                          {
                              Id = checkup.IdCheckup,
                              Date = checkup.Date,
                              Address = checkup.Address,
                              PatientComplaints = checkup.PatientComplaints,
                              ResultOfPatientCheckup = checkup.ResultOfPatientCheckup,
                              Prescription = checkup.Prescription,
                              Conclusion = checkup.Conclusion,
                              IdPatient = checkup.IdPatient,
                              IdEmployee = checkup.IdEmployee
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(CheckupView checkupView)
        {
            Checkup checkup = new Checkup()
            {
                Date = checkupView.Date,
                Address = checkupView.Address,
                PatientComplaints = checkupView.PatientComplaints,
                ResultOfPatientCheckup = checkupView.ResultOfPatientCheckup,
                Prescription = checkupView.Prescription,
                Conclusion = checkupView.Conclusion,
                IdPatient = checkupView.IdPatient,
                IdEmployee = checkupView.IdEmployee
            };
            _context.Checkups.Add(checkup);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(CheckupView checkupView)
        {
            _context.Checkups.Remove(_context.Checkups.Where(p => p.IdCheckup == checkupView.IdCheckup).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(CheckupView checkupView)
        {
            var result = (from checkupSelect in _context.Checkups
                          where checkupSelect.IdCheckup == checkupView.IdCheckup
                          select checkupSelect).FirstOrDefault();
            result.Date = checkupView.Date;
            result.Address = checkupView.Address;
            result.PatientComplaints = checkupView.PatientComplaints;
            result.ResultOfPatientCheckup = checkupView.ResultOfPatientCheckup;
            result.Prescription = checkupView.Prescription;
            result.Conclusion = checkupView.Conclusion;
            result.IdPatient = checkupView.IdPatient;
            result.IdEmployee = checkupView.IdEmployee;
            _context.SaveChanges();
        }
    }


}
