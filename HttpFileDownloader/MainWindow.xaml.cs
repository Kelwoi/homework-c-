using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Microsoft.Win32;

namespace HttpFileDownloader
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<DownloadItem> downloads = new();
        private HttpClient client = new();

        public MainWindow()
        {
            InitializeComponent();
            DownloadsList.ItemsSource = downloads;
        }

        private async void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            string url = UrlTextBox.Text;
            SaveFileDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;
                var cts = new CancellationTokenSource();

                var item = new DownloadItem
                {
                    FileName = Path.GetFileName(path),
                    FilePath = path,
                    Status = "Starting...",
                    Size = "0 KB",
                    CancelTokenSource = cts
                };
                downloads.Add(item);

                try
                {
                    await DownloadFileAsync(url, path, item, cts.Token);
                }
                catch (OperationCanceledException)
                {
                    item.Status = "Cancelled";
                }
                catch (Exception ex)
                {
                    item.Status = "Failed";
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private async Task DownloadFileAsync(string url, string path, DownloadItem item, CancellationToken token)
        {
            using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, token);
            response.EnsureSuccessStatusCode();

            var total = response.Content.Headers.ContentLength ?? -1L;
            var buffer = new byte[8192];
            var received = 0L;

            await using var stream = await response.Content.ReadAsStreamAsync(token);
            await using var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);

            int read;
            while ((read = await stream.ReadAsync(buffer, token)) > 0)
            {
                await fs.WriteAsync(buffer.AsMemory(0, read), token);
                received += read;

                item.Status = total > 0 ? $"Downloading... {received * 100 / total}%" : "Downloading...";
                item.Size = $"{received / 1024} KB";
            }

            item.Status = "Completed";
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (DownloadsList.SelectedItem is DownloadItem item && item.Status == "Completed")
            {
                Process.Start(new ProcessStartInfo(item.FilePath) { UseShellExecute = true });
            }
        }

        private void CancelDownload_Click(object sender, RoutedEventArgs e)
        {
            if (DownloadsList.SelectedItem is DownloadItem item && item.CancelTokenSource != null && item.Status.StartsWith("Downloading"))
            {
                item.CancelTokenSource.Cancel();
                item.Status = "Cancelling...";
            }
        }
    }

    public class DownloadItem : INotifyPropertyChanged
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

        private string status;
        public string Status
        {
            get => status;
            set { status = value; OnPropertyChanged("Status"); }
        }

        private string size;
        public string Size
        {
            get => size;
            set { size = value; OnPropertyChanged("Size"); }
        }

        public CancellationTokenSource CancelTokenSource { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class StatusToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string status && status.StartsWith("Downloading") ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
