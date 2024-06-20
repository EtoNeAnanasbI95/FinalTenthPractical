using System.Windows;
using System.Windows.Input;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View.PAGES;
using FinalTenthPractical.View.USERCONTROLS;
using WpfApp1;

namespace FinalTenthPractical.View.WINDOWS;

/// <summary>
///     Логика взаимодействия для Doctor.xaml
/// </summary>
public partial class DoctorWindow : Window
{
    public DoctorWindow()
    {
        InitializeComponent();

        var first = new DoctorRightContril();
        first.TBLfio.Text = "Пушкин Илья Александрович";
        first.TBLtime.Text = "10:00";

        var second = new DoctorRightContrilEnd();
        first.TBLfio.Text = "Турунцев Ленька Сергеевич";
        first.TBLtime.Text = "12:30";

        var th = new DoctorRightContrilTime();
        first.TBLfio.Text = "Кириллов Димка Сергеевич";
        first.TBLtime.Text = "09:00";

        var users = new List<object> { first, second, th };
        LB.ItemsSource = users;

        FrameDoc.Navigate(new DoctorPage());
    }

    private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void ChangeTheme(object sender, RoutedEventArgs e)
    {
        if (Settings.Default.CurrentTheme == "Dark")
            App.Theme = "Light";
        else
            App.Theme = "Dark";
    }

    private void RollUpButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
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
        Close();
    }

    private void ExitClick(object sender, RoutedEventArgs e)
    {
        Settings.Default.CurrentDoctor = 0;
        Settings.Default.Save();
        var window = new AuthorizationWindow();
        window.Show();
        Close();
    }
}