using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sentence_analizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Count_on_screen()
        {
            string text = User_text.Text;
            int symbols = 0;
            int sentences = 0;
            int words = 0;
            int questions = 0;
            int screams = 0;
            Task countTask = new Task(() =>
            {
                for (int i = 0; i < text.Length; i++)
                {
                    char ch = text[i];
                    Interlocked.Increment(ref symbols);

                    switch (ch)
                    {
                        case '.':
                        case '!':
                        case '?':
                            Interlocked.Increment(ref sentences);
                            break;
                    }

                    if (ch == '?')
                        Interlocked.Increment(ref questions);
                    else if (ch == '!')
                        Interlocked.Increment(ref screams);
                }

                int localWords = text.Split(new[] { ' ', '.', '?', '!', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                Interlocked.Exchange(ref words, localWords);
            });
            countTask.Start();
            countTask.Wait();
           
            
            string display_text = $"Sentences:{sentences};\nsymbols:{symbols};\nWords:{words};\nquestions:{questions};\nScreams{screams};";
            Analize.Items.Add(display_text);
        }
        private void Count_in_file()
        {
            string text = User_text.Text;
            int symbols = 0;
            int sentences = 0;
            int words = 0;
            int questions = 0;
            int screams = 0;
            Task countTask = new Task(() =>
            {
                for (int i = 0; i < text.Length; i++)
                {
                    char ch = text[i];
                    Interlocked.Increment(ref symbols);

                    switch (ch)
                    {
                        case '.':
                        case '!':
                        case '?':
                            Interlocked.Increment(ref sentences);
                            break;
                    }

                    if (ch == '?')
                        Interlocked.Increment(ref questions);
                    else if (ch == '!')
                        Interlocked.Increment(ref screams);
                }

                int localWords = text.Split(new[] { ' ', '.', '?', '!', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                Interlocked.Exchange(ref words, localWords);
            });
            countTask.Start();
            countTask.Wait();


            string display_text = $"Sentences:{sentences};\nsymbols:{symbols};\nWords:{words};\nquestions:{questions};\nScreams{screams};";
            File.WriteAllText(file_way.Text, text);
        }
        private void Count_screen(object sender, RoutedEventArgs e)
        {
            Count_on_screen();
        }
        private void Count_file(object sender, RoutedEventArgs e)
        {
            Count_in_file();
        }
    } 
}