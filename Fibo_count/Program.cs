using Fibo_count;
using System.Diagnostics.Metrics;
internal class Program
{
    private static void Main(string[] args)
    {
        var counter = new FibonacciCounter();

        Thread thread1 = new Thread(() => Run(counter, "Thread-1"));
        Thread thread2 = new Thread(() => Run(counter, "Thread-2"));
        Thread thread3 = new Thread(() => Run(counter, "Thread-3"));

        Console.WriteLine("press enter button to start...");
        Console.ReadLine();

        thread1.Start();
        thread2.Start();
        thread3.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.WriteLine("Ready!");
    }
    static void Run(FibonacciCounter counter, string name)
    {
        for (int i = 0; i < 10; i++)
        {
            counter.CalculateNext(name);
            Thread.Sleep(50);
        }
    }
    
}