using MailKit.Net.Imap;
using MailKit.Security;
using System;
using System.Net.Mail;
using System.Windows;

namespace GmailClient
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var client = new ImapClient();
                await client.ConnectAsync("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(EmailTextBox.Text, PasswordBox.Password);

                client.Disconnect(true);

                var mainWindow = new MainWindow(EmailTextBox.Text, PasswordBox.Password);
                mainWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed: " + ex.Message);
            }
        }
    }
}