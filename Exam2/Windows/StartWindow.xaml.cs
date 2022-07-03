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
using Exam2.Classes;
using Exam2.Pages;

namespace Exam2.Windows
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            frmStart.Navigate(new LoginPage());
            Manager.frmStart = frmStart;
        }

        private void frmStart_ContentRendered(object sender, System.EventArgs e)
        {
            if (frmStart.CanGoBack)
                btnBack.Visibility = Visibility.Visible;
            else btnBack.Visibility = Visibility.Hidden;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.frmStart.GoBack();
        }
    }
}
