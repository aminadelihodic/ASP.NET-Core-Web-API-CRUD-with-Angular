using amina_WebApplication.Models;
using aminaApplication.Dapper.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amina_WebApplication.Controllers
{
    [Route("api/cities/")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly IRepositoryCity _repositoryCity;

        public CitiesController(IRepositoryCity repositoryCity)
        {
            _repositoryCity = repositoryCity;

        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _repositoryCity.Delete(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var cities = await _repositoryCity.GetAll();
            return Ok(cities);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] City city)
        {
            _repositoryCity.Insert(city);
            return Ok(city);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var cities = await _repositoryCity.GetById(id);
            return Ok(cities);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] City city)
        {
            _repositoryCity.Update(city);
            return Ok(city);
        }
    }
}
