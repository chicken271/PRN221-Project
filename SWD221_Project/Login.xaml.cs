using SWD221_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            // Regular expression pattern for validating email addresses
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Use Regex.IsMatch to check if the email matches the pattern
            return Regex.IsMatch(email, emailPattern);
        }

        public string GetPassword()
        {
            System.Security.SecureString securePassword = tbPassword.SecurePassword;

            // Use the SecureStringToBSTR method to convert the SecureString to a BSTR (null-terminated Unicode string)
            IntPtr bstr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(securePassword);

            try
            {
                // Use the PtrToStringBSTR to convert the BSTR to a managed string
                return System.Runtime.InteropServices.Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                // Zero out the memory to clear the sensitive data
                if (bstr != IntPtr.Zero)
                {
                    System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(bstr);
                }
            }
        }

        public string Validation()
        {
            string errorMessage = "";
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                errorMessage += "Email is a required field\n";
            }

            if (string.IsNullOrEmpty(GetPassword()))
            {
                errorMessage += "Password is a required field\n";
            }

            if (cbRole.SelectedValue == null)
            {
                errorMessage += "Role is a required value\n";
            }

            if (IsValidEmail(tbEmail.Text) == false)
            {
                errorMessage += "Email field must be in the correct format\n";
            }

            return errorMessage;
        }

        public Admin GetAdminByEmailAndPassword()
        {
            return context.Admins.FirstOrDefault(x => x.Email.Equals(tbEmail.Text) && x.Password.Equals(GetPassword()));
        }

        public Student GetStudentByEmailAndPassword()
        {
            return context.Students.FirstOrDefault(x => x.Email.Equals(tbEmail.Text) && x.Password.Equals(GetPassword()));
        }

        public Teacher GetTeacherByEmailAndPassword()
        {
            return context.Teachers.FirstOrDefault(x => x.Email.Equals(tbEmail.Text) && x.Password.Equals(GetPassword()));
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
                        StudentDashboard studentDashboard = new StudentDashboard(student.StudentId);
                        studentDashboard.Show();
                        this.Close();
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
