using Microsoft.Win32;
using OfficeOpenXml;
using SWD221_Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public float CalculatePercentAttendance(string id)
        {
            int attended = context.Attendances.Where(a => a.StudentId.Equals(id) && a.Present == true && a.ClassId.Equals(tbClassId.Text)).Count();
            int absent = context.Attendances.Where(a => a.StudentId.Equals(id) && a.ClassId.Equals(tbClassId.Text)).Count();
            return ((float)attended / absent) * 100.0f;
        }

        public float CalculateWorkComplete(string id)
        {
            var joinedList = (from work in context.Works
                              join progress in context.StudentWorkProgresses on work.WorkId equals progress.WorkId
                              where progress.StudentId == id && work.ClassId == tbClassId.Text
                              select new
                              {
                                  ProgressId = progress.ProgressId,
                                  StudentID = progress.StudentId,
                                  WorkID = work.WorkId,
                                  WorkName = work.WorkName,
                                  WorkDescription = work.Description,
                                  Complete = progress.Complete,
                                  ClassID = work.ClassId
                              }).ToList();
            int attended = joinedList.Where(x => x.Complete == true).Count();
            int absent = joinedList.Count();
            return ((float)attended / absent) * 100.0f;
        }

        private void btnExportExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Excel files (*.xlsx)|*.xlsx";

                if (saveFile.ShowDialog() == true)
                {
                    var file = new FileInfo(saveFile.FileName);
                    var listOfTeachers = context.Students.ToList();

                    using (var package = new ExcelPackage(file))
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Students");

                        // Add header row
                        worksheet.Cells[1, 1].Value = "StudentID";
                        worksheet.Cells[1, 2].Value = "Name";
                        worksheet.Cells[1, 3].Value = "Email";
                        worksheet.Cells[1, 4].Value = "Password";
                        worksheet.Cells[1, 5].Value = "Attendance %";
                        worksheet.Cells[1, 6].Value = "WorkProgress %";
                        worksheet.Cells[1, 8].Value = tbClassId.Text;

                        // Add data rows
                        int row = 2;
                        foreach (var teacher in listOfTeachers)
                        {
                            worksheet.Cells[row, 1].Value = teacher.StudentId;
                            worksheet.Cells[row, 2].Value = teacher.Name;
                            worksheet.Cells[row, 3].Value = teacher.Email;
                            worksheet.Cells[row, 4].Value = teacher.Password;
                            worksheet.Cells[row, 5].Value = CalculatePercentAttendance(teacher.StudentId);
                            worksheet.Cells[row, 6].Value = CalculateWorkComplete(teacher.StudentId);
                            row++;
                        }

                        package.Save();
                    }

                    MessageBox.Show("Save list of students to excel file successfully !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving the list of students to Excel file: " + ex.Message);
            }
        }
    }
}
