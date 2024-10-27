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
    /// Логика взаимодействия для DeleteStudentWindow.xaml
    /// </summary>
    public partial class DeleteStudentWindow : Window
    {
        public DeleteStudentWindow()
        {
            InitializeComponent();
        
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7008/");
                    if (int.TryParse(DeleteStudentIDInput.Text, out int studentId))
                    {
                        var response = await client.DeleteAsync($"https://localhost:7008/api/Student/delete/{studentId}");

                        if (response.IsSuccessStatusCode)
                            MessageBox.Show("Студент успешно удален.");
                        else
                        {
                            string errorMessage = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Ошибка удаления студента: {errorMessage}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите корректный ID студента для удаления.");
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
