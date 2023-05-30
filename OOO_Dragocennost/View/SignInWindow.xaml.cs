using OOO_Dragocennost.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOO_Dragocennost.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        TradeContext context = new TradeContext();
        public SignInWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            User user = context.Users.FirstOrDefault(i => i.UserLogin == LoginText.Text && i.UserPassword == PasswordText.Password);
            if (user == null)
            {
                MessageBox.Show("Пользователя не существует");
            }
            else if (user.UserRole == 1)
            {
                new AdminWindow(user).Show();
                this.Close();
            }
            else if (user.UserRole == 2)
            {
                MessageBox.Show("Вы менеджер");
            }
            else if (user.UserRole == 3)
            {
                new ProductMenuWindow(user).Show();
                this.Close();
            }
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            new ProductMenuWindow().Show();
            this.Close();
        }
    }
}
