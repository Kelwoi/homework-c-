using System;
using Bookstore.DAL;

class Program
{
    static void Main(string[] args)
    {
        using var context = new BookstoreContext();
        var bookRepo = new BookRepository(context);

        while (true)
        {
            Console.WriteLine("\n--- Bookstore ---");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Remove a book");
            Console.WriteLine("3. Search for a book by title");
            Console.WriteLine("4. Edit a book");
            Console.WriteLine("5. Sell a book");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";
            switch (choice)
            {
                case "1":
                    AddBook(bookRepo);
                    break;
                case "2":
                    RemoveBook(bookRepo);
                    break;
                case "3":
                    SearchBook(bookRepo);
                    break;
                case "4":
                    EditBook(bookRepo);
                    break;
                case "5":
                    SellBook(bookRepo);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    static void AddBook(BookRepository bookRepo)
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine() ?? "";
        Console.Write("Enter author: ");
        string author = Console.ReadLine() ?? "";
        Console.Write("Enter price: ");
        decimal price = decimal.Parse(Console.ReadLine() ?? "0");

        var book = new Book { Title = title, Author = author, SellingPrice = price };
        bookRepo.AddBook(book);
        Console.WriteLine("Book added successfully!");
    }

    static void RemoveBook(BookRepository bookRepo)
    {
        Console.Write("Enter book ID to remove: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            bookRepo.RemoveBook(id);
            Console.WriteLine("Book removed successfully!");
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    static void SearchBook(BookRepository bookRepo)
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine() ?? "";
        var books = bookRepo.GetBooksByTitle(title);

        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Price: {book.SellingPrice}");
        }
    }

    static void EditBook(BookRepository bookRepo)
    {
        Console.Write("Enter book ID to edit: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var book = bookRepo.GetBookById(id);
            if (book != null)
            {
                Console.Write("Enter new title (leave blank to keep current): ");
                string newTitle = Console.ReadLine() ?? "";
                Console.Write("Enter new author (leave blank to keep current): ");
                string newAuthor = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(newTitle)) book.Title = newTitle;
                if (!string.IsNullOrWhiteSpace(newAuthor)) book.Author = newAuthor;

                bookRepo.UpdateBook(book);
                Console.WriteLine("Book updated successfully!");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    static void SellBook(BookRepository bookRepo)
    {
        Console.Write("Enter book ID to sell: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var book = bookRepo.GetBookById(id);
            if (book != null)
            {
                bookRepo.RemoveBook(id);
                Console.WriteLine($"Book '{book.Title}' sold successfully!");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }
}
