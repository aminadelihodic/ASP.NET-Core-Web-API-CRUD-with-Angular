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
        [Route("{id}")]

        public IActionResult Delete([FromRoute] string id)
        {
            _repositoryRole.Delete(id);
            return Ok();
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var roles = await _repositoryRole.GetAll();
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
        public async Task<IActionResult> GetById(string id)
        {
            var roles = await _repositoryRole.GetById(id);
            return Ok(roles);
        }
    }
}
