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
    /// Логика взаимодействия для ContentAddEditPage.xaml
    /// </summary>
    public partial class ContentAddEditPage : Page
    {
        private User currentUser = new User();
        public ContentAddEditPage(User selectedUser)
        {
            InitializeComponent();
            if (selectedUser != null)
                currentUser = selectedUser;
            DataContext = currentUser;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(currentUser.First_name))
                errors.AppendLine("Введите имя!");
            if (string.IsNullOrWhiteSpace(currentUser.Last_name))
                errors.AppendLine("Введите фамилию!");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
                if (currentUser.ID_User == 0)
                    Connection.dataBase.User.Add(currentUser);
                try
                {
                    Connection.dataBase.SaveChanges();
                    Manager.frmStart.GoBack();
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления или изменения данных!");
                }
        }
    }
}
