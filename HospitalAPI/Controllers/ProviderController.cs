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
    public class ProviderController : ControllerBase
    {
        private hospital_DBContext _context;

        public ProviderController(hospital_DBContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<object> Show()
        {
            var result = (from provider in _context.Providers
                          select new
                          {
                              Id = provider.IdProvider,
                              Name = provider.Name,
                              INN = provider.Inn,
                              Address = provider.Address
                          }).ToList();
            return result;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<object> Show(int id)
        {
            var result = (from provider in _context.Providers
                          where provider.IdProvider == id
                          select new
                          {
                              Id = provider.IdProvider,
                              Name = provider.Name,
                              Inn = provider.Inn,
                              Address = provider.Address
                          }).ToList();
            return result;
        }

        [Route("[action]")]
        [HttpPost]
        public void Add(ProviderView providerView)
        {
            Provider provider = new Provider()
            {
                Name = providerView.Name,
                Inn = providerView.Inn,
                Address = providerView.Address
            };
            _context.Providers.Add(provider);
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Remove(ProviderView providerView)
        {
            _context.Providers.Remove(_context.Providers.Where(p => p.IdProvider == providerView.IdProvider).FirstOrDefault());
            _context.SaveChanges();
        }

        [Route("[action]")]
        [HttpPost]
        public void Update(ProviderView providerView)
        {
            var result = (from providerSelect in _context.Providers
                          where providerSelect.IdProvider == providerView.IdProvider
                          select providerSelect).FirstOrDefault();
            result.Name = providerView.Name;
            result.Inn = providerView.Inn;
            result.Address = providerView.Address;
            _context.SaveChanges();
        }
    }
}
