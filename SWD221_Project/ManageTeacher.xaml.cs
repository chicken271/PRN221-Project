using Microsoft.EntityFrameworkCore;
using SWD221_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for ManageTeacher.xaml
    /// </summary>
    public partial class ManageTeacher : Window
    {
        public AttendanceDBContext context;
        public ManageTeacher()
        {
            InitializeComponent();
            context = new AttendanceDBContext();
        }

        public void LoadData()
        {
            lvTeacher.ItemsSource = context.Teachers.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public Teacher CheckTeacherId()
        {
            return context.Teachers.FirstOrDefault(x => x.TeacherId == tbTeacherId.Text);
        }

        public string Validation()
        {
            string errorMessage = "";
            if(string.IsNullOrEmpty(tbTeacherId.Text))
            {
                errorMessage += "TeacherId is a required field\n";
            }

            if (string.IsNullOrEmpty(tbTeacherName.Text))
            {
                errorMessage += "TeacherName is a required field\n";
            }

            if (string.IsNullOrEmpty(tbTeacherEmail.Text))
            {
                errorMessage += "TeacherEmail is a required field\n";
            }

            if (string.IsNullOrEmpty(tbTeacherPassword.Text))
            {
                errorMessage += "TeacherPassword is a required field\n";
            }

            return errorMessage;
        }

        public Teacher GetTeacherFromUI()
        {
            Teacher teacher = new Teacher();
            teacher.TeacherId = tbTeacherId.Text;
            teacher.Name = tbTeacherName.Text;
            teacher.Email = tbTeacherEmail.Text;
            teacher.Password = tbTeacherPassword.Text;
            return teacher;
        }

        private void btnTeacherAdd_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = Validation();
            if (CheckTeacherId() != null)
            {
                errorMessage += "TeacherId is a duplicate id\n";
            }

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage,"Warning",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Teacher teacher = GetTeacherFromUI();
                context.Teachers.Add(teacher);
                context.SaveChanges();
                LoadData();
                MessageBox.Show($"Add teacher with id of {teacher.TeacherId} Successfully !!");
            }
        }

        private void btnTeacherUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = Validation();
                Teacher oldTeacher = CheckTeacherId();
                if (oldTeacher == null)
                {
                    errorMessage += "Teacher is not found\n";
                }

                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Teacher newTeacher = GetTeacherFromUI();
                    oldTeacher.Name = newTeacher.Name;
                    oldTeacher.Email = newTeacher.Email;
                    oldTeacher.Password = newTeacher?.Password;

                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show($"Update teacher with id of {oldTeacher.TeacherId} Successfully !!");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTeacherDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                if (string.IsNullOrEmpty(tbTeacherId.Text))
                {
                    errorMessage += "TeacherId is a required field\n";
                }
                
                if(errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string TeacherId = tbTeacherId.Text;
                    Teacher deleTeacher = CheckTeacherId();
                    context.Database.ExecuteSqlRaw(
                $"Update Class set TeacherID = null where TeacherID = '{TeacherId}';");
                    context.Teachers.Remove(deleTeacher);
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show($"Delete teacher with id of {TeacherId} Successfully !!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Clear();
            tbTeacherId.Clear();
            tbTeacherName.Clear();
            tbTeacherEmail.Clear();
            tbTeacherPassword.Clear();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
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
                    var searchResult = context.Teachers.Where(x => x.TeacherId == tbSearch.Text || x.Name.Contains(tbSearch.Text)).ToList();
                    lvTeacher.ItemsSource = searchResult;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
