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
using EMIAS.Models;
using FinalTenthPractical.View.WINDOWS;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View
{
    /// <summary>
    /// Логика взаимодействия для FrameAutorizedDoctor.xaml
    /// </summary>
    public partial class FrameAutorizedDoctor : Page
    {
        private DoctorViewModel _doctorViewModel; 
        
        public FrameAutorizedDoctor()
        {
            InitializeComponent();
            _doctorViewModel = new DoctorViewModel();
            _doctorViewModel.GodoctorPage += (_, _) => GoDoctorPage();
            DataContext = _doctorViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this);

            if (parentWindow != null && parentWindow is AuthorizationWindow autorized)
            {
                autorized.FramePatientAutorize.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
                autorized.FramePatientAutorize.Content = new FrameAutorizedPatient();
            }
        }

        private void GoDoctorPage()
        {
            var auth = AuthorizationWindow.GetWindow(this);
            DoctorWindow doc = new DoctorWindow();
            doc.Show();
            auth.Close();
        }
    }
}
