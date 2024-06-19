using System.Windows;
using System.Windows.Controls;
using EMIAS.Models;
using FinalTenthPractical.View.USERCONTROLS;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View.PAGES;

/// <summary>
///     Логика взаимодействия для DateAndTimeOfAppintment.xaml
/// </summary>
public partial class DateAndTimeOfAppintment : Page
{
    private readonly PatientChooseDoctorViewModel _viewModel;

    public DateAndTimeOfAppintment(Frame mainFrame, object targetButton)
    {
        InitializeComponent();
        
        if (targetButton is Doctor) _viewModel = new PatientChooseDoctorViewModel(mainFrame, targetButton as Doctor);
        else _viewModel = new PatientChooseDoctorViewModel(mainFrame, (int)targetButton);
        DataContext = _viewModel;
        Frame.Navigate(new DateAndTimeOfAppintmentSecond(_viewModel));
    }

    private void DateAndTimeOfAppintment_OnLoaded(object sender, RoutedEventArgs e)
    {
        _viewModel.Load();
    }
}