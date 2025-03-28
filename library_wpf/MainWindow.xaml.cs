using System.Data;
using System.Data.SqlClient;
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

namespace library_wpf
{
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Library; Integrated Security=True; Connect Timeout = 2";

        public MainWindow()
        {
            InitializeComponent();
            LoadComboBox();
            LoadData("Genre");
        }

        private void LoadComboBox()
        {
            comboBoxFilter.Items.Add("Genre");
            comboBoxFilter.Items.Add("Author");
            comboBoxFilter.SelectedIndex = 0;
        }

        private void LoadData(string filterType, string filterValue = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM book";
                if (!string.IsNullOrEmpty(filterValue))
                {
                    query += $" WHERE {filterType} = @FilterValue";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(filterValue))
                    {
                        cmd.Parameters.AddWithValue("@FilterValue", filterValue);
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                }
            }
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            string title = "New Book";
            string author = "Unknown";
            string genre = "Unknown";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO book (Title, Author, Genre, Year) VALUES (@Title, @Author, @Genre)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@Genre", genre);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData("Genre");
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is DataRowView row)
            {
                int id = Convert.ToInt32(row["ID"]);
                string newTitle = "Edited Book";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE book SET Title = @Title WHERE ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", newTitle);
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData("Genre");
            }
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is DataRowView row)
            {
                int id = Convert.ToInt32(row["ID"]);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM book WHERE ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData("Genre");
            }
        }
    }
}