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
    public class SupplySheetOfPreparationController : ControllerBase
    {
        private hospital_DBContext _context;

        public SupplySheetOfPreparationController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from sheet in _context.SupplySheetOfPreparations
                          select new
                          {
                              Id = sheet.IdSheet,
                              DateOfSupply = sheet.DateOfSupply,
                              Provider = sheet.IdProviderNavigation.Name,
                              Preparation = sheet.IdSupplyNavigation.IdPreparationNavigation.Name,
                              Number = sheet.IdSupplyNavigation.Number
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from sheet in _context.SupplySheetOfPreparations
                          where sheet.IdSheet == id
                          select new
                          {
                              Id = sheet.IdSheet,
                              DateOfSupply = sheet.DateOfSupply,
                              Provider = sheet.IdProviderNavigation.Name,
                              Preparation = sheet.IdSupplyNavigation.IdPreparationNavigation.Name,
                              Number = sheet.IdSupplyNavigation.Number
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(SupplyOfPreparationSheetView supplyOfPreparationSheetView)
        {
            SupplySheetOfPreparation supplySheetOfPreparation = new SupplySheetOfPreparation()
            {
                DateOfSupply = supplyOfPreparationSheetView.DateOfSupply,
                IdProvider = supplyOfPreparationSheetView.IdProvider,
                IdSupply = supplyOfPreparationSheetView.IdSupply,
                IdEmployee = supplyOfPreparationSheetView.IdEmployee
            };
            _context.SupplySheetOfPreparations.Add(supplySheetOfPreparation);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(SupplyOfPreparationSheetView supplyOfPreparationSheetView)
        {
            _context.SupplySheetOfPreparations.Remove(_context.SupplySheetOfPreparations.Where(p => p.IdSheet == supplyOfPreparationSheetView.IdSheet).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(SupplyOfPreparationSheetView supplyOfPreparationSheetView)
        {
            var result = (from sheetSelect in _context.SupplySheetOfPreparations
                          where sheetSelect.IdSheet == supplyOfPreparationSheetView.IdSheet
                          select sheetSelect).FirstOrDefault();
            result.DateOfSupply = supplyOfPreparationSheetView.DateOfSupply;
            result.IdProvider = supplyOfPreparationSheetView.IdProvider;
            result.IdSupply = supplyOfPreparationSheetView.IdSupply;
            result.IdEmployee = supplyOfPreparationSheetView.IdEmployee;
            _context.SaveChanges();
        }
    }
}
