using BitTech.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace BitTech
{
    public partial class AddRequestWindow : Window
    {
        private readonly Database _context;
        public Request Request { get; set; } = new Request();
        public AddRequestWindow()
        {
            InitializeComponent();
            _context = new Database();
            Clients.ItemsSource = _context.Clients.ToList();
            Equipments.ItemsSource = _context.Equipment.ToList();
            DataContext = this;
        }

        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Clients.SelectedItem != null && StartDate.SelectedDate != null &&
                    Equipments.SelectedItem != null && Desc.Text != null &&
                    Statuses.SelectedItem != null)
                {
                    var selectedClient = Clients.SelectedItem as Client;
                    var selectedEquipment = Equipments.SelectedItem as Equipment;

                    Request = new Request
                    {
                        ClientId = selectedClient.UserId,
                        EquipmentId = selectedEquipment.Id,
                        StartDate = DateOnly.FromDateTime(StartDate.SelectedDate.Value),
                        RequestStatus = (Statuses.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                        ProblemDescryption = Desc.Text
                    };

                    if (EndDate.SelectedDate != null)
                        Request.CompletionDate = DateOnly.FromDateTime(EndDate.SelectedDate.Value);

                    DialogResult = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверные данные");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
