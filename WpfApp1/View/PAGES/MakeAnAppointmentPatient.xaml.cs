using System.Windows;
using System.Windows.Controls;
using FinalTenthPractical.View.USERCONTROLS;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View.PAGES;

/// <summary>
///     Логика взаимодействия для MakeAnAppointmentPatient.xaml
/// </summary>
public partial class MakeAnAppointmentPatient : Page
{
    private readonly PatientMakeAnAppointmentViewModel _viewmodel;

    public MakeAnAppointmentPatient(Frame frame)
    {
        InitializeComponent();
        _viewmodel = new PatientMakeAnAppointmentViewModel(frame);
        DataContext = _viewmodel;

        var emergency = new DoctorsPatient();
        var covid = new DoctorsPatient();
        emergency.IdSpecials = 11;
        covid.IdSpecials = 12;
        var ORVI_COVID_cards = new List<DoctorsPatient> { emergency, covid };
        ORVI_COVID.ItemsSource = ORVI_COVID_cards;
    }

    private void MakeAnAppointmentPatient_OnLoaded(object sender, RoutedEventArgs e)
    {
        _viewmodel.GetData();
    }
}