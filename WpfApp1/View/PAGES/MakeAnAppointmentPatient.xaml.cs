using FinalTenthPractical.View.USERCONTROLS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MakeAnAppointmentPatient.xaml
    /// </summary>
    public partial class MakeAnAppointmentPatient : Page
    {
        private PatientMakeAnAppointmentViewModel _viewmodel;
        
        public MakeAnAppointmentPatient()
        {
            InitializeComponent();
            _viewmodel = new PatientMakeAnAppointmentViewModel();
            DataContext = _viewmodel;

            DoctorsPatient emergency = new DoctorsPatient();
            DoctorsPatient covid = new DoctorsPatient();
            emergency.IdSpecials = 11;
            covid.IdSpecials = 12;
            List<DoctorsPatient> ORVI_COVID_cards = new List<DoctorsPatient>() { emergency, covid };
            ORVI_COVID.ItemsSource = ORVI_COVID_cards;
        }

        private void MakeAnAppointmentPatient_OnLoaded(object sender, RoutedEventArgs e)
        {
            _viewmodel.GetData();
        }
    }
}
