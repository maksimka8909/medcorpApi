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
    public class PostController : ControllerBase
    {
        private hospital_DBContext _context;

        public PostController(hospital_DBContext context)
        {
            _context = context;
        }
        
        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from post in _context.Posts
                          select new
                          {
                              Id = post.IdPost,
                              Name = post.Name,
                              Salary = post.Salary
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from post in _context.Posts
                          where post.IdPost == id
                          select new
                          {
                              Id = post.IdPost,
                              Name = post.Name,
                              Salary = post.Salary
                          }).ToList();
            return result;
        }
        [Route("[action]/{name}")]
        [HttpGet]
        public IEnumerable<object> Search(string name)
        {
            var result = (from post in _context.Posts
                          where post.Name == name
                          select new
                          {
                              Id = post.IdPost,
                              Name = post.Name,
                              Salary = post.Salary
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(PostView postView)
        {
            Post post = new Post()
            {
                Name = postView.Name,
                Salary = postView.Salary
            };
            _context.Posts.Add(post);
            _context.SaveChanges();            
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(PostView postView)
        {
            _context.Posts.Remove(_context.Posts.Where(p => p.IdPost == postView.IdPost).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(PostView postView)
        {
            var result = (from postSelect in _context.Posts
                         where postSelect.IdPost == postView.IdPost
                         select postSelect).FirstOrDefault();
            result.Name = postView.Name;
            result.Salary = postView.Salary;
            _context.SaveChanges();
        }

    }
}
