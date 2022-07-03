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
using Exam2.Entities;
using Exam2.Classes;

namespace Exam2.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnEntry_Click(object sender, RoutedEventArgs e)
        {
            int human = 0;
            int count = 0;
            int success = 0;
            Request history = new Request();
            foreach (var user in Connection.dataBase.Account)
            {
                count++;
                if (tbLogin.Text == user.Login && pbPassword.Password == user.Password && user.ID_Access_level == 2)
                {
                    Manager.frmStart.Navigate(new ContentManagePage());
                    count = 0;
                    success = 1;
                    human = user.ID_User;
                    break;
                }
                if (tbLogin.Text == user.Login && pbPassword.Password == user.Password && user.ID_Access_level == 4)
                {
                    Manager.frmStart.Navigate(new LoginHistoryPage());
                    count = 0;
                    success = 1;
                    human = user.ID_User;
                    break;
                }
            }
            if (count != 0)
                MessageBox.Show("Неправильный логин или пароль!");
            if (success == 1)
            {
                try
                {
                    history.ID_User = human;
                    history.Time = DateTime.Now;
                    Connection.dataBase.Request.Add(history);
                    Connection.dataBase.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления данных об успешном входе!");
                }
            }
        }
    }
}
