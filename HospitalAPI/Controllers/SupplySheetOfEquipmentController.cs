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
    public class SupplySheetOfEquipmentController : ControllerBase
    {
        private hospital_DBContext _context;

        public SupplySheetOfEquipmentController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from sheet in _context.SupplySheetOfEquipments
                          select new
                          {
                              Id = sheet.IdSheet,
                              DateOfSupply = sheet.DateOfSupply,
                              Provider = sheet.IdProviderNavigation.Name,
                              Equipment = sheet.IdSupplyNavigation.IdEquipmentNavigation.Name,
                              Number = sheet.IdSupplyNavigation.Number
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from sheet in _context.SupplySheetOfEquipments
                          where sheet.IdSheet == id
                          select new
                          {
                              Id = sheet.IdSheet,
                              DateOfSupply = sheet.DateOfSupply,
                              Provider = sheet.IdProviderNavigation.Name,
                              Equipment = sheet.IdSupplyNavigation.IdEquipmentNavigation.Name,
                              Number = sheet.IdSupplyNavigation.Number
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(SupplyOfEquipmentSheetView supplyOfEquipmentSheetView)
        {
            SupplySheetOfEquipment supplySheetOfEquipment = new SupplySheetOfEquipment()
            {
                DateOfSupply = supplyOfEquipmentSheetView.DateOfSupply,
                IdProvider = supplyOfEquipmentSheetView.IdProvider,
                IdSupply = supplyOfEquipmentSheetView.IdSupply,
                IdEmployee = supplyOfEquipmentSheetView.IdEmployee
            };
            _context.SupplySheetOfEquipments.Add(supplySheetOfEquipment);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(SupplyOfEquipmentSheetView supplyOfEquipmentSheetView)
        {
            _context.SupplySheetOfEquipments.Remove(_context.SupplySheetOfEquipments.Where(p => p.IdSheet == supplyOfEquipmentSheetView.IdSheet).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(SupplyOfEquipmentSheetView supplyOfEquipmentSheetView)
        {
            var result = (from sheetSelect in _context.SupplySheetOfEquipments
                          where sheetSelect.IdSheet == supplyOfEquipmentSheetView.IdSheet
                          select sheetSelect).FirstOrDefault();
            result.DateOfSupply = supplyOfEquipmentSheetView.DateOfSupply;
            result.IdProvider = supplyOfEquipmentSheetView.IdProvider;
            result.IdSupply = supplyOfEquipmentSheetView.IdSupply;
            result.IdEmployee = supplyOfEquipmentSheetView.IdEmployee;
            _context.SaveChanges();
        }
    }
}
