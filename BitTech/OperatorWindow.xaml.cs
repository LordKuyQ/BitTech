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
    public partial class OperatorWindow : Window
    {
        private readonly Database _context;
        public OperatorWindow()
        {
            InitializeComponent();
            _context = new Database();
            LoadRequests();
        }
    

        private void LoadRequests()
        {
            try
            {
                using (var context = new Database())
                {
                    var requests = context.Requests
                         .Include(r => r.Client)
                         .Include(r => r.Comments)
                            .ThenInclude(c => c.Master)
                         .Include(r => r.DetailRequests)
                             .ThenInclude(dr => dr.Detail)
                         .Include(r => r.Equipment)
                         .OrderBy(r => r.RequestId)
                         .ToList();

                    listBoxRequests.ItemsSource = requests;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
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
                    LoadRequests();
                    MessageBox.Show("Заявка добавлена");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }

           
        }

        private void AddMasterToRequestClick(object sender, RoutedEventArgs e)
        {
            if (listBoxRequests.SelectedItem == null)
            {
                MessageBox.Show("Выберите заявку для добавления мастера.");
                return;
            }

            var selectedRequest = (Request)listBoxRequests.SelectedItem;

            AddMasterToRequestWindow addMasterWindow = new AddMasterToRequestWindow(selectedRequest);
            if (addMasterWindow.ShowDialog() == true)
            {
                try
                {
                    using (var context = new Database())
                    {
                        context.Comments.Add(addMasterWindow.NewComment);
                        context.SaveChanges();
                        LoadRequests();
                        MessageBox.Show("Мастер добавлен к заявке.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении мастера: {ex.Message}");
                }
            }
        }
    } 
}
