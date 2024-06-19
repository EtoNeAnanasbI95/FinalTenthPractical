using System.Windows;
using System.Windows.Input;

namespace FinalTenthPractical.View;

/// <summary>
///     Логика взаимодействия для Autorized.xaml
/// </summary>
public partial class AuthorizationWindow : Window
{
    public AuthorizationWindow()
    {
        InitializeComponent();
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        FramePatientAutorize.NavigationService.Navigate(new AutorizationPatientpage());
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
    }

    private void Minimize_click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }
}