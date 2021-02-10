using Deloitte.Domain;
using Deloitte.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deloitte.RepositoryPattern.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsers _UserService;
        public LoginController(IUsers UserService)
        {
            this._UserService = UserService;
        }


        [HttpGet]
        public User Login(string Id, string password)
        {
            return _UserService.Login(Id, password);
        }
    }
}
