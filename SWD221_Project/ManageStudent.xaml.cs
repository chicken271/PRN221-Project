using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ManageStudent.xaml
    /// </summary>
    public partial class ManageStudent : Window
    {
        public AttendanceDBContext context;
        public ManageStudent()
        {
            InitializeComponent();
            context = new AttendanceDBContext();
        }

        public void LoadData()
        {
            lvStudent.ItemsSource = context.Students.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public Student CheckStudentId()
        {
            return context.Students.FirstOrDefault(x => x.StudentId == tbStudentId.Text);
        }

        public string Validation()
        {
            string errorMessage = "";
            if (string.IsNullOrEmpty(tbStudentId.Text))
            {
                errorMessage += "StudentId is a required field\n";
            }

            if (string.IsNullOrEmpty(tbStudentName.Text))
            {
                errorMessage += "StudentName is a required field\n";
            }

            if (string.IsNullOrEmpty(tbStudentEmail.Text))
            {
                errorMessage += "StudentEmail is a required field\n";
            }

            if (string.IsNullOrEmpty(tbStudentPassword.Text))
            {
                errorMessage += "StudentPassword is a required field\n";
            }

            return errorMessage;
        }

        public Student GetStudentFromUI()
        {
            Student student = new Student();
            student.StudentId = tbStudentId.Text;
            student.Name = tbStudentName.Text;
            student.Email = tbStudentEmail.Text;
            student.Password = tbStudentPassword.Text;
            return student;
        }

        private void btnStudentAdd_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = Validation();
            if (CheckStudentId() != null)
            {
                errorMessage += "StudentId is a duplicate id\n";
            }

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Student student = GetStudentFromUI();
                context.Students.Add(student);
                context.SaveChanges();
                LoadData();
                MessageBox.Show($"Add student with id of {student.StudentId} Successfully !!");
            }
        }

        private void btnStudentUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = Validation();
                Student oldStudent = CheckStudentId();
                if (oldStudent == null)
                {
                    errorMessage += "Student is not found\n";
                }

                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Student newStudent = GetStudentFromUI();
                    oldStudent.Name = newStudent.Name;
                    oldStudent.Email = newStudent.Email;
                    oldStudent.Password = newStudent?.Password;

                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show($"Update student with id of {oldStudent.StudentId} Successfully !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStudentDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                if (string.IsNullOrEmpty(tbStudentId.Text))
                {
                    errorMessage += "StudentId is a required field\n";
                }

                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string StudentId = tbStudentId.Text;
                    Student deleStudent = CheckStudentId();

                    List<BelongTo> removeFromClass = context.BelongTos.Where(x => x.StudentId == StudentId).ToList();
                    foreach (BelongTo bt in removeFromClass)
                    {
                        MessageBox.Show(bt.StudentId);
                        MessageBox.Show(bt.ClassId);
                    }

                    List<StudentWorkProgress> deleStudentWorkProgress = context.StudentWorkProgresses.Where(x => x.StudentId == StudentId).ToList();
                    foreach (StudentWorkProgress swp in deleStudentWorkProgress)
                    {
                        MessageBox.Show(swp.ProgressId.ToString());
                        MessageBox.Show(swp.StudentId);
                    }

                    //context.Students.Remove(deleStudent);
                    //context.SaveChanges();
                    LoadData();
                    MessageBox.Show($"Delete student with id of {StudentId} Successfully !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    var searchResult = context.Students.Where(x => x.StudentId == tbSearch.Text || x.Name.Contains(tbSearch.Text)).ToList();
                    lvStudent.ItemsSource = searchResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
