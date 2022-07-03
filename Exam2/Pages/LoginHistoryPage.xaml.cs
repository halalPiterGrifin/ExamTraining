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
    /// Логика взаимодействия для LoginHistoryPage.xaml
    /// </summary>
    public partial class LoginHistoryPage : Page
    {
        public LoginHistoryPage()
        {
            InitializeComponent();
        }

        private void dgHistory_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Connection.dataBase.ChangeTracker.Entries().ToList().ForEach(page => page.Reload());
            dgHistory.ItemsSource = Connection.dataBase.Request.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.frmStart.Navigate(new HistoryAddEditPage((sender as Button).DataContext as Request));
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.frmStart.Navigate(new HistoryAddEditPage(null));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var historysForRemoving = dgHistory.SelectedItems.Cast<Request>().ToList();
            try
            {
                Connection.dataBase.Request.RemoveRange(historysForRemoving);
                Connection.dataBase.SaveChanges();
                dgHistory.ItemsSource = Connection.dataBase.Request.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка удаления!");
            }
        }
    }
}
