using Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5, 3, 2, 1, 6, 7, 8, 8, 9 };
        ArrayProcessor processor = new ArrayProcessor(numbers);

        Console.WriteLine("Less than 5: " + processor.Less(5));
        Console.WriteLine("Greater than 5: " + processor.Greater(5));

        processor.ShowEven();
        processor.ShowOdd();

        Console.WriteLine("Distinct count: " + processor.CountDistinct());
        Console.WriteLine("Count of 3: " + processor.EqualToValue(3));
    }
}