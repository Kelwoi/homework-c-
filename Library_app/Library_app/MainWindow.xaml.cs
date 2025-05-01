using Library_app.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Configuration;
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

namespace Library_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LibraryContext _context = new LibraryContext();

        public MainWindow()
        {
            InitializeComponent();
        }
        public class LibraryContext : DbContext
        {
            public DbSet<Author> Authors { get; set; }
            public DbSet<Book> Books { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var connectionString = ConfigurationManager
                    .ConnectionStrings["connLibrary"].ConnectionString;

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            using var context = new LibraryContext();
            var authors = await context.Authors.ToListAsync();
            AuthorComboBox.ItemsSource = authors;
            AuthorComboBox.DisplayMemberPath = "Name";
        }

        private async void AuthorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AuthorComboBox.SelectedItem is Author selectedAuthor)
            {
                using var context = new LibraryContext();
                var books = await context.Books
                    .Where(b => b.AuthorId == selectedAuthor.Id)
                    .ToListAsync();
                BooksListBox.ItemsSource = books;
                BooksListBox.DisplayMemberPath = "Title";
            }
        }

        private async void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = SearchTextBox.Text;
            if (text.Length < 3)
                return;

            using var context = new LibraryContext();
            var books = await context.Books
                .Where(b => b.Title.Contains(text))
                .ToListAsync();
            BooksListBox.ItemsSource = books;
            BooksListBox.DisplayMemberPath = "Title";
        }

    }
}
