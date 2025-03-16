using System.Data.SqlClient;
using System.Text;
using System.Xml.Linq;

internal class Program
{
    static void GetDepartment(SqlConnection connection, string name)
    {
        connection.Open();
        string cmdText = $"select* from Departments where name = '{name}'";
        SqlCommand command = new SqlCommand(cmdText, connection);
        SqlDataReader reader = command.ExecuteReader();

        Console.OutputEncoding = Encoding.UTF8;

        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (i == 0)
                Console.Write($"{reader.GetName(i),-10}");
            else
                Console.Write($"{reader.GetName(i),-30}");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 120));

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (i == 0)
                    Console.Write($"{reader[i],-10}");
                else
                    Console.Write($"{reader[i],-30}");
            }
            Console.WriteLine();
        }

        connection.Close();
    }
    static void GetSurvey(SqlConnection connection)
    {
        connection.Open();
        string cmdText = $"select* from Survey";
        SqlCommand command = new SqlCommand(cmdText, connection);
        SqlDataReader reader = command.ExecuteReader();

        Console.OutputEncoding = Encoding.UTF8;

        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (i == 0)
                Console.Write($"{reader.GetName(i),-10}");
            else
                Console.Write($"{reader.GetName(i),-30}");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 120));

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (i == 0)
                    Console.Write($"{reader[i],-10}");
                else
                    Console.Write($"{reader[i],-30}");
            }
            Console.WriteLine();
        }

        connection.Close();
    }
    static void DeleteSurveyByDate(SqlConnection connection, DateTime date)
    {
        connection.Open();
        string formattedDate = date.ToString("yyyy-MM-dd HH:mm:ss");
        string cmdText = $"delete from Survey where Survey_date = '{formattedDate}'";
        SqlCommand command = new SqlCommand(cmdText, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }
    static void GetDoctors(SqlConnection connection, int count)
    {
        connection.Open();
        string cmdText = $"select* from Doctors where salary > {count}";
        SqlCommand command = new SqlCommand(cmdText, connection);
        SqlDataReader reader = command.ExecuteReader();

        Console.OutputEncoding = Encoding.UTF8;

        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (i == 0)
                Console.Write($"{reader.GetName(i),-10}");
            else
                Console.Write($"{reader.GetName(i),-30}");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 120));

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (i == 0)
                    Console.Write($"{reader[i],-10}");
                else
                    Console.Write($"{reader[i],-30}");
            }
            Console.WriteLine();
        }

        connection.Close();
    }
    static void GetMaxDonate(SqlConnection connection)
    {
        connection.Open();
        string cmdText = "select top 1 * from Donations order by Amount desc";
        SqlCommand command = new SqlCommand(cmdText, connection);
        SqlDataReader reader = command.ExecuteReader();

        Console.OutputEncoding = Encoding.UTF8;

        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (i == 0)
                Console.Write($"{reader.GetName(i),-10}");
            else
                Console.Write($"{reader.GetName(i),-30}");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 120));

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (i == 0)
                    Console.Write($"{reader[i],-10}");
                else
                    Console.Write($"{reader[i],-30}");
            }
            Console.WriteLine();
        }

        connection.Close();
    }
    static void AddNewSurvey(SqlConnection connection, string name, DateTime date) 
    {
        connection.Open();
        string formattedDate = date.ToString("yyyy-MM-dd HH:mm:ss");
        string cmdText = @$"insert into Survey(name, Survey_date) 
                        values('{name}', '{formattedDate}')"; 

        SqlCommand command = new SqlCommand(cmdText, connection);
        command.ExecuteNonQuery();
        connection.Close();

    }
    static void DeleteSponsor(SqlConnection connection) 
    {
        connection.Open();
        string cmdText = @"delete from Sponsors 
                            where SponsorID not in (select distinct SponsorID from Donations)";
        SqlCommand command = new SqlCommand(cmdText, connection);
        command.ExecuteNonQuery();
        connection.Close();

    }
    private static void Main(string[] args)
    {
        string conn = @"Data Source = (localdb)\MSSQLLocalDB; 
                                        Initial Catalog = Hospital; 
                                        Integrated Security=True;
                                        Connect Timeout = 2";
        
        SqlConnection connection = new SqlConnection(conn);
        while (true) 
        {
            Console.WriteLine($"Console app Hospital\nmenu:\n1.get count of free spaces in department by name of it\n2.get all Surveys\n3.delete Surveys\n4.get all doctors which's salaries more than entered number\n5.get the biggest donation\n6.add new Survey\n7.delete sponsor\n8.Exit");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("Enter department name: ");
                string name = Console.ReadLine();
                GetDepartment(connection,name);
            }
            else if (choice == "2")
            {
                GetSurvey(connection);
            }
            else if (choice == "3") 
            {
                Console.WriteLine("Enter Date: ");
                string cons = Console.ReadLine();
                DateTime date = DateTime.Parse(cons);
                DeleteSurveyByDate(connection, date);
            }
            else if(choice == "4")
            {
                Console.WriteLine("Enter salary count");
                int count = Convert.ToInt32(Console.ReadLine());
                GetDoctors(connection, count);
            }
            else if (choice == "5") {
            GetMaxDonate(connection);
            }
            else if (choice == "6") 
            {
                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Date: ");
                string cons = Console.ReadLine();
                DateTime date = DateTime.Parse(cons);
                AddNewSurvey(connection, name, date);
            }
            else if(choice == "7")
            {
                DeleteSponsor(connection);
            }
            else if(choice == "8")
            {
                break;
            }
        }



    }
}