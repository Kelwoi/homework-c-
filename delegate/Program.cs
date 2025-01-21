using System.Diagnostics.Metrics;


public delegate void arr_work(int[] arr);
delegate double AreaDelegate(params double[] args);
internal class Program
{
    class Array_work_with
    {
        public static void even(int[] arr)
        {
            foreach (int e in arr)
            {
                if (e % 2 == 0)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public static void odd(int[] arr)
        {
            foreach (int e in arr)
            {
                if (e % 2 != 0)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public static void simple(int[] arr)
        {

            foreach(int e in arr)
            {
                int counter = 0;
                for (int i = 1; i < e; i++)
                {
                    if(e % i == 0)
                    {
                        counter++;
                    }

                }
                if(counter < 2)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public static void Fibonacci(int[] arr)
        {
            foreach(var e in arr)
            {
                int a = 0; int b = 1;
                if (e == a || e == b)
                {
                    Console.WriteLine(e);
                    continue;
                }
                    
                    
                int c = a + b;
                while (c <= e)
                {
                    if(c == e)
                        Console.WriteLine(e);
                    a = b;
                    b = c;
                    c = a + b;
                }
            }
        }
    }
    class time_work
    {
        public static DateTime Time_update()
        {
            return DateTime.Now;
        } 
        public static  void time_now()
        {
            DateTime Time = Time_update();
            Console.WriteLine($"Time now: \n Hour: {Time.Hour} \n minutes: {Time.Minute} \n seconds: {Time.Second}");
        }
        public static void day_week()
        {
            DateTime Day = Time_update();
            Console.WriteLine($"\n ----------------------- \n Day of week is: {Day.DayOfWeek} \n -----------------------");
        }
        public static void Today_day()
        {
            DateTime Time = Time_update();
            Console.WriteLine($"Time now: \n Year: {Time.Year} \n Month: {Time.Month} \n Day: {Time.Day}");
        }
    }
    class math_oper
    {
        public static double RectangleArea(params double[] args)
        {
            if (args.Length != 4) throw new ArgumentException("for calculation of Rectangle area, need 4 params");
            return (args[2] - args[0]) * (args[3] - args[1]);
        }
        public static double TriangleArea(params double[] args)
        {
            if (args.Length != 3) throw new ArgumentException("For calculation of Triangle area, need 3 params");
            return 0.5 * args[0] * args[1] * Math.Sin(args[2]);
        }
    }
    private static void Main(string[] args)
    {
        arr_work ex = new arr_work(Array_work_with.Fibonacci);
        int[] arrar = { 1, 4, 6, 3, 7, 8, 5, 3 };
        ex(arrar);
        Action action = time_work.time_now;
        action();
        action += time_work.day_week;
        action();
        action += time_work.Today_day;
        action();
        AreaDelegate areaDelegate;

        areaDelegate = math_oper.RectangleArea;
        Console.WriteLine(areaDelegate(0, 0, 4, 3));

        areaDelegate = math_oper.TriangleArea;
        Console.WriteLine(areaDelegate(3, 4, 1));




    }
}