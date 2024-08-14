using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Data.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; } 
        public string Content { get; set; } = string.Empty;

        public User Sender { get; set; } = null!;
        public User Receiver { get; set; } = null!;
    }
}