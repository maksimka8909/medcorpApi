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
    public class EmployeeController : Controller
    {
        private hospital_DBContext _context;

        public EmployeeController(hospital_DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Object> Show()
        {
            var getEmployee = from employee in _context.Employees
                              select new
                              {
                                  Id = employee.IdEmployee,
                                  Name = employee.IdPersonalFileNavigation.Name,
                                  Surname = employee.IdPersonalFileNavigation.Surname,
                                  MiddleName = employee.IdPersonalFileNavigation.MiddleName,
                                  Post= employee.IdUserNavigation.IdRoleNavigation.Name,
                                  Status =employee.Status 

                              };
            return getEmployee;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var getEmployee = from employee in _context.Employees
                              where employee.IdEmployee == id
                              select new
                              {
                                  Id = employee.IdEmployee,
                                  IdLaborContract = employee.IdLaborContract,
                                  IdPersonalFile = employee.IdPersonalFile,
                                  IdUser =  employee.IdUser,
                                  Status = employee.Status

                              };
            return getEmployee;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(EmployeeView employeeView)
        {
            Employee employee = new Employee()
            {
                IdLaborContract = employeeView.IdLaborContract,
                IdPersonalFile = employeeView.IdPersonalFile,
                IdUser = employeeView.IdUser
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(EmployeeView employeeView)
        {
            _context.Employees.Remove(_context.Employees.Where(p => p.IdEmployee == employeeView.IdEmployee).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(EmployeeView employeeView)
        {
            var result = (from employeeSelect in _context.Employees
                          where employeeSelect.IdEmployee == employeeView.IdEmployee
                          select employeeSelect).FirstOrDefault();
            result.IdLaborContract = employeeView.IdLaborContract;
            result.IdPersonalFile = employeeView.IdPersonalFile;
            result.IdUser = employeeView.IdUser;
            _context.SaveChanges();
        }
    }
}
