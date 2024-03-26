using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using OfficeOpenXml;
using SWD221_Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            if(IsValidEmail(tbStudentEmail.Text) == false)
            {
                errorMessage += "Email field is not in the correct gmail format !";
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

                    context.Database.ExecuteSqlRaw($"Delete from BelongTo where StudentID = '{StudentId}';");

                    List<StudentWorkProgress> deleStudentWorkProgress = context.StudentWorkProgresses.Where(x => x.StudentId == StudentId).ToList();
                    foreach (StudentWorkProgress swp in deleStudentWorkProgress)
                    {
                        MessageBox.Show(swp.ProgressId.ToString());
                        MessageBox.Show(swp.StudentId);
                        context.StudentWorkProgresses.Remove(swp);
                    }

                    List<Attendance> deleAttendance = context.Attendances.Where(x => x.StudentId == StudentId).ToList();
                    foreach(Attendance attendance in deleAttendance)
                    {
                        context.Attendances.Remove(attendance);
                    }

                    context.Students.Remove(deleStudent);
                    context.SaveChanges();
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

        public Student CheckStudentId2(string teacherId)
        {
            return context.Students.FirstOrDefault(x => x.StudentId == teacherId);
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

        public string ValidateIdColumn(string filePath)
        {
            const int expectedColumnCount = 4;
            string errorMessage = "";
            string[] expectedFirstRowValues = { "StudentID", "Name", "Email", "Password" };
            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first sheet

                    if (worksheet.Dimension.Columns != expectedColumnCount)
                    {
                        errorMessage += "The import excel file can only have 4 column!\n";
                    }

                    for (int col = 1; col <= expectedColumnCount; col++)
                    {
                        var cellValue = worksheet.Cells[1, col].Value?.ToString();

                        if (cellValue != expectedFirstRowValues[col - 1])
                        {
                            errorMessage += "The import excel file is not in the correct format!\n";
                            break;
                        }
                    }

                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // Skipping header row (assuming headers are in row 1)
                    {
                        string cellValue = worksheet.Cells[row, 1].Value?.ToString();
                        string email = worksheet.Cells[row, 3].Value?.ToString();

                        // Add your validation logic for the cell value in the first column
                        if (CheckStudentId2(cellValue) != null)
                        {
                            errorMessage += $"The import excel file has dupplicate id at row {row} !\n";
                        }

                        if (IsValidEmail(email) == false)
                        {
                            errorMessage += $"The import excel file has invalid email id at row {row} !\n";
                        }
                    }


                    for (int row = 2; row <= rowCount; row++)
                    {
                        for (int col = 1; col <= expectedColumnCount; col++)
                        {
                            var cellValue = worksheet.Cells[row, col].Value?.ToString();

                            if (string.IsNullOrEmpty(cellValue))
                            {
                                errorMessage += $"The import excel file has a required cell empty at row {row} column {col} !\n";
                            }
                        }


                        // If the loop completes without any validation failures, return true
                    }
                    return errorMessage;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading and validating data from Excel: " + ex.Message);
                return errorMessage;
            }
        }

        private void btnImportExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                OpenFileDialog openFile = new OpenFileDialog();
                string errorMessage = "";
                if (openFile.ShowDialog() == true)
                {
                    string filePath = openFile.FileName;

                    errorMessage = ValidateIdColumn(filePath);

                    if (errorMessage != "")
                    {
                        MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        using (var package = new ExcelPackage(new FileInfo(filePath)))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first sheet
                            int rowCount = worksheet.Dimension.Rows;
                            List<Student> teachersToImport = new List<Student>();
                            for (int row = 2; row <= rowCount; row++) // Assuming row 1 contains headers
                            {
                                teachersToImport.Add(new Student
                                {
                                    // Assuming your Star class has properties like Name, Type, etc.
                                    StudentId = worksheet.Cells[row, 1].Value?.ToString(),
                                    Name = worksheet.Cells[row, 2].Value?.ToString(),
                                    Email = worksheet.Cells[row, 3].Value?.ToString(),
                                    Password = worksheet.Cells[row, 4].Value?.ToString()
                                    // Add more properties as needed
                                });
                            }

                            context.Students.AddRange(teachersToImport);
                            context.SaveChanges();
                            MessageBox.Show("Import file excel of teachers successfully");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing data from Excel: " + ex.Message);
            }
        }

        public float CalculatePercentAttendance(string id)
        {
            int attended = context.Attendances.Where(a => a.StudentId.Equals(id) && a.Present == true).Count();
            int absent = context.Attendances.Where(a => a.StudentId.Equals(id)).Count();
            return ((float)attended / absent) * 100.0f;
        }

        public float CalculateWorkComplete(string id)
        {
            int attended = context.StudentWorkProgresses.Where(a => a.StudentId.Equals(id) && a.Complete == true).Count();
            int absent = context.StudentWorkProgresses.Where(a => a.StudentId.Equals(id)).Count();
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
                        worksheet.Cells[1, 5].Value = "Overall Attendance %";
                        worksheet.Cells[1, 6].Value = "Overall WorkProgress %";

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
