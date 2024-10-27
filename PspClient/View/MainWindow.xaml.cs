using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using PspClient.View;

namespace PspClient
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void BtnShowStudents_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Создание HttpClient и указание базового адреса API
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7008/");

                    HttpResponseMessage response = await client.GetAsync("api/Student");

                    if (response.IsSuccessStatusCode)
                    {
                      
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var students = JsonConvert.DeserializeObject<List<Student>>(jsonResponse);

                        StudentDataGrid.ItemsSource = students;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при получении данных студентов: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void OpenAddStudentWindow(object sender, RoutedEventArgs e)
        {
            AddStudentWindow addStudentWindow = new AddStudentWindow();
            addStudentWindow.ShowDialog();
        }

        private void OpenDeleteStudentWindow(object sender, RoutedEventArgs e)
        {
            DeleteStudentWindow deleteStudentWindow = new DeleteStudentWindow();
            deleteStudentWindow.ShowDialog();
        }

        private async void BtnShowDisciplines_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7008/");

                    HttpResponseMessage response = await client.GetAsync("api/Discipline");

                    
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var disciplines = JsonConvert.DeserializeObject<List<Discipline>>(jsonResponse);

                        DisciplineDataGrid.ItemsSource = disciplines;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при получении данных дисциплин: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void OpenAddDisciplineWindow(object sender, RoutedEventArgs e)
        {
            AddDisciplineWindow addDisciplineWindow = new AddDisciplineWindow();
            addDisciplineWindow.ShowDialog();
        }

        private void OpenDeleteDisciplineWindow(object sender, RoutedEventArgs e)
        {
            DeleteDisciplineWindow deleteDisciplineWindow = new DeleteDisciplineWindow();
            deleteDisciplineWindow.ShowDialog();
        }

        private async void BtnShowGrade_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7008/");
                    HttpResponseMessage response = await client.GetAsync("api/Grade");

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var grades = JsonConvert.DeserializeObject<List<Grade>>(jsonResponse);

                        GradeDataGrid.ItemsSource = grades;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при получении данных оценок: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void OpenDeleteGradeWindow(object sender, RoutedEventArgs e)
        {
            DeleteGradeWindow deleteGradeWindow = new DeleteGradeWindow();
            deleteGradeWindow.ShowDialog();
        }

        private void OpenAddGradeWindow(object sender, RoutedEventArgs e)
        {
            AddGradeWindow addGradeWindow = new AddGradeWindow();
            addGradeWindow.ShowDialog();
        }


        private async void TopStudentsPercentageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7008/");
                    HttpResponseMessage response = await client.GetAsync("api/Student/top-students-percentage");
                    if (response.IsSuccessStatusCode)
                    {
                        var percentage = await response.Content.ReadAsStringAsync();
                        TopPercentageTextBlock.Text = $"{percentage}%";
                        MessageBox.Show($"Процент отличников: {percentage}%", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Не удалось выполнить действие: {errorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private async void StrugglingStudentsPercentageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7008/");
                    HttpResponseMessage response = await client.GetAsync("api/Student/struggling-students-percentage");
                    if (response.IsSuccessStatusCode)
                    {
                        var percentage = await response.Content.ReadAsStringAsync();
                        StrugglingPercentageTextBlock.Text = $"{percentage}%";
                        MessageBox.Show($"Процент отсающих студентов: {percentage}%", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Не удалось выполнить действие: {errorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



    }


    public class Student
    {
        public int ID_Student { get; set; }
        public string Full_name { get; set; }
        public string Major { get; set; }
        public string Course { get; set; }
        public string Semester { get; set; }
        public string Group_name { get; set; }
    }


    public class Discipline
    {
        public int ID_Discipline { get; set; }
        public string Name { get; set; }
    }

    public class Grade
    {
        public int ID_Grade { get; set; }
        public int ID_Student { get; set; }
        public int Grade_value { get; set; }
        public int ID_Discipline { get; set; }

    }

}


