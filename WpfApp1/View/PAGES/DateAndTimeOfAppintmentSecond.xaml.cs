using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View.PAGES;

/// <summary>
///     Логика взаимодействия для DateAndTimeOfAppintmentSecond.xaml
/// </summary>
public partial class DateAndTimeOfAppintmentSecond : Page
{
    public DateAndTimeOfAppintmentSecond(PatientChooseDoctorViewModel _viewModel)
    {
        DataContext = _viewModel;
        InitializeComponent();
    }
}