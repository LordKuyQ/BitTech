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
using BitTech.Models;

namespace BitTech
{
    public partial class Authorization : Window
    {
        private readonly Database _context;
        public Authorization()
        {
            InitializeComponent();
            _context = new Database();
        }

        private void EnterClick(object sender, RoutedEventArgs e)
        {

            try
            {
                using (var context = new Database())
                {                    
                    var Masters = context.Masters.Where(x => x.Login == Login.Text && x.Password == Password.Text).Any();
                    var Operators = context.Operators.Where(x => x.Login == Login.Text && x.Password == Password.Text).Any();
                    var Clients = context.Clients.Where(x => x.Login == Login.Text && x.Password == Password.Text).Any();

                    if (Masters)
                    {
                        MainWindow masterMainWindow = new MainWindow();
                        masterMainWindow.Show();
                        this.Close();
                    }
                    else if (Operators)
                    {
                        OperatorWindow managerMainWindow = new OperatorWindow();
                        managerMainWindow.Show();
                        this.Close();
                    }
                    else if (Clients)
                    {
                        MainWindow clientMainWindow = new MainWindow();
                        clientMainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }


        }
    }
}
