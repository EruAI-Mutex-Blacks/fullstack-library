using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.Entity
{
    public class Author : User
    {
        public int id { get; set; }
        public int bookWritten { get; set; }
        public float experience { get; set; }
        public void writeBook()
        {
            //sistem �zerinden
        }
        public void uploadBook()
        {
            //PDF olarak
        }
        public void requestBookAddition()
        {
            //Ekleme talebi
        }
    }
}