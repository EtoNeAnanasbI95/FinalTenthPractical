using System.Windows;
using System.Windows.Controls;
using FinalTenthPractical.Properties;
using WpfApp1;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View.PAGES;

/// <summary>
///     Логика взаимодействия для Settings.xaml
/// </summary>
public partial class PatientSettingsPage : Page
{
    private PatientSettingsViewModel _viewModel;
    
    public PatientSettingsPage()
    {
        InitializeComponent();
        _viewModel = new PatientSettingsViewModel();
        DataContext = _viewModel;
        
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

    private void PatientSettingsPage_OnLoaded(object sender, RoutedEventArgs e)
    { 
        _viewModel.LoadData();
    }

    private void NewAcc(object sender, RoutedEventArgs e)
    {
        var window = Window.GetWindow(this);
        AuthorizationWindow auth = new AuthorizationWindow();
        auth.Show();
        window.Close();
    }
}