using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Praktick_Krylov
{
    /// <summary>
    /// Логика взаимодействия для Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
        int UserId = 0;
        public Shop(int id)
        {
            UserId = id; 
            InitializeComponent();
            var abc = new AppDbContext();
            ListOfTovar.ItemsSource = abc.Tovar.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var abc = new AppDbContext();
            int TovarId = abc.Tovar.SingleOrDefault(x => x.Id == ListOfTovar.SelectedIndex + 1).Id;
            abc.Korzina.Add(new Korzina { User = UserId, Tovar = TovarId, Kolvo = 1 });
            abc.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            personal_account personal_Account = new personal_account();
            personal_Account.Show();
            this.Hide();
        }
    }
}
