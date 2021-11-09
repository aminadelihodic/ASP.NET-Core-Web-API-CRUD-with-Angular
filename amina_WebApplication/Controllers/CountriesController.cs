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

        [HttpPost("add_country")]
        public IActionResult Insert([FromBody] Country country)
        {
            _countryRepository.Insert(country);
            return Ok(country);
        }
        [HttpDelete]
        [Route("{id}")]

        public IActionResult Delete(int id)
        {

            _countryRepository.Delete(id);
            return Ok();
        }
        [HttpGet("get_country")]

        public async Task<IActionResult> GetAll()
        {
            var countries = await _countryRepository.GetAll();
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
        public async Task<IActionResult> GetById(int id)
        {
            var countries = await _countryRepository.GetById(id);
            return Ok(countries);
        }

    }
}