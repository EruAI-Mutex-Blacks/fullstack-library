using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace fullstack_library.DTO
{
    public class ReadBookDTO
    {
        public string Title { get; set; } = string.Empty;
        public List<PageDTO> Pages { get; set; } = new();
    }
}