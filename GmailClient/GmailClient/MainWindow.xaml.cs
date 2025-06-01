using MailKit.Net.Imap;
using MailKit;
using MimeKit;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GmailClient
{
    public partial class MainWindow : Window
    {
        private string email;
        private string password;

        public ObservableCollection<EmailItem> Emails { get; set; } = new();

        public MainWindow(string email, string password)
        {
            InitializeComponent();
            this.email = email;
            this.password = password;
            EmailListView.ItemsSource = Emails;
            LoadEmails();
        }

        private async void LoadEmails()
        {
            using var client = new ImapClient();
            await client.ConnectAsync("imap.gmail.com", 993, true);
            await client.AuthenticateAsync(email, password);

            var inbox = client.Inbox;
            await inbox.OpenAsync(FolderAccess.ReadOnly);
            var messages = await inbox.FetchAsync(0, -1, MailKit.MessageSummaryItems.Envelope);

            foreach (var msg in messages.Reverse())
            {
                Emails.Add(new EmailItem
                {
                    From = msg.Envelope.From.Mailboxes.FirstOrDefault()?.Address,
                    Subject = msg.Envelope.Subject,
                    Date = msg.Envelope.Date?.DateTime.ToString()
                });
            }

            client.Disconnect(true);
        }
    }

    public class EmailItem
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
    }
}