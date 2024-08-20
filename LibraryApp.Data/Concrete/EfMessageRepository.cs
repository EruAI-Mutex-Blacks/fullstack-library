using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Concrete
{
    public class EfMessageRepository : IMessageRepository
    {
        public IQueryable<Message> Messages => _context.Messages;
        private LibraryDbContext _context;

        public EfMessageRepository(LibraryDbContext libraryDbContext)
        {
            _context = libraryDbContext;
        }

        public void CreateMessage(Message msg)
        {
            _context.Messages.Add(msg);
            _context.SaveChanges();
        }

        public void GetMessagesByReceiverId(int receiverId)
        {
            throw new NotImplementedException();
        }

        public void GetMessagesBySenderId(int senderId)
        {
            throw new NotImplementedException();
        }
    }
}