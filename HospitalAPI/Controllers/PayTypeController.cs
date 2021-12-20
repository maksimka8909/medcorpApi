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
    public class PayTypeController : ControllerBase
    {
        private hospital_DBContext _context;

        public PayTypeController(hospital_DBContext context)
        {
            _context = context;
        }



        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from payType in _context.PayTypes
                          select new
                          {
                              Id = payType.IdPayType,
                              Name = payType.Name
                          }).ToList();
            return result;
        }
        
        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from paytype in _context.PayTypes
                          where paytype.IdPayType == id
                          select new
                          {
                              Id = paytype.IdPayType,
                              Name = paytype.Name
                          }).ToList();
            return result;
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IEnumerable<object> Search(string name)
        {
            var result = (from paytype in _context.PayTypes
                          where paytype.Name == name
                          select new
                          {
                              Id = paytype.IdPayType,
                              Name = paytype.Name
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(PayTypeView payTypeView)
        {
            PayType payType = new PayType()
            {
                Name = payTypeView.Name
            };
            _context.PayTypes.Add(payType);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(PayTypeView payTypeView)
        {
            _context.PayTypes.Remove(_context.PayTypes.Where(p => p.IdPayType == payTypeView.IdPayType).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(PayTypeView payTypeView)
        {
            var result = (from payTypeSelect in _context.PayTypes
                          where payTypeSelect.IdPayType == payTypeView.IdPayType
                          select payTypeSelect).FirstOrDefault();
            result.Name = payTypeView.Name;
            _context.SaveChanges();
        }


    }
}
