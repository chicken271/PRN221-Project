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
    /// Interaction logic for StudentDashboard.xaml
    /// </summary>
    public partial class StudentDashboard : Window
    {
        public AttendanceDBContext context;
        public StudentDashboard(String StudentId)
        {
            InitializeComponent();
            context = new AttendanceDBContext();
            tbStudentId.Text = StudentId;
        }

        public void LoadData()
        {
            var listOfClass = (from classes in context.Classes
                              join belong in context.BelongTos on classes.ClassId equals belong.ClassId
                              where belong.StudentId == tbStudentId.Text
                              select new
                              {
                                  ClassId = classes.ClassId,
                                  TeacherId = classes.TeacherId,
                                  ClassName = classes.ClassName,
                              }).ToList();

            lvClass.ItemsSource = listOfClass;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Clear();
            tbClassId.Clear();
            tbTeacherId.Clear();
            tbClassName.Clear();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
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
                    var listOfClass = (from classes in context.Classes
                                       join belong in context.BelongTos on classes.ClassId equals belong.ClassId
                                       where belong.StudentId == tbStudentId.Text
                                       select new
                                       {
                                           ClassId = classes.ClassId,
                                           TeacherId = classes.TeacherId,
                                           ClassName = classes.ClassName,
                                       });

                    var searchResult = listOfClass.Where(x => x.ClassId == tbSearch.Text || x.ClassName.Contains(tbSearch.Text) || x.TeacherId == tbSearch.Text).ToList();
                    lvClass.ItemsSource = searchResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAttendance_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                if (string.IsNullOrEmpty(tbClassId.Text))
                {
                    errorMessage += "ClassId is a required fiedld\n";
                }

                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string ClassId = tbClassId.Text;
                    StudentAttendance studentAttendance = new StudentAttendance(ClassId);
                    studentAttendance.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnWorkProgress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                if (string.IsNullOrEmpty(tbClassId.Text))
                {
                    errorMessage += "ClassId is a required fiedld\n";
                }

                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string ClassId = tbClassId.Text;
                    string StudentId = tbStudentId.Text;
                    StudentWorkProgressWindow sww = new StudentWorkProgressWindow(StudentId,ClassId);
                    sww.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
