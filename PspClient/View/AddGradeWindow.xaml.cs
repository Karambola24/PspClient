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

namespace PspClient.View
{
    /// <summary>
    /// Логика взаимодействия для AddGradeWindow.xaml
    /// </summary>
    public partial class AddGradeWindow : Window
    {
        public AddGradeWindow()
        {
            InitializeComponent();
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Считывание и валидация данных
            if (!int.TryParse(IDStudentTextBox.Text, out int ID_Student) || ID_Student < 1 ||
                !int.TryParse(IDDisciplineTextBox.Text, out int ID_Discipline) || ID_Discipline < 1 ||
                !int.TryParse(GradeValueTextBox.Text, out int Grade_value) || Grade_value < 1)
                
            {
                MessageBox.Show("Проверьте правильность введенных данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var grade = new
            {
                ID_Student = IDStudentTextBox.Text,
                Grade_value = GradeValueTextBox.Text,
                ID_Discipline = IDDisciplineTextBox.Text,
            };

            // Отправка данных на сервер
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7008/");
                    var json = JsonConvert.SerializeObject(grade);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/Grade/add", content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Оценка успешно добавлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Не удалось добавить оценку: {errorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
