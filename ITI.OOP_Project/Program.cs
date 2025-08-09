using System;
using System.Collections.Generic;

namespace ITI.OOP_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

       
            library.Books.AddRange(new List<Book>
            {
                new Book(1, "The Great Gatsby", "F. Scott Fitzgerald") { IsAvailable = true },
                new Book(2, "1984", "George Orwell") { IsAvailable = true },
                new Book(3, "To Kill a Mockingbird", "Harper Lee") { IsAvailable = true },
                new Book(4, "Pride and Prejudice", "Jane Austen") { IsAvailable = true },
                new Book(5, "The Catcher in the Rye", "J.D. Salinger") { IsAvailable = true },
                new Book(6, "Moby-Dick", "Herman Melville") { IsAvailable = true },
                new Book(7, "War and Peace", "Leo Tolstoy") { IsAvailable = true },
                new Book(8, "The Odyssey", "Homer") { IsAvailable = true },
                new Book(9, "Crime and Punishment", "Fyodor Dostoevsky") { IsAvailable = true },
                new Book(10, "The Hobbit", "J.R.R. Tolkien") { IsAvailable = true }
            });

          
            library.Members.AddRange(new List<Member>
            {
                new Member(1, "Alice Smith"),
                new Member(2, "Bob Johnson"),
                new Member(3, "Charlie Brown"),
                new Member(4, "Diana Prince"),
                new Member(5, "Ethan Hunt"),
                new Member(6, "Fiona Gallagher"),
                new Member(7, "George Martin"),
                new Member(8, "Hannah Williams"),
                new Member(9, "Ian McKellen"),
                new Member(10, "Julia Roberts")
            });

            bool keepRunning = true;

            do
            {
                Console.WriteLine("\n===== Library Management System =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Add Member");
                Console.WriteLine("4. Remove Member");
                Console.WriteLine("5. Borrow Book");
                Console.WriteLine("6. Return Book");
                Console.WriteLine("7. Show Available Books");
                Console.WriteLine("8. Show Borrowed Books");
                Console.WriteLine("9. Exit");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write(" Invalid input! Please enter a valid number: ");
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Book ID: ");
                        int bookId;
                        while (!int.TryParse(Console.ReadLine(), out bookId))
                        {
                            Console.Write("Invalid ID! Please enter a number: ");
                        }
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                        library.AddBook(bookId, title, author);
                        break;

                    case 2:
                        Console.Write("Enter Book ID to remove: ");
                        int removeBookId;
                        while (!int.TryParse(Console.ReadLine(), out removeBookId))
                        {
                            Console.Write("Invalid ID! Please enter a number: ");
                        }
                        library.RemoveBook(removeBookId);
                        break;

                    case 3:
                        Console.Write("Enter Member ID: ");
                        int memberId;
                        while (!int.TryParse(Console.ReadLine(), out memberId))
                        {
                            Console.Write("Invalid ID! Please enter a number: ");
                        }
                        Console.Write("Enter Member Name: ");
                        string name = Console.ReadLine();
                        library.AddMember(new Member(memberId, name));
                        break;

                    case 4:
                        Console.Write("Enter Member ID to remove: ");
                        int removeMemberId;
                        while (!int.TryParse(Console.ReadLine(), out removeMemberId))
                        {
                            Console.Write("Invalid ID! Please enter a number: ");
                        }
                        library.removeMember(removeMemberId);
                        break;

                    case 5:
                        Console.Write("Enter Book ID to borrow: ");
                        int borrowBookId;
                        while (!int.TryParse(Console.ReadLine(), out borrowBookId))
                        {
                            Console.Write("Invalid ID! Please enter a number: ");
                        }
                        Console.Write("Enter Member ID: ");
                        int borrowMemberId;
                        while (!int.TryParse(Console.ReadLine(), out borrowMemberId))
                        {
                            Console.Write("Invalid ID! Please enter a number: ");
                        }
                        library.BorrowBook(borrowBookId, borrowMemberId);
                        break;

                    case 6:
                        Console.Write("Enter Book ID to return: ");
                        int returnBookId;
                        while (!int.TryParse(Console.ReadLine(), out returnBookId))
                        {
                            Console.Write("Invalid ID! Please enter a number: ");
                        }
                        Console.Write("Enter Member ID: ");
                        int returnMemberId;
                        while (!int.TryParse(Console.ReadLine(), out returnMemberId))
                        {
                            Console.Write("Invalid ID! Please enter a number: ");
                        }
                        library.ReturnBook(returnBookId, returnMemberId);
                        break;

                    case 7:
                        library.ShowAvailableBooks();
                        break;

                    case 8:
                        library.ShowBorrowedBooks();
                        break;

                    case 9:
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                if (keepRunning)
                {
                    Console.Write("\nDo you want to continue? (y/n): ");
                    string cont = Console.ReadLine().ToLower();
                    if (cont != "y")
                    {
                        keepRunning = false;
                        Console.WriteLine("Exiting the program...");
                    }
                }

            } while (keepRunning);
        }
    }
}

