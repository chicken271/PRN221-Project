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
    /// Interaction logic for StudentAttendance.xaml
    /// </summary>
    public partial class StudentAttendance : Window
    {
        public AttendanceDBContext context;
        public StudentAttendance(String ClassId)
        {
            InitializeComponent();
            context = new AttendanceDBContext();
            tbClassId.Text = ClassId;
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
            LoadData();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
