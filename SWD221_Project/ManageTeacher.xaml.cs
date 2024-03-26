using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using OfficeOpenXml;
using SWD221_Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public Teacher CheckTeacherId2(string teacherId)
        {
            return context.Teachers.FirstOrDefault(x => x.TeacherId == teacherId);
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
            string[] expectedFirstRowValues = { "TeacherID", "Name", "Email", "Password" };
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
                        if (CheckTeacherId2(cellValue) != null)
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
                    var listOfTeachers = context.Teachers.ToList();

                    using (var package = new ExcelPackage(file))
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Teachers");

                        // Add header row
                        worksheet.Cells[1, 1].Value = "TeacherID";
                        worksheet.Cells[1, 2].Value = "Name";
                        worksheet.Cells[1, 3].Value = "Email";
                        worksheet.Cells[1, 4].Value = "Password";

                        // Add data rows
                        int row = 2;
                        foreach (var teacher in listOfTeachers)
                        {
                            worksheet.Cells[row, 1].Value = teacher.TeacherId;
                            worksheet.Cells[row, 2].Value = teacher.Name;
                            worksheet.Cells[row, 3].Value = teacher.Email;
                            worksheet.Cells[row, 4].Value = teacher.Password;
                            row++;
                        }

                        package.Save();
                    }

                    MessageBox.Show("Save list of teacher to excel file successfully !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving the list of stars to Excel file: " + ex.Message);
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

                    if(errorMessage != "")
                    {
                        MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        using (var package = new ExcelPackage(new FileInfo(filePath)))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first sheet
                            int rowCount = worksheet.Dimension.Rows;
                            List<Teacher> teachersToImport = new List<Teacher>();
                            for (int row = 2; row <= rowCount; row++) // Assuming row 1 contains headers
                            {
                                teachersToImport.Add(new Teacher
                                {
                                    // Assuming your Star class has properties like Name, Type, etc.
                                    TeacherId = worksheet.Cells[row, 1].Value?.ToString(),
                                    Name = worksheet.Cells[row, 2].Value?.ToString(),
                                    Email = worksheet.Cells[row, 3].Value?.ToString(),
                                    Password = worksheet.Cells[row, 4].Value?.ToString()
                                    // Add more properties as needed
                                });
                            }

                            context.Teachers.AddRange(teachersToImport);
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
    }

}
