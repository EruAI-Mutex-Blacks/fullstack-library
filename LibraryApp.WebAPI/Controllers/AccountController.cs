using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fullstack_library.DTO;
using LibraryApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace fullstack_library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public AccountController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var user = _userRepo.GetUsers().FirstOrDefault(u => u.Username == loginDTO.Username);
            if(user == null) return NotFound("Username not found");
            if(user.Password != loginDTO.Password) return StatusCode(401, "Password is incorrect");

            //TODO return with jwt
            return Ok(user);
        }
    }
}