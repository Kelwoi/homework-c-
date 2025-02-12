
using Generic_Book;

namespace Generic_Book;
internal class Program
{
    private static void Main(string[] args)
    {
        List<Book> books = new List<Book>();



        while (true)
        {
            Console.WriteLine("\nChoose:");
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. Delete book");
            Console.WriteLine("3. Change information about book");
            Console.WriteLine("4. Search book");
            Console.WriteLine("5. add book in position at start");
            Console.WriteLine("6. add book in position at end");
            Console.WriteLine("7. add book at custom position");
            Console.WriteLine("8. delete book from start");
            Console.WriteLine("9. delete book from end");
            Console.WriteLine("10. delete book from custom position");
            Console.WriteLine("11. show all books");
            Console.WriteLine("0. exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddBook(books); break;
                case "2": RemoveBook(books); break;
                case "3": EditBook(books); break;
                case "4": SearchBooks(books); break;
                case "5": InsertAtStart(books); break;
                case "6": InsertAtEnd(books); break;
                case "7": InsertAtPosition(books); break;
                case "8": RemoveFromStart(books); break;
                case "9": RemoveFromEnd(books); break;
                case "10": RemoveFromPosition(books); break;
                case "11": DisplayBooks(books); break;
                case "0": return;
                default: Console.WriteLine("Wrong choice!"); break;
            }

            static void AddBook(List<Book> books)
            {
                Console.Write("Name: ");
                string title = Console.ReadLine();
                Console.Write("Author: ");
                string author = Console.ReadLine();
                Console.Write("Genre: ");
                string genre = Console.ReadLine();
                Console.Write("Year of making: ");
                int year = int.Parse(Console.ReadLine());

                books.Add(new Book(title, author, genre, year));
                Console.WriteLine("Book added!");
            }

            static void RemoveBook(List<Book> books)
            {
                Console.Write("Enter book's name for removing: ");
                string title = Console.ReadLine();
                books.RemoveAll(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("Book deleted!");
            }

            static void EditBook(List<Book> books)
            {
                Console.Write("Enter book's name for editing: ");
                string title = Console.ReadLine();
                var book = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                if (book != null)
                {
                    Console.Write("New name: "); book.Title = Console.ReadLine();
                    Console.Write("New author: "); book.Author = Console.ReadLine();
                    Console.Write("New genre: "); book.Genre = Console.ReadLine();
                    Console.Write("New year of publishing: "); book.Year = int.Parse(Console.ReadLine());
                    Console.WriteLine("Book updated!");
                }
                else
                {
                    Console.WriteLine("ERROR can't find book!");
                }
            }

            static void SearchBooks(List<Book> books)
            {
                Console.Write("Enter parameter for searching: ");
                string query = Console.ReadLine();
                var results = books.Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                               b.Author.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                               b.Genre.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
                foreach (var book in results) Console.WriteLine(book);
            }

            static Book CreateBook()
            {
                Console.Write("Name: "); string title = Console.ReadLine();
                Console.Write("Auhtor: "); string author = Console.ReadLine();
                Console.Write("Genre: "); string genre = Console.ReadLine();
                Console.Write("Year of creating: "); int year = int.Parse(Console.ReadLine());
                return new Book(title, author, genre, year);
            }

            static void InsertAtStart(List<Book> books)
            {
                books.Insert(0, CreateBook());
                Console.WriteLine("Book added on start!");
            }

            static void InsertAtEnd(List<Book> books)
            {
                books.Add(CreateBook());
                Console.WriteLine("Book added on end!");
            }

            static void InsertAtPosition(List<Book> books)
            {
                Console.Write("Enter position: ");
                int pos = int.Parse(Console.ReadLine());
                if (pos >= 0 && pos <= books.Count)
                {
                    books.Insert(pos, CreateBook());
                    Console.WriteLine("Book added on the position!");
                }
                else
                {
                    Console.WriteLine("Error wrong position!");
                }
            }

            static void RemoveFromStart(List<Book> books)
            {
                if (books.Count > 0) books.RemoveAt(0);
                Console.WriteLine("Book deleted from start!");
            }
            static void RemoveFromEnd(List<Book> books)
            {
                if (books.Count > 0) books.RemoveAt(books.Count - 1);
                Console.WriteLine("Book deleted from end!");
            }

            static void RemoveFromPosition(List<Book> books)
            {
                Console.Write("Enter position: ");
                int pos = int.Parse(Console.ReadLine());
                if (pos >= 0 && pos < books.Count)
                {
                    books.RemoveAt(pos);
                    Console.WriteLine("Book deleted from position!");
                }
                else
                {
                    Console.WriteLine("Wrong position!");
                }
            }

            static void DisplayBooks(List<Book> books)
            {
                foreach (var book in books) Console.WriteLine(book);
            }

        }
    }
}