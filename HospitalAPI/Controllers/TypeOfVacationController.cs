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
    public class TypeOfVacationController : ControllerBase
    {
        private hospital_DBContext _context;

        public TypeOfVacationController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from typesOfVacation in _context.TypeOfVacations
                          select new
                          {
                              Id = typesOfVacation.IdTypeOfVacation,
                              Name = typesOfVacation.Name
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from typeOfVacation in _context.TypeOfVacations
                          where typeOfVacation.IdTypeOfVacation == id
                          select new
                          {
                              Id = typeOfVacation.IdTypeOfVacation,
                              Name = typeOfVacation.Name
                          }).ToList();
            return result;
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IEnumerable<object> Search(string name)
        {
            var result = (from typeOfVacation in _context.TypeOfVacations
                          where typeOfVacation.Name == name
                          select new
                          {
                              Id = typeOfVacation.IdTypeOfVacation,
                              Name = typeOfVacation.Name
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(TypeOfVacationView typeOfVacationView)
        {
            TypeOfVacation typeOfVacation = new TypeOfVacation()
            {
                Name = typeOfVacationView.Name
            };
            _context.TypeOfVacations.Add(typeOfVacation);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(TypeOfVacationView typeOfVacationView)
        {
            _context.TypeOfVacations.Remove(_context.TypeOfVacations.Where(p => p.IdTypeOfVacation == typeOfVacationView.IdTypeOfVacation).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(TypeOfVacationView typeOfVacationView)
        {
            var result = (from typeOfVacationSelect in _context.TypeOfVacations
                          where typeOfVacationSelect.IdTypeOfVacation == typeOfVacationView.IdTypeOfVacation
                          select typeOfVacationSelect).FirstOrDefault();
            result.Name = typeOfVacationView.Name;
            _context.SaveChanges();
        }
    }
}
