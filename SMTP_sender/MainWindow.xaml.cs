using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SMTP_sender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string server = "smtp.gmail.com";
        const short port = 587;
        string username = "";
        string password = "";
        private List<string> selectedFilePaths = new List<string>();


        public MainWindow(string email, string Password)
        {
            InitializeComponent();

            username = email;
            password = Password;
        }

        private void SelectFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePaths.Clear();
                listFiles.Items.Clear();

                foreach (string file in openFileDialog.FileNames)
                {
                    selectedFilePaths.Add(file);
                    listFiles.Items.Add(System.IO.Path.GetFileName(file));
                }
            }
        }

        private string GetRichText(RichTextBox richTextBox)
        {
            TextRange textRange = new TextRange(
                richTextBox.Document.ContentStart,
                richTextBox.Document.ContentEnd
            );
            return textRange.Text;
        }


        private void SendMessage(object sender, RoutedEventArgs e)
        {
            MailMessage message = new MailMessage(username, toBox.Text, themeBox.Text, GetRichText(messageBox));



            message.Priority = MailPriority.Low;
            if (MediumImportance.IsChecked == true)
                message.Priority = MailPriority.Normal;
            else if (HighImportance.IsChecked == true)
                message.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient(server, port);

            client.Credentials = new NetworkCredential(username, password);
            client.EnableSsl = true;

            client.SendAsync(message, new object());

            client.SendCompleted += SendMessageCompleted;

        }

        private void SendMessageCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Sent succesfully!");
        }
    }
}