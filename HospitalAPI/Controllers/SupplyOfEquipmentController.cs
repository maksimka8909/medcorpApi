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
    public class SupplyOfEquipmentController : ControllerBase
    {
        private hospital_DBContext _context;

        public SupplyOfEquipmentController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from supply in _context.SupplyOfEquipments
                          select new
                          {
                              Id = supply.IdSupply,
                              Equipment = supply.IdEquipmentNavigation.Name,
                              Number = supply.Number
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from supply in _context.SupplyOfEquipments
                          where supply.IdSupply == id
                          select new
                          {
                              Id = supply.IdSupply,
                              Equipment = supply.IdEquipmentNavigation.Name,
                              Number = supply.Number
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(SupplyOfEquipmentView supplyOfEquipmentView)
        {
            SupplyOfEquipment supplyOfEquipment = new SupplyOfEquipment()
            {
                IdEquipment = supplyOfEquipmentView.IdEquipment,
                Number = supplyOfEquipmentView.Number
            };
            _context.SupplyOfEquipments.Add(supplyOfEquipment);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(SupplyOfEquipmentView supplyOfEquipmentView)
        {
            _context.SupplyOfEquipments.Remove(_context.SupplyOfEquipments.Where(p => p.IdSupply == supplyOfEquipmentView.IdSupply).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(SupplyOfEquipmentView supplyOfEquipmentView)
        {
            var result = (from supplySelect in _context.SupplyOfEquipments
                          where supplySelect.IdSupply == supplyOfEquipmentView.IdSupply
                          select supplySelect).FirstOrDefault();
            result.IdEquipment = supplyOfEquipmentView.IdEquipment;
            result.Number = supplyOfEquipmentView.Number;
            _context.SaveChanges();
        }
    }
}
