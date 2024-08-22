using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fullstack_library.DTO;
using LibraryApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using LibraryApp.Data.Entity;
using Microsoft.EntityFrameworkCore;

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
            var user = _userRepo.Users.Include(u => u.Role).FirstOrDefault(u => u.Username == loginDTO.Username);
            if (user == null) return NotFound(new { message = "Username not found" });
            if (user.Password != loginDTO.Password) return StatusCode(401, new { message = "Password is incorrect" });

            //TODO return with jwt
            UserDTO userDTO = new UserDTO
            {
                Id = user.Id,
                RoleId = user.RoleId,
                RoleName = user.Role.Name,
                Name = user.Name,
                Surname = user.Surname,
                Gender = user.Gender,
                BirthDate = user.BirthDate,
                FineAmount = user.FineAmount,
                IsPunished = user.IsPunished,
                Username = user.Username,
            };
            return Ok(userDTO);
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            _userRepo.CreateUser(new User
            {
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
                Username = registerDTO.Username,
                Password = registerDTO.Password,
                BirthDate = registerDTO.BirthDate,
                Gender = registerDTO.Gender,
                RoleId = 1,
            });
            return Ok(new { message = "User registered" });
        }
    }
}