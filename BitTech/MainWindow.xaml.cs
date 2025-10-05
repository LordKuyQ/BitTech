using BitTech.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BitTech
{
    public partial class MainWindow : Window
    {
        private readonly Database _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new Database();
        }

        private void AddRequestClick(object sender, RoutedEventArgs e)
        {
            AddRequestWindow addRequestWindow = new AddRequestWindow();
            if (addRequestWindow.ShowDialog() != true)
            { 
                return; 
            }

            try
            {
                using (var context = new Database())
                {
                    context.Requests.Add(addRequestWindow.Request);
                    context.SaveChanges();
                    MessageBox.Show("Заявка добавлена");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }

           
        }
    } 
}
