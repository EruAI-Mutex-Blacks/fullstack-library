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
        private readonly IRoleRepository _roleRepo;

        public UserController(IUserRepository userRepo, IMessageRepository msgRepo, IRoleRepository roleRepo)
        {
            _userRepo = userRepo;
            _msgRepo = msgRepo;
            _roleRepo = roleRepo;
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

            //FIXME cannot send title rn

            var entity = new Message
            {
                SenderId = msg.SenderId,
                ReceiverId = msg.ReceiverId,
                Title = msg.Title,
                Details = msg.Details,
            };
            _msgRepo.CreateMessage(entity);

            return Ok(new { Message = "Message has been sent" });
        }

        [HttpGet("GetInbox")]
        public IActionResult GetInbox([FromQuery] int userId)
        {
            var msgs = _msgRepo.GetMessagesByReceiverId(userId).Take(15).Reverse();

            return Ok(msgs.Select(m =>
            new MessageDTO
            {
                Title = m.Title,
                Details = m.Details,
                ReceiverId = m.ReceiverId,
                SenderId = m.SenderId,
                SenderName = m.Sender.Name + " " + m.Sender.Surname,
            }));
        }

        [HttpGet("GetUsersOfLowerOrEqualRole")]
        public IActionResult GetUsersOfLowerOrEqualRole([FromQuery] int roleId, [FromQuery] int userId)
        {
            //designed like the higher the role the greater it's id
            //return lower or same roles
            var users = _userRepo.Users.Where(u => u.RoleId <= roleId && u.RoleId != 1 && u.Id != userId).Include(u => u.Role);

            return Ok(users.Select(u => new
            {
                Id = u.Id,
                Name = u.Name + " " + u.Surname,
                RoleName = u.Role.Name,
            }
            ));
        }

        [HttpGet("GetUsersOfLowerRole")]
        public IActionResult GetUsersOfLowerRole([FromQuery] int roleId, [FromQuery] int userId)
        {
            //designed like the higher the role the greater it's id
            //return lower roles
            var users = _userRepo.Users.Where(u => u.RoleId < roleId && u.RoleId != 1 && u.Id != userId).Include(u => u.Role);

            return Ok(users.Select(u => new
            {
                Id = u.Id,
                Name = u.Name + " " + u.Surname,
                RoleId = u.RoleId,
                RoleName = u.Role.Name,
                IsPunished = u.IsPunished,
                FineAmount = u.FineAmount,
            }
            ));
        }

        [HttpGet("MemberRegistirations")]
        public IActionResult GetPendingRegistirations()
        {
            var pendingUsers = _userRepo.Users.Where(u => u.RoleId == 1);

            return Ok(pendingUsers.Select(pu => new UserDTO
            {
                BirthDate = pu.BirthDate,
                Gender = pu.Gender,
                Id = pu.Id,
                Name = pu.Name,
                Surname = pu.Surname,
                Username = pu.Username,
            }));
        }

        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles([FromQuery] int roleId)
        {
            //designed like the higher the role the greater it's id
            //return lower roles
            var roles = _roleRepo.Roles.Where(r => r.Id != roleId && r.Id != 1);

            return Ok(roles.Select(r => new
            {
                r.Id,
                r.Name
            }
            ));
        }
    }
}