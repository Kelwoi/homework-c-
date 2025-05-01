using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ResumeAnalyzer
{
    public partial class MainWindow : Window
    {
        private readonly List<Candidate> candidates = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LoadFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                await LoadCandidateFromFileAsync(dialog.FileName);
                ShowReports();
            }
        }

        private async void LoadMultipleFiles_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Multiselect = true };
            if (dialog.ShowDialog() == true)
            {
                var tasks = dialog.FileNames.Select(LoadCandidateFromFileAsync);
                await Task.WhenAll(tasks);
                ShowReports();
            }
        }

        private async void LoadFromFolder_Click(object sender, RoutedEventArgs e)
        {
            string folderPath = Microsoft.VisualBasic.Interaction.InputBox("Enter folder path:", "Select Folder");

            if (!string.IsNullOrWhiteSpace(folderPath) && Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath, "*.txt");
                var tasks = files.Select(LoadCandidateFromFileAsync);
                await Task.WhenAll(tasks);
                ShowReports();
            }
            else
            {
                System.Windows.MessageBox.Show("Invalid folder path.");
            }
        }

        private async Task LoadCandidateFromFileAsync(string path)
        {
            try
            {
                await Task.Delay(100); 
                var lines = await File.ReadAllLinesAsync(path);

                var candidate = new Candidate
                {
                    Name = lines.FirstOrDefault(l => l.StartsWith("Name:"))?.Split(':')[1].Trim(),
                    City = lines.FirstOrDefault(l => l.StartsWith("City:"))?.Split(':')[1].Trim(),
                    ExperienceYears = int.Parse(lines.FirstOrDefault(l => l.StartsWith("ExperienceYears:"))?.Split(':')[1].Trim()),
                    ExpectedSalary = decimal.Parse(lines.FirstOrDefault(l => l.StartsWith("ExpectedSalary:"))?.Split(':')[1].Trim())
                };

               
                lock (candidates)
                {
                    candidates.Add(candidate);
                }
            }
            catch (Exception ex)
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    System.Windows.MessageBox.Show($"Error reading file: {path}\n{ex.Message}");
                });
            }
        }

        private void ShowReports()
        {
            if (!candidates.Any())
            {
                ReportTextBox.Text = "No resumes loaded.";
                return;
            }

            var mostExperienced = candidates.OrderByDescending(c => c.ExperienceYears).First();
            var leastExperienced = candidates.OrderBy(c => c.ExperienceYears).First();
            var lowestSalary = candidates.OrderBy(c => c.ExpectedSalary).First();
            var highestSalary = candidates.OrderByDescending(c => c.ExpectedSalary).First();
            var groupedByCity = candidates.GroupBy(c => c.City)
                                          .Where(g => g.Count() > 1)
                                          .Select(g => $"{g.Key}: {g.Count()} candidates");

            ReportTextBox.Text =
                $"Most experienced: {mostExperienced.Name} ({mostExperienced.ExperienceYears} years)\n" +
                $"Least experienced: {leastExperienced.Name} ({leastExperienced.ExperienceYears} years)\n" +
                $"Lowest salary demand: {lowestSalary.Name} ({lowestSalary.ExpectedSalary} $)\n" +
                $"Highest salary demand: {highestSalary.Name} ({highestSalary.ExpectedSalary} $)\n\n" +
                $"Candidates from same city:\n" +
                (groupedByCity.Any() ? string.Join("\n", groupedByCity) : "No shared cities.");
        }
    }
}
