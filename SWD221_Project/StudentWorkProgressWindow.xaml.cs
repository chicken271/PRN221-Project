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
    /// Interaction logic for StudentWorkProgressWindow.xaml
    /// </summary>
    public partial class StudentWorkProgressWindow : Window
    {
        public AttendanceDBContext context;
        public StudentWorkProgressWindow(string StudentId, string ClassId)
        {
            InitializeComponent();
            context = new AttendanceDBContext();
            tbStudentId.Text = StudentId;
            tbClassId.Text = ClassId;
        }

        public void LoadData()
        {
            var joinedList = (from work in context.Works
                              join progress in context.StudentWorkProgresses on work.WorkId equals progress.WorkId
                              where progress.StudentId == tbStudentId.Text && work.ClassId == tbClassId.Text
                              select new
                              {
                                  ProgressId = progress.ProgressId,
                                  StudentID = progress.StudentId,
                                  WorkID = work.WorkId,
                                  WorkName = work.WorkName,
                                  WorkDescription = work.Description,
                                  Complete = progress.Complete
                              }).ToList();

            lvWorkProgress.ItemsSource = joinedList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public StudentWorkProgress GetStudentWorkProgressById()
        {
            return context.StudentWorkProgresses.FirstOrDefault(s => s.ProgressId == int.Parse(tbWorkId.Text));
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                if (string.IsNullOrEmpty(tbWorkId.Text))
                {
                    errorMessage = "WorkId is a required field !!";
                }

                if(errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    StudentWorkProgress studentWorkProgress = new StudentWorkProgress();
                    studentWorkProgress.ProgressId = int.Parse(tbWorkId.Text);
                    studentWorkProgress.Complete = cbComplte.IsChecked;
                    StudentWorkProgress newStudentWorkProgress = GetStudentWorkProgressById();
                    newStudentWorkProgress.Complete = studentWorkProgress.Complete;
                    context.SaveChanges();
                    LoadData();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public StudentWorkProgress CreateStudentWorkProgressRow()
        {
            StudentWorkProgress newStudentWorkProgress = new StudentWorkProgress();
            newStudentWorkProgress.StudentId = tbStudentId.Text;
            newStudentWorkProgress.Complete = false;
            return newStudentWorkProgress;
        }

        public bool CheckDupplicateId(List<int> list, Work studentWork)
        {
            foreach(int i in list)
            {
                if(studentWork.WorkId == i)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Work> WorkInClass = context.Works.Where(w => w.ClassId == tbClassId.Text).ToList();
                List<StudentWorkProgress> list = new List<StudentWorkProgress>();
                List<int> WorkIdDupplicate = new List<int>();
                

                var joinedList = (from work in context.Works
                                  join progress in context.StudentWorkProgresses on work.WorkId equals progress.WorkId
                                  where progress.StudentId == tbStudentId.Text && work.ClassId == tbClassId.Text
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

                foreach (var item in joinedList)
                {
                    WorkIdDupplicate.Add(item.WorkID);
                }

                lvWorkProgress.ItemsSource = joinedList.Where(l => l.ClassID == tbClassId.Text);

                foreach (Work work in WorkInClass)
                {
                    StudentWorkProgress newStudentWorkProgress = CreateStudentWorkProgressRow();
                    newStudentWorkProgress.WorkId = work.WorkId;
                    if(CheckDupplicateId(WorkIdDupplicate, work) == false)
                    {
                        list.Add(newStudentWorkProgress);
                    }
                }



                if (list.Count > 0)
                {
                    context.StudentWorkProgresses.AddRange(list);
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show($"Added all work from Class {tbClassId.Text} !!");
                }
                else { MessageBox.Show($"The Class {tbClassId.Text} has no available work !!"); }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
