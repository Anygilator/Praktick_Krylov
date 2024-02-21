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
       public int ShopperId {  get; set; }
        public Shop()
        {
            InitializeComponent();
            var abc = new AppDbContext();
            ListOfTovar.ItemsSource = abc.Tovar.ToList();
        }

        private void ListOfTovar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void AAAda(object sender, MouseButtonEventArgs e)
        {
            var abc = new AppDbContext();
            abc.Korzina.Add(new Korzina { User = ShopperId, Tovar = ListOfTovar.SelectedIndex });
        }
    }
}
