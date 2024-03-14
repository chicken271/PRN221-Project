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
    /// Interaction logic for TakeAttendanceWindow.xaml
    /// </summary>
    public partial class TakeAttendanceWindow : Window
    {
        public AttendanceDBContext context;
        public TakeAttendanceWindow(String ClassID)
        {
            InitializeComponent();
            context = new AttendanceDBContext();
            tbClassId.Text = ClassID;
            dpDate.SelectedDate = DateTime.Today;
        }

        public void LoadData()
        {
            if (dpDate.SelectedDate != null)
            {
                var attendanceList = (from attendance in context.Attendances
                                      join student in context.Students on attendance.StudentId equals student.StudentId
                                      where attendance.ClassId == tbClassId.Text
                                      select new
                                      {
                                          AttendanceId = attendance.AttendanceId,
                                          StudentID = student.StudentId,
                                          StudentName = student.Name,
                                          Present = attendance.Present,
                                          DateAttend = attendance.DateAttended
                                      });

                lvAttendance.ItemsSource = attendanceList.Where(x => x.DateAttend == dpDate.SelectedDate).ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dpDate.SelectedDate != null)
            {
                var attendanceList = (from attendance in context.Attendances
                                      join student in context.Students on attendance.StudentId equals student.StudentId
                                      where attendance.ClassId == tbClassId.Text
                                      select new
                                      {
                                          AttendanceId = attendance.AttendanceId,
                                          StudentID = student.StudentId,
                                          StudentName = student.Name,
                                          Present = attendance.Present,
                                          DateAttend = attendance.DateAttended
                                      });

                lvAttendance.ItemsSource = attendanceList.Where(x => x.DateAttend == dpDate.SelectedDate).ToList();
            }
        }

        public Attendance CheckAttendanceDate()
        {
            return context.Attendances.FirstOrDefault(x => x.DateAttended == dpDate.SelectedDate);
        }

        public string Validation()
        {
            string errorMessage = "";
            if (string.IsNullOrEmpty(dpDate.SelectedDate.ToString()))
            {
                errorMessage += "Date is a required field\n";
            }

            return errorMessage;
        }

        public Attendance CreateAttendanceRow()
        {
            Attendance attendance = new Attendance();
            attendance.ClassId = tbClassId.Text;
            attendance.DateAttended = dpDate.SelectedDate;
            attendance.Present = false;
            return attendance;
        }

        public Attendance GetAttendanceFromUI()
        {
            Attendance attendance = new Attendance();
            attendance.AttendanceId = int.Parse(tbAttendanceId.Text);
            attendance.StudentId = tbStudentId.Text;
            attendance.ClassId = tbClassId.Text;
            attendance.DateAttended = dpDate.SelectedDate;
            attendance.Present = cbPresent.IsChecked;
            return attendance;
        }

        public Attendance GetAttendanceFromId()
        {
            return context.Attendances.FirstOrDefault(x => x.AttendanceId == int.Parse(tbAttendanceId.Text));
        }

        private void btnAddAll_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = Validation();
            if (CheckAttendanceDate() != null)
            {
                errorMessage += "Attendance Sheet is already added !!\n";
            }

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                List<BelongTo> BelongToList = context.BelongTos.Where(x => x.ClassId == tbClassId.Text).ToList();
                List<string> StudentIds = new List<string>();
                foreach(BelongTo bt in BelongToList)
                {
                    StudentIds.Add(bt.StudentId);
                }

                Attendance attendance;

                foreach (string studentId in StudentIds)
                {
                    MessageBox.Show(studentId);
                    attendance = CreateAttendanceRow();
                    attendance.StudentId = studentId;
                    context.Attendances.Add(attendance);
                    context.SaveChanges();
                }

                LoadData();
                MessageBox.Show($"Add attendance sheet with date of {dpDate.SelectedDate} Successfully !!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = Validation();
            if (String.IsNullOrEmpty(tbAttendanceId.Text))
            {
                errorMessage += "AttendanceId is a required field !!\n";
            }

            if(errorMessage != "")
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Attendance attendance = GetAttendanceFromUI();
                Attendance oldAttendance = GetAttendanceFromId();
                oldAttendance.Present = attendance.Present;
                context.SaveChanges();
                LoadData();
                MessageBox.Show($"Update Attendance with id of {oldAttendance.AttendanceId} Successfully !!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = Validation();
            if (CheckAttendanceDate() == null)
            {
                errorMessage += "Attendance Sheet is not added !!\n";
            }

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                context.Database.ExecuteSqlRaw(
                $"DELETE FROM Attendance WHERE DateAttended = '{dpDate.SelectedDate}';");
                context.SaveChanges();
                LoadData();
                MessageBox.Show($"Delete attendance sheet with date of {dpDate.SelectedDate} Successfully !!");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
