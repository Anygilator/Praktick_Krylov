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

namespace Praktick_Krylov
{
    /// <summary>
    /// Логика взаимодействия для personal_account.xaml
    /// </summary>
    public partial class personal_account : Window
    {
        public personal_account()
        {
            MainWindow mainWindow = new MainWindow();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Shop shop = new Shop();
            shop.Show();
            this.Hide();
            
        }
    }
}
