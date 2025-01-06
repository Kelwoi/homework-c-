
internal class Program
{
    
    public static int[] CreateArr(int size)
    {
        return new int[size];
    }

    
    public static void FillRandArr(int[] arr, int left = 0, int right = 100)
    {
        Random rand = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rand.Next(left, right + 1);
        }
    }

    
    public static void PrintArr(int[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }

    
    public static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    
    public static void SwapPairs(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i += 2)
        {
            Swap(ref arr[i], ref arr[i + 1]);
        }
    }

    
    public static int GetFirstPositive(int[] arr)
    {
        return Array.Find(arr, x => x > 0) is int result ? result : 0;
    }

    
    public static int CountEven(int[] arr)
    {
        return arr.Count(x => x % 2 == 0);
    }

    
    public static int multiple7(int[] arr)
    {
        return Array.FindIndex(arr, x => x % 7 == 0);
    }


    private static void Main(string[] args)
    {
        
        Console.WriteLine("enter size of array:");
        int size = int.Parse(Console.ReadLine());
        int[] arr = CreateArr(size);


        FillRandArr(arr, -50, 50);
        Console.WriteLine("after fiilin:");
        PrintArr(arr);


        SwapPairs(arr);
        Console.WriteLine("after change:");
        PrintArr(arr);

        
        int firstPositive = GetFirstPositive(arr);
        Console.WriteLine($"first positive: {firstPositive}");

       
        int evenCount = CountEven(arr);
        Console.WriteLine($"even: {evenCount}");

        
        int indexMultipleOf7 = multiple7(arr);
        if (indexMultipleOf7 != -1)
        {
            Console.WriteLine($"index: {indexMultipleOf7}");
        }
        else
        {
            Console.WriteLine("there is no elements multiple of 7");
        }
    }
}
