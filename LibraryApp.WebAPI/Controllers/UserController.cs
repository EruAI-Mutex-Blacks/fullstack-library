using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fullstack_library.DTO;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fullstack_library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IMessageRepository _msgRepo;

        public UserController(IUserRepository userRepo, IMessageRepository msgRepo)
        {
            _userRepo = userRepo;
            _msgRepo = msgRepo;
        }

        [HttpPut("ApproveRegistiration/{userId}")]
        public IActionResult ApproveRegistiration(int? userId)
        {
            //TODO to approve registiration use role table make a role which is like newUser or no role at all and when we approve change role to like default user or like give selection to user to make him select which role he wants and we can see it if we approve make it that role. And again only staffs can access to this method
            if (userId == null) return BadRequest(new { message = "Invalid user id" });
            var user = _userRepo.GetUserById(userId.Value);
            if (user == null) return NotFound(new { message = "User not found" });

            user.RoleId = 1; //make it like default role
            _userRepo.UpdateUser(user);

            return Ok(new { message = "User approved" });
        }

        [HttpDelete("DeleteRegistiration/{userId}")]
        public IActionResult DeleteRegistiration(int? userId)
        {
            //TODO instead of deletion think another thing
            if (userId == null) return BadRequest(new { message = "Invalid user id" });
            var user = _userRepo.GetUserById(userId.Value);
            if (user == null) return NotFound(new { message = "User not found" });

            _userRepo.DeleteUser(user);

            return Ok(new { message = "User rejected" });
        }

        [HttpPut("set-punishment/{userId}")]
        public IActionResult SetPunishment(int? userId, [FromQuery] bool isPunished, [FromQuery] int fineAmount)
        {
            //TODO can be used for both staff and users like if it is punished cannot login to system and later on we can change ispunished to false and maybe use punishmentDTO for the parameters

            if (userId == null) return BadRequest(new { message = "Invalid user id" });
            var user = _userRepo.GetUserById(userId.Value);
            if (user == null) return NotFound(new { message = "User not found" });
            user.IsPunished = isPunished;
            user.FineAmount = fineAmount;
            _userRepo.UpdateUser(user);
            return Ok(new { message = "Punishment status updated" });
        }

        [HttpPost("SendMessage")]
        public IActionResult SendMessage(MessageDTO msg)
        {
            var sender = _userRepo.GetUserById(msg.SenderId);
            if (sender == null) return NotFound(new { message = "Sender user not found" });
            var receiver = _userRepo.GetUserById(msg.ReceiverId);
            if (receiver == null) return NotFound(new { message = "Receiver user not found" });

            var entity = new Message
            {
                SenderId = msg.SenderId,
                ReceiverId = msg.ReceiverId,
                Title = msg.Title,
                Details = msg.Details,
            };
            _msgRepo.CreateMessage(entity);

            return Ok(new {Message = "Message has been sent"});
        }

        [HttpGet("GetMsgReceivers")]
        public IActionResult GetMsgReceivers([FromQuery] int roleId, [FromQuery] int userId)
        {
            //designed like the higher the role the greater it's id
            var users = _userRepo.Users.Where(u => u.RoleId <= roleId && u.RoleId != 1 && u.Id != userId).Include(u => u.Role);

            return Ok(users.Select(u => new
            {
                Id = u.Id,
                Name = u.Name + " " + u.Surname,
                RoleName = u.Role.Name,
            }
            ));
        }
    }
}