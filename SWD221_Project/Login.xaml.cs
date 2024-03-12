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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public AttendanceDBContext context;
        public List<String> roles;
        public Login()
        {
            InitializeComponent();
            context = new AttendanceDBContext();
            roles = new List<String> { "Student","Teacher","Admin"  };
        }

        public string Validation()
        {
            string errorMessage = "";
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                errorMessage += "Email is a required field\n";
            }

            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                errorMessage += "Password is a required field\n";
            }

            if (cbRole.SelectedValue == null)
            {
                errorMessage += "Role is a required value\n";
            }

            return errorMessage;
        }

        public Admin GetAdminByEmailAndPassword()
        {
            return context.Admins.FirstOrDefault(x => x.Email.Equals(tbEmail.Text) && x.Password.Equals(tbPassword.Text));
        }

        public Student GetStudentByEmailAndPassword()
        {
            return context.Students.FirstOrDefault(x => x.Email.Equals(tbEmail.Text) && x.Password.Equals(tbPassword.Text));
        }

        public Teacher GetTeacherByEmailAndPassword()
        {
            return context.Teachers.FirstOrDefault(x => x.Email.Equals(tbEmail.Text) && x.Password.Equals(tbPassword.Text));
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = Validation();

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string roleSelected = cbRole.SelectedValue.ToString();
                if (roleSelected.Equals("Teacher"))
                {
                    Teacher teacher = GetTeacherByEmailAndPassword();
                    if(teacher == null)
                    {
                        MessageBox.Show("Login Failed", "Login");
                    }
                    else
                    {
                        TeacherDashboard teacherDashboard = new TeacherDashboard(teacher.TeacherId);
                        teacherDashboard.Show();
                        this.Close();
                    }
                }

                if (roleSelected.Equals("Student"))
                {
                    Student student = GetStudentByEmailAndPassword();
                    if(student == null)
                    {
                        MessageBox.Show("Login Failed", "Login");
                    }
                    else
                    {
                        MessageBox.Show(student.StudentId);
                    }
                }

                if (roleSelected.Equals("Admin")){
                    Admin admin = GetAdminByEmailAndPassword();
                    if(admin == null)
                    {
                        MessageBox.Show("Login Failed", "Login");
                    }
                    else
                    {
                        AdminDashboard ad = new AdminDashboard();
                        ad.Show();
                        this.Close();
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbRole.ItemsSource = roles;
        }
    }
}
