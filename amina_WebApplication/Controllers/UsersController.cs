using amina_WebApplication.Models;
using aminaApplication.Dapper.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace amina_WebApplication.Controllers
{
    [Route("api/users/")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IRepositoryUser _repositoryUser;
        private IConfiguration _config;
        public UsersController(IConfiguration config, IRepositoryUser repositoryUser)
        {
            _config = config;
            _repositoryUser = repositoryUser;

        }

        [HttpPost]

        public IActionResult Insert([FromBody] User user)
        {
            _repositoryUser.Insert(user);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]

        public IActionResult Delete([FromRoute] int id)
        {
            _repositoryUser.Delete(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repositoryUser.GetAll();
            return Ok(users);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] User user)
        {
            _repositoryUser.Update(user);
            return Ok(user);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var users = await _repositoryUser.GetById(id);
            return Ok(users);
        }
    }
}
 