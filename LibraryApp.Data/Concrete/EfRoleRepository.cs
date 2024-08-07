using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Concrete
{
    public class EfRoleRepository : IRoleRepository
    {
        public IQueryable<Role> Roles => _context.Roles;
        private LibraryDbContext _context;

        public EfRoleRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void CreateRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}