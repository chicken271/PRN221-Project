using SWD221_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PRN221_Project
{
    /// <summary>
    /// Interaction logic for StudentsDetails.xaml
    /// </summary>
    public partial class StudentsDetails : Window
    {
        public AttendanceDBContext context;
        public StudentsDetails(string ClassID)
        {
            InitializeComponent();
            context = new AttendanceDBContext();
            tbClassId.Text = ClassID;
        }

        public void LoadData()
        {
            var listOfStudentId = context.BelongTos
            .Where(bt => bt.ClassId == tbClassId.Text)
            .Select(x => x.StudentId)
            .ToList();

            // Retrieve the students based on the list of StudentIds
            var studentInClass = context.Students
                .Where(s => listOfStudentId.Contains(s.StudentId))
                .ToList();

            lvStudent.ItemsSource = studentInClass;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Clear();
            tbStudentId.Clear();
            tbStudentName.Clear();
            tbStudentEmail.Clear();
            tbStudentPassword.Clear();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                if (string.IsNullOrEmpty(tbSearch.Text))
                {
                    errorMessage += "Search bar input is empty\n";
                }
                else
                {
                    var searchResult = context.Students.Where(x => x.StudentId == tbSearch.Text || x.Name.Contains(tbSearch.Text)).ToList();
                    lvStudent.ItemsSource = searchResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStudentWorkProgress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                if (string.IsNullOrEmpty(tbStudentId.Text))
                {
                    errorMessage += "StudentId is a required fiedld\n";
                }

                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    WorkProgressWindow workProgressWindow = new WorkProgressWindow(tbClassId.Text,tbStudentId.Text);
                    workProgressWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
