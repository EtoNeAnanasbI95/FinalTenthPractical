using System.Windows;
using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View.PAGES;

/// <summary>
///     Логика взаимодействия для MedicalCardStudy.xaml
/// </summary>
public partial class PatientResearchDocumentsPage : Page
{
    private readonly PatientResearchDocumentsViewModel viewModel;

    public PatientResearchDocumentsPage()
    {
        InitializeComponent();
        viewModel = new PatientResearchDocumentsViewModel();
        DataContext = viewModel;
        viewModel.RTB = RTB.Document;
        GoDownload.Click += (sender, e) => viewModel.GoDownload(sender, e);
    }

    private void PatientResearchDocumentsPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        viewModel.Load();
    }
}