using amina_WebApplication.Models;
using aminaApplication.Dapper.Interfaces;
using aminaApplication.Dapper.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amina_WebApplication.Controllers
{
    [Route("api/countries/")]
    public class CountriesController : Controller
    {
        private readonly IRepositoryCountry _countryRepository;
        public CountriesController(IRepositoryCountry countryRepository)
        {
            _countryRepository = countryRepository;

        }

        [HttpPost]
        public IActionResult Insert([FromBody] Country country)
        {
            _countryRepository.Insert(country);
            return Ok(country);
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Country country)
        {

            _countryRepository.Delete(country);
            return Ok(country);
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var countries = _countryRepository.GetAll();
            return Ok(countries);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] Country country)
        {
            _countryRepository.Update(country);
            return Ok(country);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromHeader] Country country)
        {
            _countryRepository.GetById(country);
            return Ok(country);
        }

    }
}