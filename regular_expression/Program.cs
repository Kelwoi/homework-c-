using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        // 1
        List<int> fourDigitNumbers = GetFourDigitNumbers("1234 5678 9999 10000 1001 4567");
        Console.WriteLine("task 1- 4 count numbers:");
        foreach (var num in fourDigitNumbers)
        {
            Console.WriteLine(num);
        }

        // 2

        string[] words = { "asd123zxc456", "bnm567hjk890", "abc123def456", "a1b2c3" };
        string wordPattern = @"^[a-zA-Z]{3}\d{3}[a-zA-Z]{3}\d{3}$";
        foreach (var word in words)
        {
            if (Regex.IsMatch(word, wordPattern))
            {
                Console.WriteLine($"word '{word}' good.");
            }
        }

        // 3

        string text = "Some text WWW and PDF, and also the RTF RTC, but not R and BMP.";
        string abbreviationPattern = @"\b[A-Z]{3}\b";
        var abbreviations = Regex.Matches(text, abbreviationPattern);
        foreach (Match match in abbreviations)
        {
            Console.WriteLine($"Зfound match: {match.Value}");
        }

        // 4

        string yearsText = "1999 2050 1899 2100";
        string yearPattern = @"^(19|20)\d{2}$";
        var yearsMatches = Regex.Matches(yearsText, yearPattern);
        foreach (Match match in yearsMatches)
        {
            Console.WriteLine($"year: {match.Value}");
        }

        // 5

        string phonebook = "+38-095-1234567 +38-063-2345678 +38-097-8000234 +38-097-2345000";

        // 6
        string phonePattern1 = @"\+38-0\d{2}-\d{4}23$";
        var phoneMatches1 = Regex.Matches(phonebook, phonePattern1);
        foreach (Match match in phoneMatches1)
        {
            Console.WriteLine($"number with last 23: {match.Value}");
        }

        // 7
        string phonePattern2 = @"\+38-0\d{2}-\d*00\d*\d$";
        var phoneMatches2 = Regex.Matches(phonebook, phonePattern2);
        foreach (Match match in phoneMatches2)
        {
            Console.WriteLine($"phone with 00: {match.Value}");
        }
    }

    // 8
    static List<int> GetFourDigitNumbers(string input)
    {
        List<int> fourDigitNumbers = new List<int>();
        var matches = Regex.Matches(input, @"\b\d{4}\b");
        foreach (Match match in matches)
        {
            fourDigitNumbers.Add(int.Parse(match.Value));
        }
        return fourDigitNumbers;
    }
}
