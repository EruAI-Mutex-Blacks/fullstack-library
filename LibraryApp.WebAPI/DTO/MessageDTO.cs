using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class MessageDTO
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
    }
}