using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.Xml.Linq;
public class  Book
{
    
    public string name { get; set; }
    public int authorId { get; set; }
    public int userId { get; set; }
}
internal class Program
{

    private static void Main(string[] args)
    {
        string conn = ConfigurationManager.ConnectionStrings["library"].ConnectionString;
        SqlConnection connection = new SqlConnection(conn);
        static void addbook(SqlConnection connection, Book book) 
        {
            connection.Open();
            if (book.userId == 0) 
            {
                string cmdText = @"insert into book(name,authorId) values(@name,@authorId)";
                SqlCommand command = new SqlCommand(cmdText, connection);
                command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = book.name;
                command.Parameters.Add("@authorId", System.Data.SqlDbType.Int).Value = book.authorId;

                command.ExecuteNonQuery();
            }
            else 
            {
                string cmdText = @"insert into book values(@name,@authorId,@userId)";
                SqlCommand command = new SqlCommand(cmdText, connection);
                command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = book.name;
                command.Parameters.Add("@authorId", System.Data.SqlDbType.Int).Value = book.authorId;
                command.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = book.userId;
                command.ExecuteNonQuery();
            }
            connection.Close();


        }
        static void registered_users(SqlConnection connection)
        {
            connection.Open();
            string cmdText = $@"select count(id) from library_user";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
            var reader = command.ExecuteReader();
            showRegisteredUsers(reader);
            connection.Close();



        }
        static void showRegisteredUsers(SqlDataReader reader)
        {
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"count of registered users: {reader[i]}");
                }
                Console.WriteLine();
               
            }
        }
        static void showDebtor(SqlConnection connection) 
        {
            connection.Open();
            string cmdText = $@"select * from library_user where IsDebtor = 1";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
            var reader = command.ExecuteReader() ;
            ShowReaderData(reader);
            connection.Close() ;

        }
        static void showBooks(SqlConnection connection)
        {
            connection.Open();
            string cmdText = $@"select id,name from book";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
            var reader = command.ExecuteReader();
            ShowReaderData(reader);
            connection.Close();

        }
        static void showUser(SqlConnection connection) 
        {
            connection.Open();
            string cmdText = $@"select id,name from library_user where IsDebtor = 1";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
            var reader = command.ExecuteReader();
            ShowReaderData(reader);
            connection.Close();
        }
        static void showBorrowedBooks(SqlConnection connection, int userId)
        {
            connection.Open();
            string cmdText = $@"SELECT b.Name FROM book b JOIN library_user a ON b.AuthorID = a.ID WHERE b.userId = @userId";

            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("@userId", userId);
            command.ExecuteNonQuery();
            var reader = command.ExecuteReader();
            ShowReaderData(reader);
            connection.Close();

        }
        static void showBookAuthor(SqlConnection connection, int bookId)
        {
            connection.Open();
            string cmdText = $@"SELECT a.Name, a.surname FROM book b JOIN Author a ON b.AuthorID = a.ID WHERE b.ID = @BookID";

            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("@BookID", bookId);
            command.ExecuteNonQuery();
            var reader = command.ExecuteReader();
            ShowReaderData(reader);
            connection.Close();

        }
        static void ShowReaderData(SqlDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; i++) 
            {
                Console.Write($"{reader.GetName(i),16}");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 120));

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i],16}");
                }
                Console.WriteLine();
            }
        }
        static void showAvailableBooks(SqlConnection connection)
        {
            connection.Open();
            string cmdText = $@"select * from book where userId is null";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
            var reader = command.ExecuteReader();
            ShowReaderData(reader);
            connection.Close();
        }

        static void clean_debtors(SqlConnection connection) 
        {
            connection.Open();
            string cmdText = $@"UPDATE book  SET UserID = NULL WHERE UserID IN (SELECT ID FROM library_user WHERE IsDebtor = 1)";
            SqlCommand command1 = new SqlCommand(cmdText, connection);
            command1.ExecuteNonQuery();
            string clearDebtorsQuery = "UPDATE library_user SET IsDebtor = 0 WHERE IsDebtor = 1";
            SqlCommand command2 = new SqlCommand(clearDebtorsQuery, connection);
            command2.ExecuteNonQuery();
            connection.Close();
        }

        while (true)
        {
            Console.WriteLine($"Console app library\nmenu:\n1.add book\n2.show count of registered users\n3.show debtors\n4.show book's author\n5.show book\n6.show books whic is currently borrowed by users\n7.clean debtors\n8.Exit");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                addbook(connection, new Book() { name = "monstry", userId = 2, authorId = 1 });
            }
            else if (choice == "2")
            {
                registered_users(connection);
            }
            else if (choice == "3")
            {
                showDebtor(connection);
            }
            else if (choice == "4")
            {
                showBooks(connection);
                Console.WriteLine("Choose book id to see it's author");
                int bookId = int.Parse(Console.ReadLine());
                showBookAuthor(connection, bookId);
            }
            else if (choice == "5")
            {
                showAvailableBooks(connection);
            }
            else if (choice == "6") 
            {
                showUser(connection);
                Console.WriteLine("Choose user id to see his borrowed books");
                int userId = int.Parse(Console.ReadLine()); 
                showBorrowedBooks(connection,userId);
            }
            else if(choice == "7") 
            {
                clean_debtors(connection);
            }


        }
    }
}