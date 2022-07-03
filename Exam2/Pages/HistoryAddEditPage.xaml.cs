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
    /// Логика взаимодействия для HistoryAddEditPage.xaml
    /// </summary>
    public partial class HistoryAddEditPage : Page
    {
        private Request currentRequest = new Request();
        public HistoryAddEditPage(Request selectedRequest)
        {
            InitializeComponent();
            if (selectedRequest != null)
                currentRequest = selectedRequest;
            DataContext = currentRequest;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (currentRequest.ID_User <= 0)
                errors.AppendLine("Введите идентификатор!");
            if (errors.Length > 0)
                MessageBox.Show(errors.ToString());
            else
            {
                try
                {
                    Connection.dataBase.Request.Add(currentRequest);
                    Connection.dataBase.SaveChanges();
                    Manager.frmStart.GoBack();
                }
                catch
                {
                    MessageBox.Show("Не удалось добавить или изменить данные!");
                }
            }
        }
    }
}
