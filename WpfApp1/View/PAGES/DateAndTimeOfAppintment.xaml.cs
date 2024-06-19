using System.Windows;
using System.Windows.Controls;
using FinalTenthPractical.View.USERCONTROLS;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View.PAGES;

/// <summary>
///     Логика взаимодействия для DateAndTimeOfAppintment.xaml
/// </summary>
public partial class DateAndTimeOfAppintment : Page
{
    private readonly PatientChooseDoctorViewModel _viewModel;

    public DateAndTimeOfAppintment(Frame mainFrame, DoctorsPatient targetButton)
    {
        InitializeComponent();
        _viewModel = new PatientChooseDoctorViewModel(mainFrame, targetButton);
        DataContext = _viewModel;
        Frame.Navigate(new DateAndTimeOfAppintmentSecond(_viewModel));
    }

    private void DateAndTimeOfAppintment_OnLoaded(object sender, RoutedEventArgs e)
    {
        _viewModel.Load();
    }
}