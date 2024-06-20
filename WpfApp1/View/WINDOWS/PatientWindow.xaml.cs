using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Navigation;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View.PAGES;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View;

/// <summary>
///     Логика взаимодействия для Patient.xaml
/// </summary>
public partial class PatientWindow : Window
{
    private PatientSettingsViewModel _viewModel;
    
    public PatientWindow()
    {
        InitializeComponent();

        Frame.Content = new PatientAppointmentPage(Frame);
        MinWidth = 718;
        MinHeight = 472;
        CurrentUser.ItemsSource = MainViewModel.Users;
        CurrentUser.SelectedItem = MainViewModel.Users.Find(item => item.Oms == Settings.Default.CurrentPatient);
        _viewModel = new PatientSettingsViewModel(Frame);
        DataContext = _viewModel;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var auth = new AuthorizationWindow();
        Close();
    }

    private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }
    
    private void RollUpButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
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

    private void Button_Settings(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(new PatientSettingsPage());
    }

    private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (e.NewValue is TreeViewItem selectedItem)
            switch (selectedItem.Header)
            {
                case "Приёмы":
                    Frame.Navigate(new PatientAppointmentDocumentsPage());
                    break;
                case "Анализы":
                    Frame.Navigate(new PatientAnalysDocumentsPage());
                    break;
                case "Исследования":
                    Frame.Navigate(new PatientResearchDocumentsPage());
                    break;
                case "Записи и направления":
                    Frame.Navigate(new PatientAppointmentPage(Frame));
                    break;
            }
    }

    private void PatientWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        //_viewModel.LoadData();
    }
}