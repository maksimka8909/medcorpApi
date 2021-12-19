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
    public class TypeOfResearchController : ControllerBase
    {
        private hospital_DBContext _context;

        public TypeOfResearchController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from typeOfResearch in _context.TypeOfResearches
                          select new
                          {
                              Id = typeOfResearch.IdTypeOfResearch,
                              Name = typeOfResearch.Name
                          }).ToList();
            return result;
        }


        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from typeOfResearch in _context.TypeOfResearches
                          where typeOfResearch.IdTypeOfResearch == id
                          select new
                          {
                              Id = typeOfResearch.IdTypeOfResearch,
                              Name = typeOfResearch.Name
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(TypeOfResearchView typeOfResearchView)
        {
            TypeOfResearch typeOfResearch = new TypeOfResearch()
            {
                Name = typeOfResearchView.Name
            };
            _context.TypeOfResearches.Add(typeOfResearch);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(TypeOfResearchView typeOfResearchView)
        {
            _context.TypeOfResearches.Remove(_context.TypeOfResearches.Where(p => p.IdTypeOfResearch == typeOfResearchView.IdTypeOfResearch).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(TypeOfResearchView typeOfResearchView)
        {
            var result = (from typeOfResearchSelect in _context.TypeOfResearches
                          where typeOfResearchSelect.IdTypeOfResearch == typeOfResearchView.IdTypeOfResearch
                          select typeOfResearchSelect).FirstOrDefault();
            result.Name = typeOfResearchView.Name;
            _context.SaveChanges();
        }
    }
}
