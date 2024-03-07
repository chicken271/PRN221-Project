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
    /// Interaction logic for ManageClass.xaml
    /// </summary>
    public partial class ManageClass : Window
    {
        public AttendanceDBContext context;
        public ManageClass()
        {
            InitializeComponent();
            context = new AttendanceDBContext();
        }

        public void LoadData()
        {
            lvClass.ItemsSource = context.Classes.ToList();
            cbTeacherId.ItemsSource = context.Teachers.Select(teacher => teacher.TeacherId).ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public Class CheckClassId()
        {
            return context.Classes.FirstOrDefault(x => x.ClassId == tbClassId.Text);
        }

        public string Validation()
        {
            string errorMessage = "";
            if (string.IsNullOrEmpty(tbClassId.Text))
            {
                errorMessage += "ClassId is a required field\n";
            }

            if (string.IsNullOrEmpty(tbClassName.Text))
            {
                errorMessage += "ClassName is a required field\n";
            }

            if (cbTeacherId.SelectedValue == null)
            {
                errorMessage += "TeacherId is a required value\n";
            }

            return errorMessage;
        }

        public Class GetClassFromUI()
        {
            Class classFromUI = new Class();
            classFromUI.ClassId = tbClassId.Text;
            classFromUI.TeacherId = cbTeacherId.SelectedValue.ToString();
            classFromUI.ClassName = tbClassName.Text;
            return classFromUI;
        }

        private void btnAddClass_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = Validation();
            if (CheckClassId() != null)
            {
                errorMessage += "ClassId is a duplicate id\n";
            }

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Class addClass = GetClassFromUI();
                context.Classes.Add(addClass);
                context.SaveChanges();
                LoadData();
                MessageBox.Show($"Add class with id of {addClass.ClassId} Successfully !!");
            }
        }

        private void btnUpdateClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = Validation();
                Class oldClass = CheckClassId();
                if (oldClass == null)
                {
                    errorMessage += "Class is not found\n";
                }

                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Class newClass = GetClassFromUI();
                    oldClass.TeacherId = newClass.TeacherId;
                    oldClass.ClassName = newClass.ClassName;

                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show($"Update class with id of {oldClass.ClassId} Successfully !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                if (string.IsNullOrEmpty(tbClassId.Text))
                {
                    errorMessage += "ClassId is a required field\n";
                }

                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string ClassId = tbClassId.Text;
                    Class deleClass = CheckClassId();

                    List<BelongTo> removeFromClass = context.BelongTos.Where(x => x.ClassId == ClassId).ToList();
                    foreach (BelongTo bt in removeFromClass)
                    {
                        MessageBox.Show(bt.StudentId);
                        MessageBox.Show(bt.ClassId);
                    }

                    //context.Classes.Remove(deleClass);
                    //context.SaveChanges();
                    LoadData();
                    MessageBox.Show($"Delete class with id of {ClassId} Successfully !!");
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
            tbClassId.Clear();
            tbClassName.Clear();
            cbTeacherId.SelectedValue = null;
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
                    string searchInput = tbSearch.Text;
                    var searchResult = context.Classes.Where(x => x.ClassId == searchInput || x.ClassName.Contains(tbSearch.Text) || x.TeacherId == searchInput).ToList();
                    lvClass.ItemsSource = searchResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnManageStudentInClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                Class oldClass = CheckClassId();
                if (string.IsNullOrEmpty(tbClassId.Text))
                {
                    errorMessage += "ClassId is a required fiedld\n";
                }

                if(oldClass == null)
                {
                    errorMessage += "Class is not found\n";
                }

                if(errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string ClassId = tbClassId.Text;
                    ClassPopup classPopup = new ClassPopup(ClassId);
                    classPopup.Show();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnManageWorkInClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage = "";
                Class oldClass = CheckClassId();
                if (string.IsNullOrEmpty(tbClassId.Text))
                {
                    errorMessage += "ClassId is a required fiedld\n";
                }

                if (oldClass == null)
                {
                    errorMessage += "Class is not found\n";
                }

                if (errorMessage != "")
                {
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string ClassId = tbClassId.Text;
                    WorkPopup workPopup = new WorkPopup(ClassId);
                    workPopup.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
