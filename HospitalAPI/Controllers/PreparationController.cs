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
    public class PreparationController : ControllerBase
    {
        private hospital_DBContext _context;

        public PreparationController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from preparation in _context.Preparations
                          select new
                          {
                              Id = preparation.IdPreparation,
                              Name = preparation.Name,
                              Manufacturer = preparation.Manufacturer,
                              Description = preparation.Description,
                              Provider = preparation.IdProviderNavigation.Name
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from preparation in _context.Preparations
                          where preparation.IdPreparation == id
                          select new
                          {
                              Id = preparation.IdPreparation,
                              Name = preparation.Name,
                              Manufacturer = preparation.Manufacturer,
                              Description = preparation.Description,
                              Provider = preparation.IdProviderNavigation.Name
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(PreparationView preparationView)
        {
            Preparation preparation = new Preparation()
            {
                Name = preparationView.Name,
                Manufacturer = preparationView.Manufacturer,
                Description = preparationView.Description,
                IdProvider = preparationView.IdProvider
            };
            _context.Preparations.Add(preparation);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(PreparationView preparationView)
        {
            _context.Preparations.Remove(_context.Preparations.Where(p => p.IdPreparation == preparationView.IdPreparation).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(PreparationView preparationView)
        {
            var result = (from preparationSelect in _context.Preparations
                          where preparationSelect.IdPreparation == preparationView.IdPreparation
                          select preparationSelect).FirstOrDefault();
            result.Name = preparationView.Name;
            result.Manufacturer = preparationView.Manufacturer;
            result.IdProvider = preparationView.IdProvider;
            result.Description = preparationView.Description;
            _context.SaveChanges();
        }
    }
}
