using System.Windows;
using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View.PAGES;

/// <summary>
///     Логика взаимодействия для MedicalCardAnaliz.xaml
/// </summary>
public partial class PatientAnalysDocumentsPage : Page
{
    private readonly PatientAnalysDocumentsViewModel _viewModel;

    public PatientAnalysDocumentsPage()
    {
        InitializeComponent();
        _viewModel = new PatientAnalysDocumentsViewModel();
        DataContext = _viewModel;
        _viewModel.RTB = RTB.Document;
    }

    private void PatientResearchDocumentsPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        _viewModel.Load();
    }
}