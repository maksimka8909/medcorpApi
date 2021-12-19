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
    public class ReasonOfDismissalController : ControllerBase
    {
        private hospital_DBContext _context;

        public ReasonOfDismissalController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from reasonOfDismissal in _context.ReasonOfDismissals
                          select new
                          {
                              Id = reasonOfDismissal.IdReasonOfDismissal,
                              Name = reasonOfDismissal.Name
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from reasonOfDismissal in _context.ReasonOfDismissals
                          where reasonOfDismissal.IdReasonOfDismissal == id
                          select new
                          {
                              Id = reasonOfDismissal.IdReasonOfDismissal,
                              Name = reasonOfDismissal.Name
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(ReasonOfDismissalView reasonOfDismissalView)
        {
            ReasonOfDismissal reasonOfDismissal = new ReasonOfDismissal()
            {
                Name = reasonOfDismissalView.Name
            };
            _context.ReasonOfDismissals.Add(reasonOfDismissal);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(ReasonOfDismissalView reasonOfDismissalView)
        {
            _context.ReasonOfDismissals.Remove(_context.ReasonOfDismissals.Where(p => p.IdReasonOfDismissal == reasonOfDismissalView.IdReasonOfDismissal).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(ReasonOfDismissalView reasonOfDismissalView)
        {
            var result = (from reasonOfDismissalSelect in _context.ReasonOfDismissals
                          where reasonOfDismissalSelect.IdReasonOfDismissal == reasonOfDismissalView.IdReasonOfDismissal
                          select reasonOfDismissalSelect).FirstOrDefault();
            result.Name = reasonOfDismissalView.Name;
            _context.SaveChanges();
        }
    }
}
