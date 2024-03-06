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
    /// Interaction logic for ClassPopup.xaml
    /// </summary>
    public partial class ClassPopup : Window
    {
        public AttendanceDBContext context;
        public ClassPopup(string ClassId)
        {
            InitializeComponent();
            context = new AttendanceDBContext();
            tbClassId.Text = ClassId;
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

            lvStudentsInClass.ItemsSource = studentInClass;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public BelongTo CheckStudentId()
        {
            return context.BelongTos.FirstOrDefault(x => x.StudentId == tbStudentId.Text && x.ClassId == tbClassId.Text);
        }

        public string Validation()
        {
            string errorMessage = "";
            if (string.IsNullOrEmpty(tbStudentId.Text))
            {
                errorMessage += "StudentId is a required field\n";
            }

            return errorMessage;
        }

        public BelongTo GetClassFromUI()
        {
            BelongTo classFromUI = new BelongTo();
            classFromUI.ClassId = tbClassId.Text;
            classFromUI.StudentId = tbStudentId.Text;
            return classFromUI;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = Validation();
            if (CheckStudentId() != null)
            {
                errorMessage += "Student is already in this class\n";
            }
            if(context.Students.FirstOrDefault(x => x.StudentId == tbStudentId.Text) == null){
                errorMessage += "Student does not exist\n";
            }

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                BelongTo addClass = GetClassFromUI();
                context.Database.ExecuteSqlRaw($"INSERT INTO BelongTo (StudentID, ClassID) VALUES ('{addClass.StudentId}', '{addClass.ClassId}');");
                //context.BelongTos.Add(addClass); //error database
                context.SaveChanges();
                LoadData();
                MessageBox.Show($"Add student id of {addClass.StudentId} in class with id of {addClass.ClassId} Successfully !!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = Validation();
            if(CheckStudentId() == null)
            {
                errorMessage += "Student is not found in this class\n";
            }

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string ClassId = tbClassId.Text;
                string StudentId = tbStudentId.Text;
                BelongTo deleClass = CheckStudentId();

                context.Database.ExecuteSqlRaw($"Delete from BelongTo where StudentID = '{StudentId}' AND ClassID = '{ClassId}';");
                context.SaveChanges();
                LoadData();
                MessageBox.Show($"Delete class with id of {ClassId} Successfully !!");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
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
                    var listOfStudentId = context.BelongTos
                    .Where(bt => bt.ClassId == tbClassId.Text)
                    .Select(x => x.StudentId);

                    // Retrieve the students based on the list of StudentIds
                    var studentInClass = context.Students
                        .Where(s => listOfStudentId.Contains(s.StudentId));

                    lvStudentsInClass.ItemsSource = studentInClass.Where(x => x.StudentId.Equals(tbSearch.Text) || x.Name.Contains(tbSearch.Text)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = "";
            tbStudentId.Text = "";
        }
    }
}
