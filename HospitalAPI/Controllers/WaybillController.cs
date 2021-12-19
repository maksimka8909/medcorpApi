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
    public class WaybillController : ControllerBase
    {
        private hospital_DBContext _context;

        public WaybillController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from waybill in _context.Waybills
                          select new
                          {
                              Id = waybill.IdWaybill,
                              Amount = waybill.Amount,
                              DateOfEnrollment = waybill.DateOfEnrollment,
                              IdEmployee = waybill.IdEmployee
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from waybill in _context.Waybills
                          where waybill.IdWaybill == id
                          select new
                          {
                              Id = waybill.IdWaybill,
                              Amount = waybill.Amount,
                              DateOfEnrollment = waybill.DateOfEnrollment,
                              IdEmployee = waybill.IdEmployee
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(WaybillView waybillView)
        {
            Waybill waybill = new Waybill()
            {
                Amount = waybillView.Amount,
                DateOfEnrollment = waybillView.DateOfEnrollment,
                IdEmployee = waybillView.IdEmployee
            };
            _context.Waybills.Add(waybill);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(WaybillView waybillView)
        {
            _context.Waybills.Remove(_context.Waybills.Where(p => p.IdWaybill == waybillView.IdWaybill).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(WaybillView waybillView)
        {
            var result = (from waybillSelect in _context.Waybills
                          where waybillSelect.IdWaybill == waybillView.IdWaybill
                          select waybillSelect).FirstOrDefault();
            result.Amount = waybillView.Amount;
            result.DateOfEnrollment = waybillView.DateOfEnrollment;
            result.IdEmployee = waybillView.IdEmployee;
            _context.SaveChanges();
        }
    }
}
