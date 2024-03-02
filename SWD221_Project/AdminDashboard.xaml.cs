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
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnTeacher_Click(object sender, RoutedEventArgs e)
        {
            ManageTeacher manageTeacherWindow = new ManageTeacher();
            manageTeacherWindow.Show();
            this.Close();
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            ManageStudent manageStudentWindow  = new ManageStudent();
            manageStudentWindow.Show();
            this.Close();
        }

        private void btnClass_Click(object sender, RoutedEventArgs e)
        {
            ManageClass manageClassWindow = new ManageClass();
            manageClassWindow.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }
    }
}
