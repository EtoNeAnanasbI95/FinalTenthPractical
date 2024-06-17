    using FinalTenthPractical.View.USERCONTROLS;
using System;
using System.Collections.Generic;
using System.IO;
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
using EMIAS.Models;
using FinalTenthPractical.Properties;
using WpfApp1.ViewModel;
using WpfApp1.ViewModel.ApiHelper;

namespace FinalTenthPractical.View.PAGES
{
    /// <summary>
    /// Логика взаимодействия для MedicalCardPatient.xaml
    /// </summary>
    public partial class PatientAppointmentDocumentsPage : Page
    {
        PatientArchiveAppointmentViewModel viewModel;
        
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
}
