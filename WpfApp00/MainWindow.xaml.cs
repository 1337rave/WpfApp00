using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace StudentManagement
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Student> students = new ObservableCollection<Student>();

        public MainWindow()
        {
            InitializeComponent();
            lstStudents.ItemsSource = students;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                students.Add(new Student { Name = name });
                txtName.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a student name.");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstStudents.SelectedItem != null)
            {
                students.Remove((Student)lstStudents.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }

        private void BtnAddGrade_Click(object sender, RoutedEventArgs e)
        {
            if (lstStudents.SelectedItem != null)
            {
                if (int.TryParse(txtGrade.Text, out int grade))
                {
                    ((Student)lstStudents.SelectedItem).Grades.Add(grade);
                    txtGrade.Clear();
                }
                else
                {
                    MessageBox.Show("Please enter a valid grade.");
                }
            }
            else
            {
                MessageBox.Show("Please select a student to add grade.");
            }
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public ObservableCollection<int> Grades { get; set; } = new ObservableCollection<int>();
    }
}
