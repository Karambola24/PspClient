using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using PspClient;

namespace PspClient.View
{
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow()
        {
            InitializeComponent();
        
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Считывание и валидация данных
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(GroupNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(MajorTextBox.Text) ||
                !int.TryParse(CourseTextBox.Text, out int course) || course < 1 || course > 6 ||
                !int.TryParse(SemesterTextBox.Text, out int semester) || semester < 1 || semester > 12)
            {
                MessageBox.Show("Проверьте правильность введенных данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Создание объекта студента
            var student = new
            {
                Full_name = FullNameTextBox.Text,
                Group_name = GroupNameTextBox.Text,
                Major = MajorTextBox.Text,
                Course = course,
                Semester = semester
            };

            // Отправка данных на сервер
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7008/");
                    var json = JsonConvert.SerializeObject(student);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/Student/add", content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Студент успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Не удалось добавить студента: {errorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
