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
    public class WorkScheduleController : ControllerBase
    {
        private hospital_DBContext _context;

        public WorkScheduleController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from workSchedule in _context.WorkSchedules
                          select new
                          {
                              Id = workSchedule.IdWorkSchedule,
                              Name = workSchedule.Name,
                              TypeOfWorkSchedule = workSchedule.TypeOfWorkSchedule
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from workSchedule in _context.WorkSchedules
                          where workSchedule.IdWorkSchedule == id
                          select new
                          {
                              Id = workSchedule.IdWorkSchedule,
                              Name = workSchedule.Name,
                              TypeOfWorkSchedule = workSchedule.TypeOfWorkSchedule
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(WorkScheduleView workScheduleView)
        {
            WorkSchedule workSchedule = new WorkSchedule()
            {
                Name = workScheduleView.Name,
                TypeOfWorkSchedule = workScheduleView.TypeOfWorkSchedule
            };
            _context.WorkSchedules.Add(workSchedule);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(WorkScheduleView workScheduleView)
        {
            _context.WorkSchedules.Remove(_context.WorkSchedules.Where(p => p.IdWorkSchedule == workScheduleView.IdWorkSchedule).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(WorkScheduleView workScheduleView)
        {
            var result = (from workScheduleSelect in _context.WorkSchedules
                          where workScheduleSelect.IdWorkSchedule == workScheduleView.IdWorkSchedule
                          select workScheduleSelect).FirstOrDefault();
            result.Name = workScheduleView.Name;
            result.TypeOfWorkSchedule = workScheduleView.TypeOfWorkSchedule;
            _context.SaveChanges();
        }
    }
}
