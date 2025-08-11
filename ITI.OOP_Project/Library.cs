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
        //********************************** Show Available Books Function ***********************************
        public void ShowAvailableBooks()
        {
            bool isEmpty = true;
            Console.WriteLine("Available Books:");
            foreach (var book in Books)
            {
                if (book.IsAvailable)
                {
                    isEmpty = false;
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
                }
            }
            if (isEmpty)
                Console.WriteLine("No available books.");
            
        }
        //********************************** Show Borrowed Books Function ***********************************
        public void ShowBorrowedBooks()
        {
            bool isEmpty = true;
            Console.WriteLine("Borrowed Books:");
            foreach (var book in Books)
            {
                if (!book.IsAvailable)
                {
                    isEmpty = false;
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
                }
            }
            if (isEmpty)
                Console.WriteLine("No borrowed books.");
        }

        //*********************************** Show Members Function ***********************************
        public void ShowMembers()
        {
            if (Members.Count == 0)
            {
                Console.WriteLine("No members in the library.");
                return;
            }
            Console.WriteLine("Members:");
            foreach (var member in Members)
            {
                Console.WriteLine(member);
            }
        }


        //********************************** Add Book Function ***********************************

        public void AddBook(int id, string title, string author)
        {
            foreach(Book book in Books)
            {
                if(book.Id == id || book.Title.Equals(title,StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("This book is already exist");
                    return;
                }
            }
            Books.Add(new Book(id, title, author));
            Console.WriteLine("Book added successfully");   
        }

        //********************************** Remove Book Function ***********************************

        public void RemoveBook(int id)
        {
            foreach(Book book in Books)
            {
                if(book.Id == id)
                {
                    if(book.IsAvailable)
                    {
                        Books.Remove(book);
                        Console.WriteLine("Book removed successfully");
                        return ;
                    }
                    else if (!book.IsAvailable)
                    {
                        Console.WriteLine("You can not remove this book because it is borrowed ");
                        return ;
                    }
                }
            }
            Console.WriteLine("This book is not exist");

        }

        //********************************** Borrow Book Function ***********************************

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
            Console.WriteLine($"{member.Name} borrowed '{book.Title}'");
        }

        //********************************** Return Book Function ***********************************

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
                Console.WriteLine("Member added successfully");
            }
            else
            {
                Console.WriteLine("can't add null");
            }
        }
        public void RemoveMember(int memberId)
        {
            foreach (Member m in Members)
            {
                if (m.Id == memberId)
                {
                    if (m.BorrowedBooks.Count > 0)
                    {
                        Console.WriteLine("Member cannot be removed because they have borrowed books.");
                        Console.WriteLine("Please return the borrowed books before removing the member.");
                        m.DisplayBorrowedBooks();
                        return;
                    }
                    Members.Remove(m);
                    Console.WriteLine("Member removed successfuly");
                    return;
                }
            }  
            Console.WriteLine("member is not found");
        }
    }
}
