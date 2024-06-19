using FinalTenthPractical.View.USERCONTROLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для DateAndTimeOfAppintmentSecond.xaml
    /// </summary>
    public partial class DateAndTimeOfAppintmentSecond : Page
    {
        public DateAndTimeOfAppintmentSecond(PatientChooseDoctorViewModel _viewModel)
        {

            DataContext = _viewModel;
            InitializeComponent();
        }

    }
}
