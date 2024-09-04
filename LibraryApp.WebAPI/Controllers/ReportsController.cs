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
    public class ReportsController : ControllerBase
    {
        IUserRepository _userRepo;
        IRoleRepository _roleRepo;
        IBookRepository _bookRepo;
        IBookBorrowActivityRepository _borrowActRepo;

        public ReportsController(IUserRepository userRepo, IRoleRepository roleRepo, IBookRepository bookRepo, IBookBorrowActivityRepository borrowActRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _bookRepo = bookRepo;
            _borrowActRepo = borrowActRepo;
        }

        [HttpGet("GetReports")]
        [Authorize(Policy = "ManagerPolicy")]
        [Authorize(Policy = "NotPunishedPolicy")]
        public async Task<IActionResult> GetReports([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            IQueryable<User> usersBetweenDates = _userRepo.Users
            .AsNoTracking()
            .Where(u => u.AccountCreationDate > startDate && u.AccountCreationDate < endDate);
            IQueryable<BookBorrowActivity> bookBorrowActivities = _borrowActRepo.BookBorrowActivities
            .AsNoTracking()
            .Where(bba => bba.BorrowDate > startDate && bba.BorrowDate < endDate);

            int totalUserCount = await usersBetweenDates.CountAsync();
            int totalBookCount = await _bookRepo.Books
            .AsNoTracking()
            .Where(b => b.PublishDate > startDate && b.PublishDate < endDate)
            .CountAsync();

            var usersPerRole = await _roleRepo.Roles
            .AsNoTracking()
            .Select(r => new KeyValuePair<string, int>(
                r.Name,
                usersBetweenDates.Count(u => u.RoleId == r.Id)
            ))
            .ToListAsync();

            var mostBorrowedBooks = await bookBorrowActivities
            .Include(bba => bba.Book)
            .GroupBy(bba => bba.Book)
            .OrderByDescending(g => g.Count())
            .Take(10)
            .Select(g => new KeyValuePair<string, int>(
                g.Key.Title,
                g.Count()
            ))
            .ToListAsync();

            var mostScoredMembers = await usersBetweenDates
            .Where(u => u.RoleId < 4)
            .OrderByDescending(u => u.MonthlyScore)
            .Take(10)
            .Select(u => new KeyValuePair<string, int>(
                u.Name + " " + u.Surname,
                u.MonthlyScore
            ))
            .ToListAsync();

            var mostBorrowers = await bookBorrowActivities
            .Include(bba => bba.User)
            .GroupBy(bba => bba.User)
            .OrderByDescending(g => g.Count())
            .Take(10)
            .Select(g => new KeyValuePair<string, int>(
                g.Key.Name + " " + g.Key.Surname,
                g.Count()
            ))
            .ToListAsync();

            return Ok(new ReportDTO{
                MostBorrowedBooks = mostBorrowedBooks,
                MostBorrowers = mostBorrowers,
                MostScoredMembers = mostScoredMembers,
                totalBookCount = totalBookCount,
                TotalUserCount = totalUserCount,
                UsersPerRole = usersPerRole,
            });
        }
    }
}