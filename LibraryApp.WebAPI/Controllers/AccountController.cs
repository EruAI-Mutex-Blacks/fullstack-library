using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fullstack_library.DTO;
using LibraryApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using LibraryApp.Data.Entity;

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

        //TODO make every action method async Task<>

        [HttpPost("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var user = _userRepo.GetUsers().FirstOrDefault(u => u.Username == loginDTO.Username);
            if (user == null) return NotFound(new { message = "Username not found" });
            if (user.Password != loginDTO.Password) return StatusCode(401, new { message = "Password is incorrect" });

            //TODO return with jwt
            //TODO do not return entity directly return dto instead with only id and username enough
            return Ok(user);
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            //TODO here we make user newUser first then a staff will approve or deny the req
            _userRepo.CreateUser(new User
            {
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
                Username = registerDTO.Username,
                Password = registerDTO.Password,
                BirthDate = registerDTO.BirthDate,
                Gender = registerDTO.Gender,
            });
            return Ok(new { message = "User registered" });
        }
    }
}