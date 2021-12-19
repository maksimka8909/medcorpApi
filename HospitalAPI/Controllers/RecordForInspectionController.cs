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
    public class RecordForInspectionController : ControllerBase
    {
        private readonly hospital_DBContext _context;

        public RecordForInspectionController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from record in _context.RecordForInspections
                          select new
                          {
                              Id = record.IdRecord,
                              Date = record.Date,
                              Address = record.Address,
                              Status = record.Status,
                              DateOfUpdate = record.DateOfUpdate,
                              IdPatient = record.IdPatient,
                              IdEmployee = record.IdEmployee
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from record in _context.RecordForInspections
                          where record.IdRecord == id
                          select new
                          {
                              Id = record.IdRecord,
                              Date = record.Date,
                              Address = record.Address,
                              Status = record.Status,
                              DateOfUpdate = record.DateOfUpdate,
                              IdPatient = record.IdPatient,
                              IdEmployee = record.IdEmployee
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(RecordForInspectionView recordForInspectionView)
        {
            RecordForInspection recordForInspection = new RecordForInspection()
            {
                Date = recordForInspectionView.Date,
                Address = recordForInspectionView.Address,
                Status = recordForInspectionView.Status,
                DateOfUpdate = recordForInspectionView.DateOfUpdate,
                IdPatient = recordForInspectionView.IdPatient,
                IdEmployee = recordForInspectionView.IdEmployee
            };
            _context.RecordForInspections.Add(recordForInspection);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(CheckupView checkupView)
        {
            _context.Checkups.Remove(_context.Checkups.Where(p => p.IdCheckup == checkupView.IdCheckup).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(RecordForInspectionView recordForInspectionView)
        {
            var result = (from recordSelect in _context.RecordForInspections
                          where recordSelect.IdRecord == recordForInspectionView.IdRecord
                          select recordSelect).FirstOrDefault();
            result.Date = recordForInspectionView.Date;
            result.Address = recordForInspectionView.Address;
            result.Status = recordForInspectionView.Status;
            result.DateOfUpdate = recordForInspectionView.DateOfUpdate;
            result.IdPatient = recordForInspectionView.IdPatient;
            result.IdEmployee = recordForInspectionView.IdEmployee;
            _context.SaveChanges();
        }
    }
}

