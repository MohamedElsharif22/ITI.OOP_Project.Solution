using System.ComponentModel.Design.Serialization;

namespace ITI.OOP_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.Books.AddRange(new List<Book>
            {
                new Book(1, "OOP", "Ahmed Refaat"),
                new Book(2, "c#", "Mohamed Kamal"),
                new Book(3, "Sql", "Walid Ayman"),
                new Book(4, "Html", "Mohamed Ghazaly"),
                new Book(5, "css", "Mohamed Shaban"),
                new Book(6, "javaScript", "Refaat"),
                new Book(7, "BootStrip", "Kamal"),
                new Book(8, "React", "Ghazaly"),
                new Book(9, "Angler", "Ayman"),
                new Book(10, "Github", "J.R.R. Tolkien")
            });

            library.Members.AddRange(new List<Member>
            {
                new Member(1, "Ahmed refaat"),
                new Member(2, "Mohamed Kamal"),
                new Member(3, "Walid Ayman"),
                new Member(4, "Mohamed Ghazaly"),
                new Member(5, "Mohamed Shaban"),
                new Member(6, "Refaat"),
                new Member(7, "Kamal"),
                new Member(8, "Ayman"),
                new Member(9, "Ghazaly"),
                new Member(10, "Shaban")
            });

            bool keepRunning = true;

            do
            {
                int choice = ShowMenuAndGetChoice();

                switch (choice)
                {
                    case 0:
                        Console.Write("Enter Book ID: ");
                        int bookId;
                        while (!int.TryParse(Console.ReadLine(), out bookId))
                        {
                            Console.Write("Invalid ID => Please enter a number: ");
                        }
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(title))
                        {
                            Console.Write("Invalid Title => Please enter a valid title: ");
                            title = Console.ReadLine();
                        }
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(author))
                        {
                            Console.Write("Invalid Author => Please enter a valid author: ");
                            author = Console.ReadLine();
                        }
                        library.AddBook(bookId, title, author);
                        break;

                    case 1:
                        Console.Write("Enter Book ID to remove: ");
                        int removeBookId;
                        while (!int.TryParse(Console.ReadLine(), out removeBookId))
                        {
                            Console.Write("Invalid ID => Please enter a number: ");
                        }
                        library.RemoveBook(removeBookId);
                        break;

                    case 2:
                        Console.Write("Enter Member ID: ");
                        int memberId;
                        while (!int.TryParse(Console.ReadLine(), out memberId) || memberId <= 0)
                        {
                            Console.Write("Invalid ID => Please enter a number: ");
                        }
                        Console.Write("Enter Member Name: ");
                        string name = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(name))
                        {
                            Console.Write("Invalid Name => Please enter a valid name: ");
                            name = Console.ReadLine();
                        }
                        library.AddMember(new Member(memberId, name));
                        break;

                    case 3:
                        Console.Write("Enter Member ID to remove: ");
                        int removeMemberId;
                        while (!int.TryParse(Console.ReadLine(), out removeMemberId))
                        {
                            Console.Write("Invalid ID => Please enter a number: ");
                        }
                        library.RemoveMember(removeMemberId);
                        break;

                    case 4:
                        Console.Write("Enter Book ID to borrow: ");
                        int borrowBookId;
                        while (!int.TryParse(Console.ReadLine(), out borrowBookId))
                        {
                            Console.Write("Invalid ID => Please enter a number: ");
                        }
                        Console.Write("Enter Member ID: ");
                        int borrowMemberId;
                        while (!int.TryParse(Console.ReadLine(), out borrowMemberId))
                        {
                            Console.Write("Invalid ID => Please enter a number: ");
                        }
                        library.BorrowBook(borrowBookId, borrowMemberId);
                        break;

                    case 5:
                        Console.Write("Enter Book ID to return: ");
                        int returnBookId;
                        while (!int.TryParse(Console.ReadLine(), out returnBookId))
                        {
                            Console.Write("Invalid ID => Please enter a number: ");
                        }
                        Console.Write("Enter Member ID: ");
                        int returnMemberId;
                        while (!int.TryParse(Console.ReadLine(), out returnMemberId))
                        {
                            Console.Write("Invalid ID => Please enter a number: ");
                        }
                        library.ReturnBook(returnBookId, returnMemberId);
                        break;

                    case 6:
                        library.ShowAvailableBooks();
                        break;

                    case 7:
                        library.ShowBorrowedBooks();
                        break;

                    case 8:
                        library.ShowMembers();
                        break;

                    case 9:
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                }

                if (keepRunning)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

            } while (keepRunning);
        }

        static int ShowMenuAndGetChoice()
        {
            string[] menuOptions = 
            {
                "Add Book",
                "Remove Book",
                "Add Member",
                "Remove Member",
                "Borrow Book",
                "Return Book",
                "Show Available Books",
                "Show Borrowed Books",
                "Show Members",
                "Exit"
            };

            int selectedIndex = 0;
            ConsoleKey keyPressed;

            do
            {
                Console.Clear();
                Console.WriteLine("===== Library Management System =====");
                Console.WriteLine("Use ↑↓ arrow keys to navigate and Enter to select:\n");

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine($"> {menuOptions[i]} <");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {menuOptions[i]}");
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex == 0) ? menuOptions.Length - 1 : selectedIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex == menuOptions.Length - 1) ? 0 : selectedIndex + 1;
                        break;
                }

            } while (keyPressed != ConsoleKey.Enter);

            Console.Clear();
            return selectedIndex;
        }
    }
}
