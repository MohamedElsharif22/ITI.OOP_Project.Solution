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
                if(book.Id == id || book.Title.Equals(title,StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("This book is already exist");
                    return;
                }
            }
            books.Add(new Book(id, title, author));
            Console.WriteLine("Book added successfully");   
        }

        //********************************** Remove Book Function ***********************************

        public void RemoveBook(int id)
        {
            foreach(Book book in books)
            {
                if(book.Id == id)
                {
                    books.Remove (book);
                    Console.WriteLine("Book removed successfully");
                    return;
                }
            }
            Console.WriteLine("This book is not exist");

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

        // Ghazaly's code for adding and removing members
        public void AddMember(Member member)
        { 
            if(member!=null)
            {
                foreach(var m in Members)
                {
                    if(m.Id== member.Id)
                    { 
                        Console.WriteLine("member is Already in Memberlist");      
                        return;
                    }
                }
                Members.Add(member);

            }
            else
            {
                Members.Add(member);
            }
        }
        public void removeMember(int memberId)
        {
            int v = 0;
            foreach (Member m in Members)
            {
                if (m.Id == memberId)
                {
                    Members.Remove(m);
                    v=1; break;
                }
            }
            if(v == 0)
            {
                Console.WriteLine("member is Already not found");
            }
          
        }
    }
}
