using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract
{
    public interface IRoleRepository
    {
        IQueryable<Role> Roles { get; }

        void CreateRole(Role role);
    }
}