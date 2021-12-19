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
    public class EmploymentApplicationController : ControllerBase
    {
        private hospital_DBContext _context;

        public EmploymentApplicationController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from employmentApplication in _context.EmploymentApplications
                          select new
                          {
                              Id = employmentApplication.IdStatement,
                              Description = employmentApplication.Description
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from employmentApplication in _context.EmploymentApplications
                          where employmentApplication.IdStatement == id
                          select new
                          {
                              Id = employmentApplication.IdStatement,
                              Description = employmentApplication.Description
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(EmploymentApplicationView employmentApplicationView)
        {
            EmploymentApplication employmentApplication = new EmploymentApplication()
            {
                Description = employmentApplicationView.Description
            };
            _context.EmploymentApplications.Add(employmentApplication);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(EmploymentApplicationView employmentApplicationView)
        {
            _context.EmploymentApplications.Remove(_context.EmploymentApplications.Where(p => p.IdStatement == employmentApplicationView.IdStatement).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(EmploymentApplicationView employmentApplicationView)
        {
            var result = (from employmentApplicationSelect in _context.EmploymentApplications
                          where employmentApplicationSelect.IdStatement == employmentApplicationView.IdStatement
                          select employmentApplicationSelect).FirstOrDefault();
            result.Description = employmentApplicationView.Description;
            _context.SaveChanges();
        }
    }
}
