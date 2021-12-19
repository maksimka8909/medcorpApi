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
    public class RoleController : ControllerBase
    {
        private hospital_DBContext _context;

        public RoleController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from role in _context.Roles
                          select new
                          {
                              Id = role.IdRole,
                              Name = role.Name
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from role in _context.Roles
                          where role.IdRole == id
                          select new
                          {
                              Id = role.IdRole,
                              Name = role.Name
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(RoleView roleView)
        {
            Role role = new Role()
            {
                Name = roleView.Name
            };
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(RoleView roleView)
        {
            _context.Roles.Remove(_context.Roles.Where(p => p.IdRole == roleView.IdRole).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(RoleView roleView)
        {
            var result = (from roleSelect in _context.Roles
                          where roleSelect.IdRole == roleView.IdRole
                          select roleSelect).FirstOrDefault();
            result.Name = roleView.Name;
            _context.SaveChanges();
        }
    }
}
