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
    public class LaborContractController : ControllerBase
    {
        private hospital_DBContext _context;

        public LaborContractController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from contract in _context.LaborContracts
                          select new
                          {
                              Id = contract.IdLaborContract,
                              NamePost = contract.IdPostNavigation.Name,
                              WorkSchedule = contract.IdWorkScheduleNavigation.Name,
                              Rate = contract.Rate,
                              DateOfBeginingWork = contract.DateOfBeginingWork
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from contract in _context.LaborContracts
                          where contract.IdLaborContract == id
                          select new
                          {
                              Id = contract.IdLaborContract,
                              NamePost = contract.IdPostNavigation.Name,
                              WorkSchedule = contract.IdWorkScheduleNavigation.Name,
                              Rate = contract.Rate,
                              DateOfBeginingWork = contract.DateOfBeginingWork,
                              Description = contract.Description
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(LaborContractView laborContractView)
        {
            LaborContract laborContract = new LaborContract()
            {
                IdLaborContract = laborContractView.IdLaborContract,
                IdPost =  laborContractView.IdPost,
                IdWorkSchedule = laborContractView.IdWorkSchedule,
                Rate = laborContractView.Rate,
                DateOfBeginingWork = laborContractView.DateOfBeginingWork,
                Description = laborContractView.Description
            };
            _context.LaborContracts.Add(laborContract);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(LaborContractView laborContractView)
        {
            _context.LaborContracts.Remove(_context.LaborContracts.Where(p => p.IdLaborContract == laborContractView.IdLaborContract).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(LaborContractView laborContractView)
        {
            var result = (from contract in _context.LaborContracts
                          where contract.IdLaborContract == laborContractView.IdLaborContract
                          select contract).FirstOrDefault();
            result.IdPost = laborContractView.IdPost;
            result.DateOfBeginingWork = laborContractView.DateOfBeginingWork;
            result.IdWorkSchedule = laborContractView.IdWorkSchedule;
            result.Rate = laborContractView.Rate;
            result.Description = laborContractView.Description;
            _context.SaveChanges();
        }
    }
}
