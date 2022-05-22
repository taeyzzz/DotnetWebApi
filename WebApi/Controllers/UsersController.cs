using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Models;
using CoreApp.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    public class UsersController : ApiBaseController
    {
        private readonly IUsersService _usersService;
        private readonly IConfiguration _configuration;

        public UsersController(IUsersService usersService, IConfiguration configuration)
        {
            _usersService = usersService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {           
            return Ok(await _usersService.GetAllUsers());
        }

        [HttpGet]
        [Route("heathcheck")]
        public ActionResult<string> GetHealthCheck()
        {
            var key = _configuration.GetSection("Secret:Key");
            return Ok(key.Value);
        }
    }
}
