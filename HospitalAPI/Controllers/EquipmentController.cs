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
    public class EquipmentController : ControllerBase
    {
        private hospital_DBContext _context;

        public EquipmentController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from equipment in _context.Equipment
                          select new
                          {
                              Id = equipment.IdEquipment,
                              Name = equipment.Name,
                              Manufacturer = equipment.Manufacturer,
                              Description = equipment.Description,
                              Type = equipment.IdTypeOfEquipmentNavigation.Name,
                              Number = equipment.Number
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from equipment in _context.Equipment
                          where equipment.IdEquipment == id
                          select new
                          {
                              Id = equipment.IdEquipment,
                              Name = equipment.Name,
                              Manufacturer = equipment.Manufacturer,
                              Description = equipment.Description,
                              Type = equipment.IdTypeOfEquipmentNavigation.Name,
                              Number = equipment.Number
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(EquipmentView equipmentView)
        {
            Equipment equipment = new Equipment()
            {
                Name = equipmentView.Name,
                IdTypeOfEquipment = equipmentView.IdTypeOfEquipment,
                Manufacturer = equipmentView.Manufacturer,
                Number = equipmentView.Number,
                Description = equipmentView.Description
            };
            _context.Equipment.Add(equipment);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(EquipmentView equipmentView)
        {
            _context.Equipment.Remove(_context.Equipment.Where(p => p.IdEquipment == equipmentView.IdEquipment).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(EquipmentView equipmentView)
        {
            var result = (from equipmentSelect in _context.Equipment
                          where equipmentSelect.IdEquipment == equipmentView.IdEquipment
                          select equipmentSelect).FirstOrDefault();
            result.Name = equipmentView.Name;
            result.IdTypeOfEquipment = equipmentView.IdTypeOfEquipment;
            result.Manufacturer = equipmentView.Manufacturer;
            result.Number = equipmentView.Number;
            result.Description = equipmentView.Description;
            _context.SaveChanges();
        }
    }
}
