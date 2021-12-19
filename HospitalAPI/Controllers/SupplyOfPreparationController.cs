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
    public class SupplyOfPreparationController : ControllerBase
    {
        private hospital_DBContext _context;

        public SupplyOfPreparationController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from supply in _context.SupplyOfPreparations
                          select new
                          {
                              Id = supply.IdSupply,
                              Preparation = supply.IdPreparationNavigation.Name,
                              Number = supply.Number
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from supply in _context.SupplyOfPreparations
                          where supply.IdSupply == id
                          select new
                          {
                              Id = supply.IdSupply,
                              Preparation = supply.IdPreparationNavigation.Name,
                              Number = supply.Number
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(SupplyOfPreparationView supplyOfPreparationView)
        {
            SupplyOfPreparation supplyOfPreparation = new SupplyOfPreparation()
            {
                IdPreparation= supplyOfPreparationView.IdPreparation,
                Number = supplyOfPreparationView.Number
            };
            _context.SupplyOfPreparations.Add(supplyOfPreparation);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(SupplyOfPreparationView supplyOfPreparationView)
        {
            _context.SupplyOfPreparations.Remove(_context.SupplyOfPreparations.Where(p => p.IdSupply == supplyOfPreparationView.IdSupply).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(SupplyOfPreparationView supplyOfPreparationView)
        {
            var result = (from supplySelect in _context.SupplyOfPreparations
                          where supplySelect.IdSupply == supplyOfPreparationView.IdSupply
                          select supplySelect).FirstOrDefault();
            result.IdPreparation = supplyOfPreparationView.IdPreparation;
            result.Number = supplyOfPreparationView.Number;
            _context.SaveChanges();
        }
    }
}
