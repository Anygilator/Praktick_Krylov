using Microsoft.VisualBasic.ApplicationServices;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для PA.xaml
    /// </summary>
    public partial class PA : Window
    {
        int user = 0;
        public PA(int id)
        {
            InitializeComponent();
            var con = new AppDbContext();
            user = id;
            MainWindow mainWindow = new MainWindow();

            Korzina.ItemsSource = con.Korzina.Where(x => x.User == user).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Katalog katalog = new Katalog(user);
            katalog.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var con = new AppDbContext();
            var sum = con.Korzina.Where(x => x.User == user).Sum(x => x.Stoimost * x.Kolvo);
            MessageBox.Show("К оплате " + sum + "$");
            con.Tovar.FirstOrDefault(x => x.Id == con.Korzina.FirstOrDefault(x => x.User == user).TovaraIdishnik).Kolvo -= con.Korzina.FirstOrDefault(x => x.User == user).Kolvo;
            con.SaveChanges();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var con = new AppDbContext();
            var Deletethis = con.Korzina.FirstOrDefault(x => x.TovaraIdishnik == con.Korzina.FirstOrDefault(x => x.User == user).TovaraIdishnik);
            if (Deletethis != null)
            {
            con.Korzina.Remove((Korzina)Deletethis);
            con.SaveChanges();
            Korzina.ItemsSource = con.Korzina.Where(x => x.User == user).ToList();
            }
            else
            {
                MessageBox.Show("Элемент не найден");
            }
        }
    }
}
