using Serializers;
using System.Text.Json;

internal class Program
{
    static void HandleIntegerArray()
    {
        Console.WriteLine("Enter integers separated by spaces:");
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine("Filter option:\n1. Remove prime numbers\n2. Remove Fibonacci numbers");
        string filterChoice = Console.ReadLine();

        numbers = filterChoice switch
        {
            "1" => numbers.Where(n => !IsPrime(n)).ToArray(),
            "2" => numbers.Where(n => !IsFibonacci(n)).ToArray(),
            _ => numbers
        };

        string json = JsonSerializer.Serialize(numbers);
        File.WriteAllText("numbers.json", json);
        Console.WriteLine("Filtered array saved to numbers.json");

        string loadedJson = File.ReadAllText("numbers.json");
        int[] loadedNumbers = JsonSerializer.Deserialize<int[]>(loadedJson);
        Console.WriteLine("Loaded numbers: " + string.Join(", ", loadedNumbers));
    }

    static bool IsPrime(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
            if (num % i == 0) return false;
        return true;
    }

    static bool IsFibonacci(int num)
    {
        int a = 0, b = 1;
        while (b < num)
        {
            int temp = a + b;
            a = b;
            b = temp;
        }
        return b == num || num == 0;
    }

    static void HandleAlbums()
    {
        List<Album> albums = new();
        if (File.Exists("albums.json"))
        {
            string json = File.ReadAllText("albums.json");
            albums = JsonSerializer.Deserialize<List<Album>>(json) ?? new List<Album>();
        }

        Console.WriteLine("Enter album details:");
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Artist: ");
        string artist = Console.ReadLine();
        Console.Write("Year: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Duration (minutes): ");
        double duration = double.Parse(Console.ReadLine());
        Console.Write("Record Label: ");
        string label = Console.ReadLine();

        List<Song> songs = new();
        Console.Write("Number of songs: ");
        int songCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < songCount; i++)
        {
            Console.WriteLine($"Enter details for song {i + 1}:");
            Console.Write("Title: ");
            string songTitle = Console.ReadLine();
            Console.Write("Duration (minutes): ");
            double songDuration = double.Parse(Console.ReadLine());
            Console.Write("Genre: ");
            string genre = Console.ReadLine();
            songs.Add(new Song(songTitle, songDuration, genre));
        }

        albums.Add(new Album(title, artist, year, duration, label, songs));
        string serializedAlbums = JsonSerializer.Serialize(albums, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("albums.json", serializedAlbums);
        Console.WriteLine("Albums saved to albums.json");

        Console.WriteLine("Loaded Albums:");
        foreach (var album in albums)
        {
            Console.WriteLine(album);
        }
    }

    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:\n1. Work with integer array\n2. Work with music albums\n3. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    HandleIntegerArray();
                    break;
                case "2":
                    HandleAlbums();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}