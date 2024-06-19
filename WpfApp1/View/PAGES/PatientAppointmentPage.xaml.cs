using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View.PAGES;

public partial class PatientAppointmentPage : Page
{
    private readonly Frame _frame;
    private readonly PatientMainAppointmentViewModel _patientMainAppointmentViewModel;

    public PatientAppointmentPage(Frame frame)
    {
        InitializeComponent();
        _frame = frame;
        _patientMainAppointmentViewModel = new PatientMainAppointmentViewModel(_frame);
        DataContext = _patientMainAppointmentViewModel;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var MakeAnAppo = Window.GetWindow(this);

        if (MakeAnAppo != null && MakeAnAppo is PatientWindow autorized)
        {
            autorized.Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            autorized.Frame.Content = new MakeAnAppointmentPatient(_frame);
        }
    }

    private void PatientAppointmentPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        _patientMainAppointmentViewModel._timeOf = DateOnly.FromDateTime(DateTime.Today);
        _patientMainAppointmentViewModel._timeTo = DateOnly.FromDateTime(DateTime.Today.AddMonths(2));
        _patientMainAppointmentViewModel._timeOfArchive = DateOnly.FromDateTime(DateTime.Today.AddMonths(-1));
        _patientMainAppointmentViewModel._timeToArchive = DateOnly.FromDateTime(DateTime.Today.AddMonths(1));
        _patientMainAppointmentViewModel.Specialisations();
        _patientMainAppointmentViewModel.ActiveAppointments();
        _patientMainAppointmentViewModel.ArchiveAppointments();
    }
}