using aminaApplication.Dapper.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amina_WebApplication.Controllers
{
    [Route("api/login/user-profile/")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IRepositoryUserProfile _repositoryUserProfile;
        public UserProfileController(IRepositoryUserProfile repositoryUserProfile)
        {
            _repositoryUserProfile = repositoryUserProfile;

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var user = await _repositoryUserProfile.GetById(id);
            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repositoryUserProfile.GetAll();
            return Ok(users);
        }
    }
}
