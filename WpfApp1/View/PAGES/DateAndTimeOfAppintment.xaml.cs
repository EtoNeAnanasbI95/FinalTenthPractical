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
using FinalTenthPractical.View.USERCONTROLS;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View.PAGES
{
    /// <summary>
    /// Логика взаимодействия для DateAndTimeOfAppintment.xaml
    /// </summary>
    public partial class DateAndTimeOfAppintment : Page
    {
        private PatientChooseDoctorViewModel _viewModel;
        
        public DateAndTimeOfAppintment(Frame mainFrame, DoctorsPatient targetButton)
        {
            InitializeComponent();
            _viewModel = new PatientChooseDoctorViewModel(mainFrame, targetButton);
            DataContext = _viewModel;
            Frame.Navigate(new DateAndTimeOfAppintmentSecond(_viewModel));
        }

        private void DateAndTimeOfAppintment_OnLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();
        }
    }
}
