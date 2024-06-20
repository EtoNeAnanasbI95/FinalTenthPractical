using System.Windows;
using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View.PAGES;

/// <summary>
///     Логика взаимодействия для MedicalCardPatient.xaml
/// </summary>
public partial class PatientAppointmentDocumentsPage : Page
{
    private readonly PatientArchiveAppointmentViewModel viewModel;

    public PatientAppointmentDocumentsPage()
    {
        InitializeComponent();
        viewModel = new PatientArchiveAppointmentViewModel();
        DataContext = viewModel;
        viewModel.RTB = RTB.Document;
    }

    private void PatientAppointmentDocumentsPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        viewModel.Load();
    }
}