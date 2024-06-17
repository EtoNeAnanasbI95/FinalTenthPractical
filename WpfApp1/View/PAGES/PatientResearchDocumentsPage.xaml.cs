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
    /// Логика взаимодействия для MedicalCardStudy.xaml
    /// </summary>
    public partial class PatientResearchDocumentsPage : Page
    {
        private PatientResearchDocumentsViewModel viewModel;
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
}
