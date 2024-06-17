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
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow()
        {
            InitializeComponent();
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
                        FrameAdmin.Navigate(new PAGES.AdminPatientLBPage());
                        break;
                    case "Сотрудник":
                        FrameAdmin.Navigate(new PAGES.AdminDoctorLBPage());
                        break; 
                    case "Администратор":
                        FrameAdmin.Navigate(new PAGES.AdminPage());
                        break;
                }
            }
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UnwrapButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (WindowState == WindowState.Normal)
                    WindowState = WindowState.Maximized;
                else
                    WindowState = WindowState.Normal;
            }
        }
    }
}
