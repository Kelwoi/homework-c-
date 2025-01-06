internal class Program
{
    private static void Main(string[] args)
    {
        //task 1
        Console.WriteLine("name of job:");
        string position = Console.ReadLine();

        Console.WriteLine("count of hours:");
        int hoursWorked = int.Parse(Console.ReadLine());

        double hourlyRate = 0;

        switch (position.ToLower())
        {
            case "manager":
                hourlyRate = 100;
                break;
            case "programmer":
                hourlyRate = 150;
                break;
            case "accountant":
                hourlyRate = 120;
                break;
            default:
                Console.WriteLine("error.");
                return;
        }

        double salary = hoursWorked * hourlyRate;
        Console.WriteLine($"sallary: {salary} $");
        //task 2
        Console.WriteLine("enter A:");
        int A = int.Parse(Console.ReadLine());

        Console.WriteLine("enter B:");
        int B = int.Parse(Console.ReadLine());

        if (A >= B)
        {
            Console.WriteLine("A should be less than B");
            return;
        }

        for (int i = A; i <= B; i++)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        // task 3
        int spaceCount = 0, digitCount = 0, letterCount = 0, otherCount = 0;
        Console.WriteLine("Enter symbols (enter dot, to end):");

        char input;
        do
        {
            input = (char)Console.Read();

            if (char.IsWhiteSpace(input) && input != '.')
                spaceCount++;
            else if (char.IsDigit(input))
                digitCount++;
            else if (char.IsLetter(input))
                letterCount++;
            else if (input != '.')
                otherCount++;

        } while (input != '.');

        Console.WriteLine($"\nspace count: {spaceCount}");
        Console.WriteLine($"digit count: {digitCount}");
        Console.WriteLine($"letter count: {letterCount}");
        Console.WriteLine($"other count: {otherCount}");
        //task 4
        Console.WriteLine("Enter symbols(press enter to end):");

        string input1 = Console.ReadLine();
        string result = "";

        foreach (char c in input1)
        {
            if (char.IsLower(c))
                result += char.ToUpper(c);
            else if (char.IsUpper(c))
                result += char.ToLower(c);
            else
                result += c;
        }

        Console.WriteLine($"Result: {result}");
    }
}

