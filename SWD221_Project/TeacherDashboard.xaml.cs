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
    /// Interaction logic for TeacherDashboard.xaml
    /// </summary>
    public partial class TeacherDashboard : Window
    {
        public AttendanceDBContext context;
        public TeacherDashboard(String teacherId)
        {
            InitializeComponent();
            context = new AttendanceDBContext();
            tbTeacherId.Text = teacherId;
        }

        public void LoadData()
        {
            var listOfWork = context.Classes.Where(c => c.TeacherId.Equals(tbTeacherId.Text)).ToList();

            lvClass.ItemsSource = listOfWork;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public Class CheckClassId()
        {
            return context.Classes.FirstOrDefault(x => x.ClassId == tbClassId.Text);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Clear();
            tbClassName.Clear();
            tbClassId.Clear();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

        private void btnStudentsDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                Class oldClass = CheckClassId();
                if (string.IsNullOrEmpty(tbClassId.Text))
                {
                    errorMessage += "ClassId is a required fiedld\n";
                }

                if (oldClass == null)
                {
                    errorMessage += "Class is not found\n";
                }

                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string ClassId = tbClassId.Text;
                    StudentsDetails studentsDetails = new StudentsDetails(ClassId);
                    studentsDetails.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnManageWorkInClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                Class oldClass = CheckClassId();
                if (string.IsNullOrEmpty(tbClassId.Text))
                {
                    errorMessage += "ClassId is a required fiedld\n";
                }

                if (oldClass == null)
                {
                    errorMessage += "Class is not found\n";
                }

                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string ClassId = tbClassId.Text;
                    WorkPopup workPopup = new WorkPopup(ClassId);
                    workPopup.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    string searchInput = tbSearch.Text;
                    var searchResult = context.Classes.Where(x => x.ClassId == searchInput || x.ClassName.Contains(tbSearch.Text)).ToList();
                    lvClass.ItemsSource = searchResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTakeAttendance_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                Class oldClass = CheckClassId();
                if (string.IsNullOrEmpty(tbClassId.Text))
                {
                    errorMessage += "ClassId is a required fiedld\n";
                }

                if (oldClass == null)
                {
                    errorMessage += "Class is not found\n";
                }

                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string ClassId = tbClassId.Text;
                    WorkPopup workPopup = new WorkPopup(ClassId);
                    workPopup.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
