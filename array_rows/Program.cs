internal class Program
{
    static void Task1()
    {
        int[] a = new int[5];
        int[,] b = new int[3,4];
        int Max_a = int.MinValue;
        int Max_b = int.MinValue;
        int Min_b = int.MaxValue;
        int Min_a = int.MaxValue;
        int sum_a = 0, sum_b = 0;
        int even_a = 0, even_b = 0;
        for (int i = 0; i < a.Length; i++) 
        {
            Console.WriteLine($"enter five numbers in array. number {i + 1}:");
            a[i] = int.Parse(Console.ReadLine());
            sum_a += a[i];
            if(i % 2 == 0)
            {
                even_a += a[i];
            }
            if( a[i] > Max_a)
            {
                Max_a = a[i];
            }
            if( a[i] < Min_a)
            {
                Min_a = a[i];
            }
        }
        Console.WriteLine("A:");
        for(int i = 0; i<a.Length; i++)
        {
            Console.WriteLine(a[i]);
        }
        Console.WriteLine($"A min:{Min_a}\nA max:{Max_a}\nA sum:{sum_a}\nA even sum{even_a}\n");
        Console.WriteLine("B:");
        Random rand = new Random();
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 4; j++)
            {
                b[i, j] = Convert.ToInt32(rand.NextDouble() * 100);
                sum_b += b[i, j];
                if(i % 2 != 0)
                {
                    even_b += b[i, j];
                }
                if (b[i,j] > Max_b)
                {
                    Max_b = b[i,j];
                }
                if (b[i,j] < Min_b)
                {
                    Min_b = b[i,j];
                }
            }


        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < 4; j++)
                Console.Write($"{b[i,j]} ");
        }
        Console.WriteLine($"B min:{Min_b}\nB max:{Max_b}\nB sum:{sum_b}\nB odd sum{even_b}\n");
        Console.WriteLine();



    }

    static void Task2()
    {
        int[,] matrix = new int[5, 5];
        Random rand = new Random();
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
                matrix[i, j] = rand.Next(-100, 101);

        int min = int.MaxValue, max = int.MinValue, sum = 0;
        foreach (var num in matrix)
        {
            if (num < min) min = num;
            if (num > max) max = num;
        }

        foreach (var num in matrix)
        {
            if (num > min && num < max)
                sum += num;
        }
        Console.WriteLine($"Sum between min and max: {sum}");
    }

    static void Task3()
    {
        Console.Write("Enter text to encrypt: ");
        string text = Console.ReadLine();
        Console.Write("Enter shift: ");
        int shift = int.Parse(Console.ReadLine());
        string encrypted = CaesarCipher(text, shift);
        string decrypted = CaesarCipher(encrypted, -shift);
        Console.WriteLine($"Encrypted: {encrypted}\nDecrypted: {decrypted}");
    }

    static string CaesarCipher(string text, int shift)
    {
        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];
            if (char.IsLetter(letter))
            {
                char baseChar = char.IsUpper(letter) ? 'A' : 'a';
                buffer[i] = (char)(baseChar + (letter - baseChar + shift + 26) % 26);
            }
        }
        return new string(buffer);
    }

    static void Task4()
    {
        int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
        int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
        int[,] resultAdd = AddMatrices(matrix1, matrix2);
        int[,] resultMul = MultiplyMatrices(matrix1, matrix2);

        Console.WriteLine("Matrix Addition:");
        PrintMatrix(resultAdd);

        Console.WriteLine("Matrix Multiplication:");
        PrintMatrix(resultMul);
    }

    static int[,] AddMatrices(int[,] a, int[,] b)
    {
        int rows = a.GetLength(0), cols = a.GetLength(1);
        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = a[i, j] + b[i, j];
        return result;
    }

    static int[,] MultiplyMatrices(int[,] a, int[,] b)
    {
        int rows = a.GetLength(0), cols = b.GetLength(1);
        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                for (int k = 0; k < a.GetLength(1); k++)
                    result[i, j] += a[i, k] * b[k, j];
        return result;
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }
    private static void Main(string[] args)
    {
        Task1();
        Task2();
        Task3();
        Task4();
    }

}