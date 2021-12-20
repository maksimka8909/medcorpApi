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
    public class TypeOfEquipmentController : ControllerBase
    {

        private hospital_DBContext _context;

        public TypeOfEquipmentController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from typeOfEquipment in _context.TypeOfEqupiments
                          select new
                          {
                              Id = typeOfEquipment.IdTypeOfEquipment,
                              Name = typeOfEquipment.Name
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from typeOfEquipment in _context.TypeOfEqupiments
                          where typeOfEquipment.IdTypeOfEquipment == id
                          select new
                          {
                              Id = typeOfEquipment.IdTypeOfEquipment,
                              Name = typeOfEquipment.Name
                          }).ToList();
            return result;
        }
        [Route("[action]/{name}")]
        [HttpGet]
        public IEnumerable<object> Search(string name)
        {
            var result = (from typeOfEquipment in _context.TypeOfEqupiments
                          where typeOfEquipment.Name == name
                          select new
                          {
                              Id = typeOfEquipment.IdTypeOfEquipment,
                              Name = typeOfEquipment.Name
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(TypeOfEquipmentView typeOfEquipmentView)
        {
            TypeOfEqupiment typeOfEqupiment = new TypeOfEqupiment()
            {
                Name = typeOfEquipmentView.Name
            };
            _context.TypeOfEqupiments.Add(typeOfEqupiment);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(TypeOfEquipmentView typeOfEquipmentView)
        {
            _context.TypeOfEqupiments.Remove(_context.TypeOfEqupiments.Where(p => p.IdTypeOfEquipment == typeOfEquipmentView.IdTypeOfEquipment).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(TypeOfEquipmentView typeOfEquipmentView)
        {
            var result = (from typeOfEquipmentSelect in _context.TypeOfEqupiments
                          where typeOfEquipmentSelect.IdTypeOfEquipment == typeOfEquipmentView.IdTypeOfEquipment
                          select typeOfEquipmentSelect).FirstOrDefault();
            result.Name = typeOfEquipmentView.Name;
            _context.SaveChanges();
        }
    }
}
