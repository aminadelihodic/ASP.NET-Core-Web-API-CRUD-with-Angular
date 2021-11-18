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
    [Route("api/roles/")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IRepositoryRole _repositoryRole;
        public RolesController(IRepositoryRole repositoryRole)
        {
            _repositoryRole = repositoryRole;
        }

        [HttpPost]

        public IActionResult Insert([FromBody] Role role)
        {
            _repositoryRole.Insert(role);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Role role)
        {

            _repositoryRole.Delete(role);
            return Ok(role);
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var roles = _repositoryRole.GetAll();
            return Ok(roles);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] Role role)
        {
            _repositoryRole.Update(role);
            return Ok(role);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromHeader] Role role)
        {
            _repositoryRole.GetById(role);
            return Ok(role);
        }
    }
}
