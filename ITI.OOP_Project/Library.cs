using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

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


        //********************************** Add Book Function ***********************************
        
        private List<Book> books = new List<Book>();

        public void AddBook(int id, string title, string author)
        {
            foreach(Book book in books)
            {
                if(book.Id == id && book.Title == title && book.Author == author)
                {
                    Console.WriteLine("This book is already exist");
                }
            }
            books.Add(new Book(id, title, author));
            Console.WriteLine("Book added successfully");   
        }



        public void BorrowBook(int bookId, int memberId)
        {
        var book = Books.FirstOrDefault(b => b.Id == bookId);
        var member = Members.FirstOrDefault(m => m.Id == memberId);
        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }
        if (member == null)
        {
            Console.WriteLine("Member not found.");
            return;
        }
        if (!book.IsAvailable)
        {
            Console.WriteLine("Book is not available for borrowing.");
            return;
        }
        book.IsAvailable = false;
        member.BorrowedBooks.Add(book);
        //Alice Smith borrowed 'The Great Gatsby'
        Console.WriteLine($"{member.Name} borrowed '{book.Title}'");
        }
        
        public void ReturnBook(int bookId, int memberId)
        {
        var book = Books.FirstOrDefault(b => b.Id == bookId);
        var member = Members.FirstOrDefault(m => m.Id == memberId);
        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }
        if (member == null)
        {
            Console.WriteLine("Member not found.");
            return;
        }
        if (book.IsAvailable || !member.BorrowedBooks.Contains(book))
        {
            Console.WriteLine("This book was not borrowed by this member.");
            return;
        }
        book.IsAvailable = true;
        member.BorrowedBooks.Remove(book);
        //Alice Smith returned 'The Great Gatsby'
        Console.WriteLine($"{member.Name} returned '{book.Title}'");
        }

    }
}
