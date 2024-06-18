using FinalTenthPractical.View.USERCONTROLS;
using System.Windows;
using System.Windows.Controls;
using EMIAS.Models;
using WpfApp1.ViewModel;
using WpfApp1.ViewModel.ApiHelper;

namespace FinalTenthPractical.View.PAGES;

public partial class PatientAppointmentPage : Page
{
    private PatientMainAppointmentViewModel _patientMainAppointmentViewModel;
    public PatientAppointmentPage()
    {
        InitializeComponent();
        
        _patientMainAppointmentViewModel = new PatientMainAppointmentViewModel();
        DataContext = _patientMainAppointmentViewModel;
        
    }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        var MakeAnAppo = Window.GetWindow(this);

        if (MakeAnAppo != null && MakeAnAppo is PatientWindow autorized)
        {
            autorized.Frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            autorized.Frame.Content = new MakeAnAppointmentPatient();
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