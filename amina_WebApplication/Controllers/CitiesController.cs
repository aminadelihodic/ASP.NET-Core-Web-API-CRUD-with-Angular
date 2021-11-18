using amina_WebApplication.Models;
using aminaApplication.Dapper.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace amina_WebApplication.Controllers
{
    [Route("api/cities/")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IRepositoryCity _repositoryCity;
        public CitiesController(IRepositoryCity repositoryCity)
        {
            _repositoryCity = repositoryCity;

        }
        [HttpDelete]
        public IActionResult Delete([FromBody] City city)
        {
            _repositoryCity.Delete(city);
            return Ok(city);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var cities = _repositoryCity.GetAll();
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
        public  IActionResult GetById([FromHeader] City city)
        {
            _repositoryCity.GetById(city);
            return Ok(city);
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
