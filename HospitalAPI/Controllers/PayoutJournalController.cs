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
    public class PayoutJournalController : ControllerBase
    {
        private readonly hospital_DBContext _context;

        public PayoutJournalController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from payout in _context.PayoutJournals
                          select new
                          {
                              Id = payout.IdRecord,
                              IdWaybill = payout.IdWaybill,
                              IdEmployee = payout.IdEmployee,
                              PayType = payout.IdPayTypeNavigation.Name,
                              Status = payout.Status
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from payout in _context.PayoutJournals
                          where payout.IdRecord == id
                          select new
                          {
                              Id = payout.IdRecord,
                              IdWaybill = payout.IdWaybill,
                              IdEmployee = payout.IdEmployee,
                              PayType = payout.IdPayTypeNavigation.Name,
                              Status = payout.Status
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(PayoutJournalView payoutJournalView)
        {
            PayoutJournal payoutJournal = new PayoutJournal()
            {
                IdWaybill = payoutJournalView.IdWaybill,
                IdEmployee = payoutJournalView.IdEmployee,
                IdPayType = payoutJournalView.IdPayType,
                Status = payoutJournalView.Status
            };
            _context.PayoutJournals.Add(payoutJournal);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(PayoutJournalView payoutJournalView)
        {
            _context.PayoutJournals.Remove(_context.PayoutJournals.Where(p => p.IdRecord == payoutJournalView.IdRecord).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(PayoutJournalView payoutJournalView)
        {
            var result = (from payoutSelect in _context.PayoutJournals
                          where payoutSelect.IdRecord == payoutJournalView.IdRecord
                          select payoutSelect).FirstOrDefault();
            result.IdWaybill = payoutJournalView.IdWaybill;
            result.IdEmployee = payoutJournalView.IdEmployee;
            result.IdPayType = payoutJournalView.IdPayType;
            result.Status = payoutJournalView.Status;
            _context.SaveChanges();
        }
    }
}
