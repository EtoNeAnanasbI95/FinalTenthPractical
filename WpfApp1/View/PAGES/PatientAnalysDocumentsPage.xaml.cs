using FinalTenthPractical.View.USERCONTROLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View.PAGES
{
    /// <summary>
    /// Логика взаимодействия для MedicalCardAnaliz.xaml
    /// </summary>
    public partial class PatientAnalysDocumentsPage : Page
    {
        private PatientAnalysDocumentsViewModel _viewModel;
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
}
