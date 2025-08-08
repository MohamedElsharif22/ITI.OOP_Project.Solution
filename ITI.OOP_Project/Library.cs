using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.OOP_Project
{
    internal class Library
    {
        public List<Book> Books { get; set; }
        public List<Member> Members { get; set; }
        public Library()
        {
            Books = new List<Book>();
            Members = new List<Member>();
        }

        public Library(List<Book> books, List<Member> members)
        {
            Books = books ?? new List<Book>();
            Members = members ?? new List<Member>();
        }
    }
}
