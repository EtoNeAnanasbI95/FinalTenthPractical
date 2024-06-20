using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View;

/// <summary>
///     Логика взаимодействия для FrameAutorizedPatient.xaml
/// </summary>
public partial class AutorizationPatientpage : Page
{
    private readonly PatientMainAppointmentViewModel _patientMainAppointmentViewModel;

    public AutorizationPatientpage()
    {
        InitializeComponent();
        _patientMainAppointmentViewModel = new PatientMainAppointmentViewModel();
        _patientMainAppointmentViewModel.GoPatient += (sender, args) => GoPatient();
        DataContext = _patientMainAppointmentViewModel;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var parentWindow = Window.GetWindow(this);

        if (parentWindow != null && parentWindow is AuthorizationWindow autorized)
        {
            autorized.FramePatientAutorize.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            autorized.FramePatientAutorize.Content = new AutorizationDoctorPage();
        }
    }

    private void GoPatient()
    {
        var auth = Window.GetWindow(this);
        var patient = new PatientWindow();
        patient.Show();
        auth.Close();
    }
}