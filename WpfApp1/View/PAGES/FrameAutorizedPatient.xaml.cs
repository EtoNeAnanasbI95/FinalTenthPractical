using FinalTenthPractical.View.WINDOWS;
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
using FinalTenthPractical.Properties;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View
{
    /// <summary>
    /// Логика взаимодействия для FrameAutorizedPatient.xaml
    /// </summary>
    public partial class FrameAutorizedPatient : Page
    {
        private PatientViewModel _patientViewModel;
        
        public FrameAutorizedPatient()
        {
            InitializeComponent();
            _patientViewModel = new PatientViewModel();
            _patientViewModel.GoPatient += (sender, args) => GoPatient();
            DataContext = _patientViewModel;
        }
     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this);

            if (parentWindow != null && parentWindow is AuthorizationWindow autorized)
            {
                autorized.FramePatientAutorize.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
                autorized.FramePatientAutorize.Content = new FrameAutorizedDoctor();
            }
        }

        private void GoPatient()
        {
            var auth = AuthorizationWindow.GetWindow(this);
            PatientWindow patient = new PatientWindow();
            patient.Show();
            auth.Close();
        }
    }
}