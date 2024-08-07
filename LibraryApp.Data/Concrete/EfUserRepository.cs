using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Concrete
{
    public class EfUserRepository : IUserRepository
    {
        public IQueryable<User> Users => _context.Users;
        private LibraryDbContext _context;

        public EfUserRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}