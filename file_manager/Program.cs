internal class Program
{
    static void CreateDirectory(string currentDirectory)
    {
        Console.Write("Enter directory name: ");
        string dirName = Console.ReadLine();
        string path = Path.Combine(currentDirectory, dirName);
        Directory.CreateDirectory(path);
        Console.WriteLine("Directory created successfully.");
    }

    static void DeleteDirectory(string currentDirectory)
    {
        Console.Write("Enter directory name: ");
        string dirName = Console.ReadLine();
        string path = Path.Combine(currentDirectory, dirName);
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
            Console.WriteLine("Directory deleted successfully.");
        }
        else
        {
            Console.WriteLine("Directory not found.");
        }
    }

    static void ViewDirectoryContents(string currentDirectory)
    {
        string[] files = Directory.GetFiles(currentDirectory);
        string[] directories = Directory.GetDirectories(currentDirectory);
        Console.WriteLine("Directories:");
        foreach (var dir in directories) Console.WriteLine(dir);
        Console.WriteLine("Files:");
        foreach (var file in files) Console.WriteLine(file);
    }

    static void ViewSubdirectories(string currentDirectory)
    {
        string[] directories = Directory.GetDirectories(currentDirectory);
        Console.WriteLine("Subdirectories:");
        foreach (var dir in directories) Console.WriteLine(dir);
    }

    static void DeleteFile(string currentDirectory)
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();
        string path = Path.Combine(currentDirectory, fileName);
        if (File.Exists(path))
        {
            File.Delete(path);
            Console.WriteLine("File deleted successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    static void MoveFile(string currentDirectory)
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();
        Console.Write("Enter destination directory: ");
        string destDir = Console.ReadLine();
        string sourcePath = Path.Combine(currentDirectory, fileName);
        string destPath = Path.Combine(destDir, fileName);
        if (File.Exists(sourcePath))
        {
            File.Move(sourcePath, destPath);
            Console.WriteLine("File moved successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    static void ViewFileInfo(string currentDirectory)
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();
        string path = Path.Combine(currentDirectory, fileName);
        if (File.Exists(path))
        {
            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine($"Size: {fileInfo.Length} bytes");
            Console.WriteLine($"Created: {fileInfo.CreationTime}");
            Console.WriteLine($"Last Modified: {fileInfo.LastWriteTime}");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    static string ChangeDirectory(string currentDirectory)
    {
        Console.Write("Enter new directory path: ");
        string newDir = Console.ReadLine();
        if (Directory.Exists(newDir))
        {
            return currentDirectory = newDir;
        }
        else
        {
            Console.WriteLine("Directory not found.");
            return currentDirectory;
        }
    }

    private static void Main(string[] args)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        while (true)
        {
            Console.WriteLine($"\nCurrent Directory: {currentDirectory}");
            Console.WriteLine("1. Create Directory");
            Console.WriteLine("2. Delete Directory");
            Console.WriteLine("3. View Directory Contents");
            Console.WriteLine("4. View Subdirectories Only");
            Console.WriteLine("5. Delete File");
            Console.WriteLine("6. Move File");
            Console.WriteLine("7. View File Info");
            Console.WriteLine("8. Change Directory");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": CreateDirectory( currentDirectory); break;
                case "2": DeleteDirectory( currentDirectory); break;
                case "3": ViewDirectoryContents(currentDirectory); break;
                case "4": ViewSubdirectories(currentDirectory); break;
                case "5": DeleteFile(currentDirectory); break;
                case "6": MoveFile(currentDirectory); break;
                case "7": ViewFileInfo(currentDirectory); break;
                case "8": currentDirectory = ChangeDirectory(currentDirectory);break;
                case "9": return;
                default: Console.WriteLine("Invalid option!"); break;
            }
        }
    }
}