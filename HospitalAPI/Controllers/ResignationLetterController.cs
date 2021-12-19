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
    public class ResignationLetterController : ControllerBase
    {
        private hospital_DBContext _context;

        public ResignationLetterController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from letter in _context.ResignationLetters
                          select new
                          {
                              Id = letter.IdResignationLetter,
                              DateOfDismissal = letter.DateOfDismissal,
                              ReasonOfDismissal = letter.IdReasonOfDismissalNavigation.Name,
                              IdEmployee = letter.IdEmployee
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from letter in _context.ResignationLetters
                          where letter.IdResignationLetter == id
                          select new
                          {
                              Id = letter.IdResignationLetter,
                              DateOfDismissal = letter.DateOfDismissal,
                              ReasonOfDismissal = letter.IdReasonOfDismissalNavigation.Name,
                              IdEmployee = letter.IdEmployee
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(ResignationLetterView resignationLetterView)
        {
            ResignationLetter resignationLetter = new ResignationLetter()
            {
                DateOfDismissal = resignationLetterView.DateOfDismissal,
                IdReasonOfDismissal = resignationLetterView.IdReasonOfDismissal,
                IdEmployee = resignationLetterView.IdEmployee
            };
            _context.ResignationLetters.Add(resignationLetter);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(ResignationLetterView resignationLetterView)
        {
            _context.ResignationLetters.Remove(_context.ResignationLetters.Where(p => p.IdResignationLetter == resignationLetterView.IdResignationLetter).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(ResignationLetterView resignationLetterView)
        {
            var result = (from letterSelect in _context.ResignationLetters
                          where letterSelect.IdResignationLetter == resignationLetterView.IdResignationLetter
                          select letterSelect).FirstOrDefault();
            result.DateOfDismissal = resignationLetterView.DateOfDismissal;
            result.IdReasonOfDismissal = resignationLetterView.IdReasonOfDismissal;
            result.IdEmployee = resignationLetterView.IdEmployee;
            _context.SaveChanges();
        }
    }
}
