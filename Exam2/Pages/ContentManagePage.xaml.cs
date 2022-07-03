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
using Exam2.Classes;
using Exam2.Entities;

namespace Exam2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContentManagePage.xaml
    /// </summary>
    public partial class ContentManagePage : Page
    {
        public ContentManagePage()
        {
            InitializeComponent();
        }

        private void dgContent_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Connection.dataBase.ChangeTracker.Entries().ToList().ForEach(page => page.Reload());
            dgContent.ItemsSource = Connection.dataBase.User.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.frmStart.Navigate(new ContentAddEditPage((sender as Button).DataContext as User));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.frmStart.Navigate(new ContentAddEditPage(null));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = dgContent.SelectedItems.Cast<User>().ToList();
            try
            {
                Connection.dataBase.User.RemoveRange(usersForRemoving);
                Connection.dataBase.SaveChanges();
                dgContent.ItemsSource = Connection.dataBase.User.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка удаления!");
            }
        }
    }
}
