using HospitalAPI.Classes;
using HospitalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private hospital_DBContext _context;

        public UserController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<object> Authorization(UserView userView)
        {
            var result = (from user in _context.Users
                          where user.Login == userView.Login && user.Password == userView.Password
                          select new 
                          {
                              IdUser = user.IdUser,
                              Login = user.Login,
                              Password = user.Password,
                              Role = user.IdRoleNavigation.Name,
                              Status = user.Status,
                              UpdateTime = user.UpdateTime
                          }).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from user in _context.Users
                          select new
                          {
                              IdUser = user.IdUser,
                              Login = user.Login,
                              Password = user.Password,
                              Role = user.IdRoleNavigation.Name,
                              Status = user.Status,
                              UpdateTime = user.UpdateTime
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from user in _context.Users
                          where user.IdRole == id
                          select new
                          {
                              IdUser = user.IdUser,
                              Login = user.Login,
                              Password = user.Password,
                              Role = user.IdRoleNavigation.Name,
                              Status = user.Status,
                              UpdateTime = user.UpdateTime
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(UserView userView)
        {
            User user = new User()
            {
                Login = userView.Login,
                Password = userView.Password,
                IdRole = userView.IdRole
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(UserView userView)
        {
            _context.Users.Remove(_context.Users.Where(p => p.IdUser == userView.IdUser).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(UserView userView)
        {
            var result = (from user in _context.Users
                          where user.IdUser == userView.IdUser
                          select user).FirstOrDefault();

            result.Login = userView.Login;
            result.Password = userView.Password;
            result.IdRole = userView.IdRole;

            _context.SaveChanges();
        }

    }
}
