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

namespace FinalTenthPractical.View
{
    /// <summary>
    /// Логика взаимодействия для FrameAutorizedDoctor.xaml
    /// </summary>
    public partial class FrameAutorizedDoctor : Page
    {
        public FrameAutorizedDoctor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this);

            if (parentWindow != null && parentWindow is Autorized autorized)
            {
                autorized.FramePatientAutorize.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
                autorized.FramePatientAutorize.Content = new FrameAutorizedPatient();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
