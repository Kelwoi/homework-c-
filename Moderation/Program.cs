using System;
using System.IO;



internal class Program
{
    private static void Main(string[] args)
    {
        try
        {


            string moderationFilePath = "../../../moderation_words.txt";
            string textFilePath = "../../../text.txt";



            if (!File.Exists(moderationFilePath))
            {
                Console.WriteLine("file with words for moderation does not exist.");
                return;
            }

            if (!File.Exists(textFilePath))
            {
                Console.WriteLine("file does not exist.");
                return;
            }

            string[] moderationWords = File.ReadAllLines(moderationFilePath);
            string[] textLines = File.ReadAllLines(textFilePath);


            for (int i = 0; i < textLines.Length; i++)
            {
                foreach (var word in moderationWords)
                {
                    string mask = new string('*', word.Length);
                    textLines[i] = textLines[i].Replace(word, mask);
                }
            }


            string outputFilePath = "../../../moderated_text.txt";
            File.WriteAllLines(outputFilePath, textLines);

            Console.WriteLine($"Moderation is finished in file: {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error: {ex.Message}");
        }
    }
}
