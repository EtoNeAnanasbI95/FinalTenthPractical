using System.Timers;
using System.Windows;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View;
using FinalTenthPractical.View.WINDOWS;
using WpfApp1.ViewModel;
using WpfApp1.ViewModel.ApiHelper;
using Timer = System.Timers.Timer;

namespace WpfApp1;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class Load : Window
{
    private Timer timer;

    public Load()
    {
        InitializeComponent();
        // Settings.Default.CurrentPatient = 0;
        // Settings.Default.Save();
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        MainViewModel.Appointments = ApiHelper.Get<List<Appointment>>("Appointments");
        MainViewModel.Doctors = ApiHelper.Get<List<Doctor>>("Doctors");
        MainViewModel.AnalysDocuments = ApiHelper.Get<List<AnalysDocument>>("AnalysDocuments");
        MainViewModel.LoadUsers();
        timer = new Timer(700);
        timer.Elapsed += Timer_Elapsed;
        timer.AutoReset = false;
        timer.Start();
    }

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        Dispatcher.Invoke(() =>
        {
            if (Settings.Default.CurrentPatient != 0)
            {
                var window = new PatientWindow();
                window.Show();
                Close();
            }
            else if (Settings.Default.CurrentDoctor != 0)
            {
                var window = new DoctorWindow();
                window.Show();
                Close();
            }
            else if (Settings.Default.CurrentAdmin != 0)
            {
                var window = new AdministratorWindow();
                window.Show();
                Close();
            }
            else
            {
                var authorizedWindow = new AuthorizationWindow();
                authorizedWindow.Show();
                Close();
            }
        });
    }
}