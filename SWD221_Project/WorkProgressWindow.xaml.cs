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
    /// Interaction logic for WorkProgressWindow.xaml
    /// </summary>
    public partial class WorkProgressWindow : Window
    {
        public AttendanceDBContext context;
        public WorkProgressWindow(String ClassID, String StudentID)
        {
            InitializeComponent();
            context = new AttendanceDBContext();
            tbClassId.Text = ClassID;
            tbStudentId.Text = StudentID;
        }

        public void LoadData()
        {
            var joinedList = (from work in context.Works
                              join progress in context.StudentWorkProgresses on work.WorkId equals progress.WorkId
                              where progress.StudentId == tbStudentId.Text
                              select new
                              {
                                  ProgressId = progress.ProgressId,
                                  StudentID = progress.StudentId,
                                  WorkID = work.WorkId,
                                  WorkName = work.WorkName,
                                  WorkDescription = work.Description,
                                  Complete = progress.Complete
                              }).ToList();

            //lvWorkProgress.ItemsSource = joinedList;

            lvWorkProgress.ItemsSource = joinedList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
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
                    string searchInput = tbSearch.Text;
                    var searchResult = (from work in context.Works
                                        join progress in context.StudentWorkProgresses on work.WorkId equals progress.WorkId
                                        where progress.StudentId == tbStudentId.Text
                                        select new
                                        {
                                            ProgressId = progress.ProgressId,
                                            StudentID = progress.StudentId,
                                            WorkID = work.WorkId,
                                            WorkName = work.WorkName,
                                            WorkDescription = work.Description,
                                            Complete = progress.Complete
                                        });
                    lvWorkProgress.ItemsSource = searchResult.Where( r => r.WorkName.Contains(searchInput) || r.WorkDescription.Contains(searchInput)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
