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
using FinalTenthPractical.Properties;
using WpfApp1;

namespace FinalTenthPractical.View.PAGES
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class PatientSettingsPage : Page
    {
        public PatientSettingsPage()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
                if (selectedItem != null)
                {
                    string selectedTheme = selectedItem.Content.ToString();
                    if (selectedTheme == "Светлая")
                    {
                        App.Theme = "Light";
                    }
                    else if (selectedTheme == "Темная")
                    {
                        App.Theme = "Dark";
                    }
                }
            }
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Settings.Default.CurrentPatient = 0;
            Settings.Default.Save();
            var auth = new AuthorizationWindow();
            auth.Show();
            var window = Window.GetWindow(this);
            window.Close();
        }
    }
}
    