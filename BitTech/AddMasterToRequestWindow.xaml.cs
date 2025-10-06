using BitTech.Models;
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

namespace BitTech
{
    public partial class AddMasterToRequestWindow : Window
    {
        private readonly Database _context;
        private readonly Request _request;
        public Comment NewComment { get; private set; }
        public AddMasterToRequestWindow(Request request)
        {
            InitializeComponent();
            _context = new Database();
            _request = request;
            LoadMasters();
        }

        private void LoadMasters()
        {
            try
            {
                var masters = _context.Masters.ToList();
                comboBoxMasters.ItemsSource = masters;
                comboBoxMasters.DisplayMemberPath = "Fio";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки мастеров: {ex.Message}");
            }
        }

        private void AddMasterClick(object sender, RoutedEventArgs e)
        {
            if (comboBoxMasters.SelectedItem == null)
            {
                MessageBox.Show("Выберите мастера");
                return;
            }
            var selectedMaster = (Master)comboBoxMasters.SelectedItem;
            NewComment = new Comment
            {
                RequestId = _request.RequestId,
                MasterId = selectedMaster.Id,
                Message = textBoxComment.Text
            };
            DialogResult = true;
            Close();
        }

        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
