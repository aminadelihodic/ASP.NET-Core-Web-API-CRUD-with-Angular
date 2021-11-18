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
    [Route("api/permissions/")]
    [ApiController]
    public class PermissionsController : Controller
    {
        private readonly IRepositoryPermission _repositoryPermission;
        public PermissionsController(IRepositoryPermission repositoryPermission)
        {
            _repositoryPermission = repositoryPermission;
        }

        [HttpPost]

        public IActionResult Insert([FromBody] Permission permission)
        {
            _repositoryPermission.Insert(permission);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Permission permission)
        {

            _repositoryPermission.Delete(permission);
            return Ok(permission);
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var permissions = _repositoryPermission.GetAll();
            return Ok(permissions);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] Permission permission)
        {
            _repositoryPermission.Update(permission);
            return Ok(permission);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromHeader] Permission permission)
        {
            _repositoryPermission.GetById(permission);
            return Ok(permission);
        }
    }
}
