using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract
{
    public interface IPageRepository
    {
        IQueryable<Page> Pages { get; }

        void CreatePage(Page page);
    }
}