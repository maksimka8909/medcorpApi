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
    public class VacationApplicationController : ControllerBase
    {
        private hospital_DBContext _context;

        public VacationApplicationController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from application in _context.VacationApplications
                          select new
                          {
                              Id = application.IdVacationApplication,
                              BeginingDate = application.BeginingDate,
                              EndingDate = application.EndingDate,
                              TypeOfVacation = application.IdTypeOfVacationNavigation.Name,
                              IdEmployee = application.IdEmployee
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from application in _context.VacationApplications
                          where application.IdVacationApplication == id
                          select new
                          {
                              Id = application.IdVacationApplication,
                              BeginingDate = application.BeginingDate,
                              EndingDate = application.EndingDate,
                              TypeOfVacation = application.IdTypeOfVacationNavigation.Name,
                              IdEmployee = application.IdEmployee
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(VacationApplicationView vacationApplicationView)
        {
            VacationApplication vacationApplication = new VacationApplication()
            {
                BeginingDate = vacationApplicationView.BeginingDate,
                EndingDate = vacationApplicationView.EndingDate,
                IdTypeOfVacation = vacationApplicationView.IdTypeOfVacation,
                IdEmployee = vacationApplicationView.IdEmployee
            };
            _context.VacationApplications.Add(vacationApplication);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(VacationApplicationView vacationApplicationView)
        {
            _context.VacationApplications.Remove(_context.VacationApplications.Where(p => p.IdVacationApplication == vacationApplicationView.IdVacationApplication).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(VacationApplicationView vacationApplicationView)
        {
            var result = (from applicationSelect in _context.VacationApplications
                          where applicationSelect.IdVacationApplication == vacationApplicationView.IdVacationApplication
                          select applicationSelect).FirstOrDefault();
            result.BeginingDate = vacationApplicationView.BeginingDate;
            result.EndingDate = vacationApplicationView.EndingDate;
            result.IdTypeOfVacation = vacationApplicationView.IdTypeOfVacation;
            result.IdEmployee = vacationApplicationView.IdEmployee;
            _context.SaveChanges();
        }
    }
}
