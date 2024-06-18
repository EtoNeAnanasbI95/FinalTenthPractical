using FinalTenthPractical.Properties;
using FinalTenthPractical.View.PAGES;
using FinalTenthPractical.View.USERCONTROLS;
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
using Spire.Doc.Documents;
using WpfApp1;

namespace FinalTenthPractical.View.WINDOWS
{
    /// <summary>
    /// Логика взаимодействия для Doctor.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public DoctorWindow()
        {
            InitializeComponent();

            DoctorRightContril first = new DoctorRightContril();
            first.TBLfio.Text = "Пушкин Илья Александрович";
            first.TBLtime.Text = "10:00";

            DoctorRightContrilEnd second = new DoctorRightContrilEnd();
            first.TBLfio.Text = "Турунцев Ленька Сергеевич";
            first.TBLtime.Text = "12:30";

            DoctorRightContrilTime th = new DoctorRightContrilTime();
            first.TBLfio.Text = "Кириллов Димка Сергеевич";
            first.TBLtime.Text = "09:00";

            List<Object> users = new List<Object>() { first, second, th };
            LB.ItemsSource = users;  

            FrameDoc.Navigate(new DoctorPage());
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();

        }

        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.CurrentTheme == "Dark")
            {
                App.Theme = "Light";
            }
            else
            {
                App.Theme = "Dark";
            }
        }

        private void RollUpButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }

        private void UnwrapButton_Click(object sender, RoutedEventArgs e)
        {

            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Settings.Default.CurrentDoctor = 0;
            Settings.Default.Save();
            AuthorizationWindow window = new AuthorizationWindow();
            window.Show();
            Close();
        }
    }
}
