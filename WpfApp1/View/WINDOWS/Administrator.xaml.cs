using FinalTenthPractical.View.PAGES;
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
using FinalTenthPractical.Properties;
using WpfApp1;

namespace FinalTenthPractical.View
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Window
    {
        public Administrator()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Autorized auth = new Autorized();
            auth.Show();
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            {
                if (WindowState == WindowState.Normal)
                    WindowState = WindowState.Maximized;
                else
                    WindowState = WindowState.Normal;
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OnPageSelector(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                switch (selectedItem.Content.ToString())
                {
                    case "Пользователь":
                        FrameAdmin.Navigate(new AdminPatient());
                        break;
                    case "Сотрудник":
                        FrameAdmin.Navigate(new AdminDoctor());
                        break; 
                    case "Администратор":
                        FrameAdmin.Navigate(new AdminAdministrator());
                        break;
                }
            }
        }
        
        private void KNOPKA(object sender, RoutedEventArgs e)
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
    }
}
