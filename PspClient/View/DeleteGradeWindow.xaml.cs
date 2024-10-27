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
    /// Логика взаимодействия для DeleteGradeWindow.xaml
    /// </summary>
    public partial class DeleteGradeWindow : Window
    {
        public DeleteGradeWindow()
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
                    if (int.TryParse(DeleteGradeIDInput.Text, out int GradeID))
                    {
                        var response = await client.DeleteAsync($"https://localhost:7008/api/Grade/delete/{GradeID}");

                        if (response.IsSuccessStatusCode)
                            MessageBox.Show("Оценка успешно удалена.");
                        else
                        {
                            string errorMessage = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Ошибка удаления оценки: {errorMessage}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите корректный ID оценки для удаления.");
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
