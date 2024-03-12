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
    /// Interaction logic for WorkPopup.xaml
    /// </summary>
    public partial class WorkPopup : Window
    {
        public AttendanceDBContext context;
        public WorkPopup(string ClassId)
        {
            InitializeComponent();
            context = new AttendanceDBContext();
            tbClassId.Text = ClassId;
        }

        public void LoadData()
        {
            var listOfWork = context.Works.Where(w => w.ClassId.Equals(tbClassId.Text)).ToList();

            lvWorksInClass.ItemsSource = listOfWork;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public Work CheckWorkId()
        {
            if (string.IsNullOrEmpty(tbWorkId.Text))
            {
                return null;
            }else return context.Works.FirstOrDefault(x => x.WorkId == int.Parse(tbWorkId.Text));
        }

        public string Validation()
        {
            string errorMessage = "";
            if (string.IsNullOrEmpty(tbWorkName.Text))
            {
                errorMessage += "WorkName is a required field\n";
            }

            if (string.IsNullOrEmpty(tbDescription.Text))
            {
                errorMessage += "Description is a required field\n";
            }

            return errorMessage;
        }

        public Work GetWorkFromUI()
        {
            Work work = new Work();
            work.ClassId = tbClassId.Text;
            work.WorkName = tbWorkName.Text;
            work.Description = tbDescription.Text;
            return work;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = Validation();
            if (CheckWorkId() != null)
            {
                errorMessage += "WorkId is a duplicate id\n";
            }

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Work work = GetWorkFromUI();
                context.Works.Add(work);
                context.SaveChanges();
                LoadData();
                MessageBox.Show($"Add student with id of {work.WorkId} Successfully !!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = Validation();
                Work oldWork = CheckWorkId();
                if (oldWork == null)
                {
                    errorMessage += "Work is not found\n";
                }



                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Work newWork = GetWorkFromUI();
                    oldWork.WorkName = newWork.WorkName;
                    oldWork.Description = newWork.Description;
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show($"Update student with id of {oldWork.WorkId} Successfully !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                if (string.IsNullOrEmpty(tbWorkId.Text))
                {
                    errorMessage += "WorkId is a required field\n";
                }

                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int WorkId = int.Parse(tbWorkId.Text);
                    Work deleWork = CheckWorkId();

                    List<StudentWorkProgress> deleStudentWorkProgress1 = context.StudentWorkProgresses.Where(x => x.WorkId == WorkId).ToList();
                    List<StudentWorkProgress> deleStudentWorkProgress = context.StudentWorkProgresses.Where(x => x.WorkId == WorkId).ToList();
                    foreach (StudentWorkProgress swp in deleStudentWorkProgress)
                    {
                        MessageBox.Show(swp.ProgressId.ToString());
                        MessageBox.Show(swp.StudentId);
                    }

                    //context.Works.Remove(deleWork);
                    //context.SaveChanges();
                    LoadData();
                    MessageBox.Show($"Delete student with id of {WorkId} Successfully !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbWorkId.Clear();
            tbSearch.Clear();
            tbWorkName.Clear();
            tbDescription.Clear();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
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
                    var listOfWork = context.Works.Where(w => w.ClassId.Equals(tbClassId.Text));
                    var searchResult = listOfWork.Where(w => w.WorkName.Contains(tbSearch.Text) || w.Description.Contains(tbSearch.Text)).ToList();
                    lvWorksInClass.ItemsSource = searchResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
