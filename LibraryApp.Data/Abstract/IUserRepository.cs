using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        void CreateUser(User user);
    }
}