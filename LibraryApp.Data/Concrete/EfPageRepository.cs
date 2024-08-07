using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Concrete
{
    public class EfPageRepository : IPageRepository
    {
        public IQueryable<Page> Pages => _context.Pages;
        private LibraryDbContext _context;

        public EfPageRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void CreatePage(Page page)
        {
            throw new NotImplementedException();
        }
    }
}