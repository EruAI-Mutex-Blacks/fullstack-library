using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class BookBorrowActivityDTO
    {
        [Column(TypeName = "DATE")]
        public DateTime BorrowDate { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime ReturnDate { get; set; }

        public BookDTO BookDTO { get; set; } = null!;
    }
}