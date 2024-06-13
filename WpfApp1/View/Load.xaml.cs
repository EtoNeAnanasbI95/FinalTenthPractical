using System.Text;
using System.Timers;
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
using FinalTenthPractical.View;
using WpfApp1.ViewModel;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Load : Window
{
    private System.Timers.Timer timer;

    public Load()
    {
        InitializeComponent();
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        timer = new System.Timers.Timer(100);
        timer.Elapsed += Timer_Elapsed;
        timer.AutoReset = false;
        timer.Start();
    }

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        Dispatcher.Invoke(() =>
        {
            var authorizedWindow = new AuthorizationWindow();
            authorizedWindow.Show();
            Close();
        });
    }
}


   
