using System;
using AutoMapper;
using InLogicApp.API.Authorization;
using InLogicApp.API.Helper;
using InLogicApp.API.Model.Users;
using InLogicApp.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InLogicApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private IUserService context;
        private readonly AppSettings _appSettings;
        
        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public UsersController(IUserService context)
        {
            this.context = context;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
          var response =  _userService.Authenticate(model);
          return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("registeruser")]
        public IActionResult Register(RegisterRequest model)
        {
                _userService.Register(model);
                return Ok(new { message = "Registration successful" });
         
        }

        [Authorize]
        [HttpGet("GetAllUsers")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("GetUserById/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [Authorize]
        [HttpPut("UpdateUser/{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            _userService.Update(id, model);
            return Ok(new { message = "User updated successfully" });
        }

        [Authorize]
        [HttpDelete("DeleteUser/{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }

    }
}