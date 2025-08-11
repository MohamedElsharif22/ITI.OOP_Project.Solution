using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.OOP_Project
{
    internal class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; }
        public Member(int id, string name)
        {
            Id = id;
            Name = name;
            BorrowedBooks = new List<Book>();
        }

        public void DisplayBorrowedBooks()
        {
            Console.WriteLine($"Borrowed Books by {Name}:");
            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("No books borrowed.");
            }
            else
            {
                Console.WriteLine($"{Name}'s List of borrowed books:");
                foreach (var book in BorrowedBooks)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
                }
            }
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}";
        }
    }
}
