using System.Windows;
using System.Windows.Controls;
using FinalTenthPractical.Properties;
using WpfApp1;

namespace FinalTenthPractical.View.PAGES;

/// <summary>
///     Логика взаимодействия для Settings.xaml
/// </summary>
public partial class PatientSettingsPage : Page
{
    public PatientSettingsPage()
    {
        InitializeComponent();
    }

    private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = sender as ComboBox;
        if (comboBox != null)
        {
            var selectedItem = comboBox.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                var selectedTheme = selectedItem.Content.ToString();
                if (selectedTheme == "Светлая")
                    App.Theme = "Light";
                else if (selectedTheme == "Темная") App.Theme = "Dark";
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