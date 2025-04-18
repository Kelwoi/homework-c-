using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

class Program
{
    private static void Main(string[] args)
    {
        string filePath = "numbers.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("can't find file.");
            return;
        }

        var numbers = File.ReadAllLines(filePath)
                          .Select(line => int.TryParse(line, out var num) ? (int?)num : null)
                          .Where(n => n.HasValue)
                          .Select(n => n.Value)
                          .ToList();


        Console.WriteLine("Factorial:");
        var factorials = new Dictionary<int, BigInteger>();

        Parallel.ForEach(numbers, number =>
        {
            BigInteger fact = 1;
            for (int i = 2; i <= number; i++)
                fact *= i;

            lock (factorials)
            {
                factorials[number] = fact;
            }
        });

        foreach (var kvp in factorials.OrderBy(k => k.Key))
        {
            Console.WriteLine($"{kvp.Key}! = {kvp.Value}");
        }


        var parallelNumbers = numbers.AsParallel();

        int sum = parallelNumbers.Sum();
        int max = parallelNumbers.Max();
        int min = parallelNumbers.Min();

        Console.WriteLine("\nPLINQ statistic:");
        Console.WriteLine($"sum: {sum}");
        Console.WriteLine($"max: {max}");
        Console.WriteLine($"min: {min}");
    }
}
