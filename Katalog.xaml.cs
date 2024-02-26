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
    /// Логика взаимодействия для Katalog.xaml
    /// </summary>
    public partial class Katalog : Window
    {
        int UserId = 0;
        public Katalog(int id)
        {
            UserId = id;
            InitializeComponent();
            var abc = new AppDbContext();
            ListOfTovar.ItemsSource = abc.Tovar.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var abc = new AppDbContext();
            string Tovar = abc.Tovar.SingleOrDefault(x => x.Id == ListOfTovar.SelectedIndex + 1).Nazv;
            int IDTovar = abc.Tovar.SingleOrDefault(x => x.Id == ListOfTovar.SelectedIndex + 1).Id;
            int Kolvo = abc.Tovar.SingleOrDefault(x => x.Id == ListOfTovar.SelectedIndex + 1).Kolvo;
            string Pic = abc.Tovar.SingleOrDefault(x => x.Id == ListOfTovar.SelectedIndex + 1).Pic;
            int stoimost = abc.Tovar.SingleOrDefault(x => x.Id == ListOfTovar.SelectedIndex + 1).Stoimost;
            abc.Korzina.Add(new Korzina { User = UserId, Nazv = Tovar, Kolvo = Convert.ToInt32(Tb_Kolvo.Text), Pic = Pic, Stoimost = stoimost,TovaraIdishnik = IDTovar });
            abc.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PA personal_Account = new PA(UserId);
            personal_Account.Show();
            this.Hide();
        }
    }
}
