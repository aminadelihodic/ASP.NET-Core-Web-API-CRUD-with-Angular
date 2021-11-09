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
    [Route("api/roles/{roleId}/permissions/")]
    [ApiController]
    public class RolePermissionsController : Controller
    {
        private readonly IRepositoryRolePermission _repositoryRolePermission;
        public RolePermissionsController(IRepositoryRolePermission repositoryRolePermission)
        {
            _repositoryRolePermission = repositoryRolePermission;
        }

        
        [HttpPost]
        [Route("{permissionId}")]
        public IActionResult Insert(RolePermission rolePermission)
        {
            _repositoryRolePermission.Insert(rolePermission);
            return Ok();
        }
        [HttpDelete]
        [Route("{permissionId}")]

        public IActionResult Delete([FromRoute] string roleId, [FromRoute] string permissionId)
        {
            _repositoryRolePermission.Delete(roleId, permissionId);
            return Ok();
        }
        [HttpGet]

        public async Task<IActionResult> GetAll(string roleId)
        {
            var roles = await _repositoryRolePermission.GetAll(roleId);
            return Ok(roles);
        }
        [HttpPut]

        public IActionResult Update([FromBody] RolePermission rolePermission)
        {
            _repositoryRolePermission.Update(rolePermission);
            return Ok(rolePermission);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var roles = await _repositoryRolePermission.GetById(id);
            return Ok(roles);
        }
    }
}

