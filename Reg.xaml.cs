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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var context = new AppDbContext();

            if (context.Users.FirstOrDefault(x => x.Login == TB_Reg_Log.Text) != null)
            {
                MessageBox.Show("Такой пользователь уже есть");
            }
            else
            {
                if (TB_Reg_Pas.Text == TB_Reg_PasAgain.Text)
                {
                    context.Users.Add(new User { Login = TB_Reg_Log.Text, Password = TB_Reg_Pas.Text });
                    context.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрировались");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Пароль повторен неправилно");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
