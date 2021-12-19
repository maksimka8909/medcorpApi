using HospitalAPI.Classes;
using HospitalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private hospital_DBContext _context;

        public PatientController(hospital_DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Object> Show()
        {
            var request = from patients in _context.Patients
                          select new
                          {
                              Id = patients.IdPatient,
                              Policy = patients.Policy,
                              Name = patients.Name,
                              Surname = patients.Surname,
                              MiddleName = patients.MiddleName,
                              Birthday = patients.Birthday,
                              Gender = patients.Gender,
                              SNILS = patients.Snils,
                              PassportSeries = patients.PassportSeries,
                              PassportNumber = patients.PassportNumber,
                              IssuedBy = patients.IssuedBy,
                              DateOfIssue = patients.IssuedBy,
                              Phonenumber = patients.Phonenumber,
                              Status = patients.Status,
                              IdUser = patients.IdUser
                          };
            return request;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var request = from patients in _context.Patients
                          where patients.IdPatient == id
                          select new
                          {
                              Id = patients.IdPatient,
                              Policy = patients.Policy,
                              Name = patients.Name,
                              Surname = patients.Surname,
                              MiddleName = patients.MiddleName,
                              Birthday = patients.Birthday,
                              Gender = patients.Gender,
                              SNILS = patients.Snils,
                              PassportSeries = patients.PassportSeries,
                              PassportNumber = patients.PassportNumber,
                              IssuedBy = patients.IssuedBy,
                              DateOfIssue = patients.IssuedBy,
                              Phonenumber = patients.Phonenumber,
                              Status = patients.Status,
                              IdUser = patients.IdUser
                          };
            return request;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(PatientView patientView)
        {
            Patient patient = new Patient()
            {
                Policy = patientView.Policy,
                Name = patientView.Name,
                Surname = patientView.Surname,
                MiddleName = patientView.MiddleName,
                Birthday = patientView.Birthday,
                Gender = patientView.Gender,
                Snils = patientView.Snils,
                PassportSeries = patientView.PassportSeries,
                PassportNumber = patientView.PassportNumber,
                IssuedBy = patientView.IssuedBy,
                DateOfIssue = patientView.DateOfIssue,
                Phonenumber = patientView.Phonenumber,
                IdUser = patientView.IdUser
            };
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(PatientView patientView)
        {
            _context.Patients.Remove(_context.Patients.Where(p => p.IdPatient == patientView.IdPatient).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(PatientView patientView)
        {
            var result = (from patientSelect in _context.Patients
                          where patientSelect.IdPatient == patientView.IdPatient
                          select patientSelect).FirstOrDefault();
            result.Policy = patientView.Policy;
            result.Name = patientView.Name;
            result.Surname = patientView.Surname;
            result.MiddleName = patientView.MiddleName;
            result.Birthday = patientView.Birthday;
            result.Gender = patientView.Gender;
            result.Snils = patientView.Snils;
            result.PassportSeries = patientView.PassportSeries;
            result.PassportNumber = patientView.PassportNumber;
            result.IssuedBy = patientView.IssuedBy;
            result.DateOfIssue = patientView.DateOfIssue;
            result.Phonenumber = patientView.Phonenumber;
            result.IdUser = patientView.IdUser;
            _context.SaveChanges();
        }
    }
}
