using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fullstack_library.DTO;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;
using Microsoft.AspNetCore.Authorization;
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

        //TODO encrypt password when saving to db

        [HttpPut("SetRegistirationRequest")]
        [Authorize(Policy = "StaffOrManagerPolicy")]
        public async Task<IActionResult> SetRegistirationRequest(UserRegistirationDTO userRegistirationDTO)
        {
            var user = await _userRepo.GetUserByIdAsync(userRegistirationDTO.UserId);
            if (user == null) return NotFound(new { message = "User not found" });

            var staff = await _userRepo.GetUserByIdAsync(userRegistirationDTO.StaffId);
            if (staff == null) return NotFound(new { message = "Staff not found" });

            staff.MonthlyScore += user.AccountCreationDate.AddDays(1) >= DateTime.UtcNow ? 1 : -1;

            if (userRegistirationDTO.IsApproved)
            {
                user.RoleId++;
                user.AccountCreationDate = DateTime.UtcNow;
                await _userRepo.UpdateUserAsync(user);
            }
            else
                await _userRepo.DeleteUserAsync(user);

            return Ok(new { message = userRegistirationDTO.IsApproved ? "Request approved." : "Request rejected" });
        }

        [HttpPut("SetPunishment")]
        [Authorize(Policy = "StaffOrManagerPolicy")]
        public async Task<IActionResult> SetPunishment(PunishUserDTO punishUserDTO)
        {
            var user = await _userRepo.GetUserByIdAsync(punishUserDTO.UserId);
            if (user == null) return NotFound(new { message = "User not found" });
            if (!_userRepo.Users.Any(u => u.Id == punishUserDTO.PunisherId)) return NotFound(new { message = "Punisher not found" });

            user.FineAmount = punishUserDTO.FineAmount;
            user.IsPunished = punishUserDTO.IsPunished;

            await _userRepo.UpdateUserAsync(user);
            await _msgRepo.CreateMessageAsync(new Message
            {
                ReceiverId = user.Id,
                Details = punishUserDTO.IsPunished ? punishUserDTO.Details : "Your punishment removed. Thanks for being good boy.",
                SenderId = punishUserDTO.PunisherId,
                Title = punishUserDTO.IsPunished ? "You are punished from library at " + DateTime.UtcNow : "Your punishment removed.",
            });

            return Ok(new { message = punishUserDTO.IsPunished ? "User punished." : "Punishment removed." });
        }

        [HttpPost("SendMessage")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        public async Task<IActionResult> SendMessage(MessageDTO msg)
        {
            var sender = await _userRepo.GetUserByIdAsync(msg.SenderId);
            if (sender == null) return NotFound(new { message = "Sender user not found" });
            var receiver = await _userRepo.GetUserByIdAsync(msg.ReceiverId);
            if (receiver == null) return NotFound(new { message = "Receiver user not found" });

            var entity = new Message
            {
                SenderId = msg.SenderId,
                ReceiverId = msg.ReceiverId,
                Title = msg.Title,
                Details = msg.Details,
            };
            await _msgRepo.CreateMessageAsync(entity);

            return Ok(new { Message = "Message has sent" });
        }

        [HttpGet("GetInbox")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        public async Task<IActionResult> GetInbox([FromQuery] int userId)
        {
            var msgs = await _msgRepo.GetMessagesByReceiverIdAsync(userId);
            msgs.Reverse();
            return Ok(msgs.Select(m =>
            new MessageDTO
            {
                Id = m.Id,
                Title = m.Title,
                Details = m.Details,
                ReceiverId = m.ReceiverId,
                SenderId = m.SenderId,
                SenderName = m.Sender.Name + " " + m.Sender.Surname,
                IsReceiverRead = m.IsReceiverRead,
            }));
        }

        [HttpGet("GetUsersOfLowerOrEqualRole")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        public async Task<IActionResult> GetUsersOfLowerOrEqualRole([FromQuery] int roleId, [FromQuery] int userId)
        {
            //designed like the higher the role the greater it's id
            //return lower or same roles
            var users = await _userRepo.Users.Where(u => u.RoleId <= roleId && u.RoleId != 1 && u.Id != userId).Include(u => u.Role).ToListAsync();

            return Ok(users.Select(u => new
            {
                Id = u.Id,
                Name = u.Name + " " + u.Surname,
                RoleName = u.Role.Name,
            }
            ));
        }

        [HttpGet("GetUsersOfLowerRole")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        public async Task<IActionResult> GetUsersOfLowerRole([FromQuery] int roleId, [FromQuery] int userId)
        {
            //designed like the higher the role the greater it's id
            //return lower roles
            var users = await _userRepo.Users.Where(u => u.RoleId < roleId && u.RoleId != 1 && u.Id != userId).Include(u => u.Role).ToListAsync();

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
        [Authorize(Policy = "StaffOrManagerPolicy")]
        public async Task<IActionResult> GetPendingRegistirations()
        {
            var pendingUsers = await _userRepo.Users.Where(u => u.RoleId == 1).ToListAsync();

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
        [Authorize(Policy = "MemberOrHigherPolicy")]
        public async Task<IActionResult> GetAllRoles([FromQuery] int roleId)
        {
            //designed like the higher the role the greater it's id
            //return lower roles
            var roles = await _roleRepo.Roles.Where(r => r.Id != roleId && r.Id != 1).ToListAsync();

            return Ok(roles.Select(r => new
            {
                r.Id,
                r.Name
            }
            ));
        }

        [HttpPut("UpdateMessageReadState")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        public async Task<IActionResult> UpdateMessageReadState(MessageDTO readMsg)
        {
            var msg = _msgRepo.Messages.FirstOrDefault(m => m.Id == readMsg.Id);
            if (msg == null) return NotFound(new { Message = "Message could not found" });
            msg.IsReceiverRead = true;

            await _msgRepo.UpdateMessageAsync(msg);

            return Ok();
        }

        [HttpPut("ChangeRole")]
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> ChangeRole(UpdateRoleDTO updateRoleDTO)
        {
            var user = await _userRepo.GetUserByIdAsync(updateRoleDTO.UserId);
            if (user == null) return NotFound(new { Message = "User could not found" });
            if (!_roleRepo.Roles.Any(r => r.Id == updateRoleDTO.NewRoleId)) return NotFound(new { Message = "Role could not found" });

            user.RoleId = updateRoleDTO.NewRoleId;
            await _userRepo.UpdateUserAsync(user);
            return Ok(new { Message = "User's role changed." });
        }

        [HttpGet("GetStaffOfMonth")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        public async Task<IActionResult> GetStaffOfMonth()
        {
            var maxScore = await _userRepo.Users.Where(u => u.RoleId == 3).MaxAsync(u => u.MonthlyScore);
            var staff = await _userRepo.Users.FirstOrDefaultAsync(u => u.RoleId == 3 && u.MonthlyScore == maxScore);

            return Ok(new UserDTO{
                BirthDate = staff!.BirthDate,
                Gender = staff.Gender,
                Name = staff.Name,
                Surname = staff.Surname,
            });
        }
    }
}