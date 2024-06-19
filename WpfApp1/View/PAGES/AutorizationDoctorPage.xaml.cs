using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using FinalTenthPractical.View.WINDOWS;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View;

/// <summary>
///     Логика взаимодействия для FrameAutorizedDoctor.xaml
/// </summary>
public partial class AutorizationDoctorPage : Page
{
    private readonly DoctorViewModel _doctorViewModel;

    public AutorizationDoctorPage()
    {
        InitializeComponent();
        _doctorViewModel = new DoctorViewModel();
        _doctorViewModel.GoDoctor += (_, _) => GoDoctor();
        _doctorViewModel.GoAdmin += (_, _) => GoAdmin();
        DataContext = _doctorViewModel;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var parentWindow = Window.GetWindow(this);

        if (parentWindow != null && parentWindow is AuthorizationWindow autorized)
        {
            autorized.FramePatientAutorize.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            autorized.FramePatientAutorize.Content = new AutorizationPatientpage();
        }
    }

    private void GoDoctor()
    {
        var auth = Window.GetWindow(this);
        var doc = new DoctorWindow();
        doc.Show();
        auth.Close();
    }

    private void GoAdmin()
    {
        var auth = Window.GetWindow(this);
        var adm = new AdministratorWindow();
        adm.Show();
        auth.Close();
    }
}