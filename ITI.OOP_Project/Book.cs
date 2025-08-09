using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.OOP_Project
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

        public Book(int id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
            IsAvailable = true; // Default to available when a book is created
        }
    }
}
