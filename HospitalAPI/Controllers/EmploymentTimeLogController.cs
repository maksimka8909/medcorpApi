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
    public class EmploymentTimeLogController : ControllerBase
    {
        private hospital_DBContext _context;

        public EmploymentTimeLogController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from timeLog in _context.EmployeeTimeLogs
                          select new
                          {
                              Id = timeLog.IdRecord,
                              StartDateOfShift = timeLog.StartDateOfShift,
                              EndDateOfShift = timeLog.EndDateOfShift,
                              IdEmployee = timeLog.IdEmployee
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from timeLog in _context.EmployeeTimeLogs
                          where timeLog.IdRecord == id
                          select new
                          {
                              Id = timeLog.IdRecord,
                              StartDateOfShift = timeLog.StartDateOfShift,
                              EndDateOfShift = timeLog.EndDateOfShift,
                              IdEmployee = timeLog.IdEmployee
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(EmployeeTimeLogView employeeTimeLogView)
        {
            EmployeeTimeLog employeeTimeLog = new EmployeeTimeLog()
            {
                StartDateOfShift = employeeTimeLogView.StartDateOfShift,
                EndDateOfShift = employeeTimeLogView.EndDateOfShift,
                IdEmployee = employeeTimeLogView.IdEmployee
            };
            _context.EmployeeTimeLogs.Add(employeeTimeLog);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(EmployeeTimeLogView employeeTimeLogView)
        {
            _context.EmployeeTimeLogs.Remove(_context.EmployeeTimeLogs.Where(p => p.IdRecord == employeeTimeLogView.IdRecord).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(EmployeeTimeLogView employeeTimeLogView)
        {
            var result = (from recordSelect in _context.EmployeeTimeLogs
                          where recordSelect.IdRecord == employeeTimeLogView.IdRecord
                          select recordSelect).FirstOrDefault();
            result.StartDateOfShift = employeeTimeLogView.StartDateOfShift;
            result.EndDateOfShift = employeeTimeLogView.EndDateOfShift;
            result.IdEmployee = employeeTimeLogView.IdEmployee;
            _context.SaveChanges();
        }
    }
}
