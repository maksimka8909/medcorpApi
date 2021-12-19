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
    public class PersonalFileController : ControllerBase
    {
        private hospital_DBContext _context;

        public PersonalFileController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from personalFile in _context.PersonalFiles
                          select new
                          {
                            Id =personalFile.IdPersonalFile, 
                            Name = personalFile.Name,
                            Surname = personalFile.Surname,
                            MiddleName = personalFile.MiddleName,
                            Gender = personalFile.Gender,
                            Birthday = personalFile.Birthday,
                            Inn = personalFile.Inn, 
                            Snils = personalFile.Snils,
                            PassportSeries = personalFile.PassportSeries,
                            PassportNumber = personalFile.PassportNumber,
                            EmploymentHistory = personalFile.EmploymentHistory,
                            Phonenumber = personalFile.Phonenumber,
                            Email = personalFile.Email,
                            Education = personalFile.Education,
                            IdStatement = personalFile.IdStatement,
                            Requisites = personalFile.Requisites,
                            MilitaryId = personalFile.MilitaryId}).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from personalFile in _context.PersonalFiles
                          where personalFile.IdPersonalFile == id
                          select new
                          {
                              Id = personalFile.IdPersonalFile,
                              Name = personalFile.Name,
                              Surname = personalFile.Surname,
                              MiddleName = personalFile.MiddleName,
                              Gender = personalFile.Gender,
                              Birthday = personalFile.Birthday,
                              Inn = personalFile.Inn,
                              Snils = personalFile.Snils,
                              PassportSeries = personalFile.PassportSeries,
                              PassportNumber = personalFile.PassportNumber,
                              EmploymentHistory = personalFile.EmploymentHistory,
                              Phonenumber = personalFile.Phonenumber,
                              Email = personalFile.Email,
                              Education = personalFile.Education,
                              IdStatement = personalFile.IdStatement,
                              Requisites = personalFile.Requisites,
                              MilitaryId = personalFile.MilitaryId
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(PersonalFileView personalFileView)
        {
            PersonalFile personalFile = new PersonalFile()
            {
                Name = personalFileView.Name,
                Surname = personalFileView.Surname,
                MiddleName = personalFileView.MiddleName,
                Gender = personalFileView.Gender,
                Birthday = personalFileView.Birthday,
                Inn = personalFileView.Inn,
                Snils = personalFileView.Snils,
                PassportSeries = personalFileView.PassportSeries,
                PassportNumber = personalFileView.PassportNumber,
                EmploymentHistory = personalFileView.EmploymentHistory,
                Phonenumber = personalFileView.Phonenumber,
                Email = personalFileView.Email,
                Education = personalFileView.Education,
                IdStatement = personalFileView.IdStatement,
                Requisites = personalFileView.Requisites,
                MilitaryId = personalFileView.MilitaryId
            };
            _context.PersonalFiles.Add(personalFile);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(PersonalFileView personalFileView)
        {
            _context.PersonalFiles.Remove(_context.PersonalFiles.Where(p => p.IdPersonalFile == personalFileView.IdPersonalFile).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(PersonalFileView personalFileView)
        {
            var result = (from personalFileSelect in _context.PersonalFiles
                          where personalFileSelect.IdPersonalFile == personalFileView.IdPersonalFile
                          select personalFileSelect).FirstOrDefault();
            result.Name = personalFileView.Name;
            result.Surname = personalFileView.Surname;
            result.MiddleName = personalFileView.MiddleName;
            result.Gender = personalFileView.Gender;
            result.Birthday = personalFileView.Birthday;
            result.Inn = personalFileView.Inn;
            result.Snils = personalFileView.Snils;
            result.PassportSeries = personalFileView.PassportSeries;
            result.PassportNumber = personalFileView.PassportNumber;
            result.EmploymentHistory = personalFileView.EmploymentHistory;
            result.Phonenumber = personalFileView.Phonenumber;
            result.Email = personalFileView.Email;
            result.Education = personalFileView.Education;
            result.IdStatement = personalFileView.IdStatement;
            result.Requisites = personalFileView.Requisites;
            result.MilitaryId = personalFileView.MilitaryId;
            _context.SaveChanges();
        }
    }
}
