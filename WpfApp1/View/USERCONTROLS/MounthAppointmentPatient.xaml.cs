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

namespace FinalTenthPractical.View.USERCONTROLS
{
    /// <summary>
    /// Логика взаимодействия для MounthAppointmentPatient.xaml
    /// </summary>
    public partial class MounthAppointmentPatient : UserControl
    {
        public MounthAppointmentPatient()
        {
            InitializeComponent();
        }

        public int CurrentAppointmentId;
        public int CycleStage;
        public int NumberOfCard;

        public event EventHandler SecondActionClick;

        private void secondAction(object sender, RoutedEventArgs e)
        {
            SecondActionClick?.Invoke(this, EventArgs.Empty);
        }
        
        public event EventHandler FirstActionClick;

        private void fistAction(object sender, RoutedEventArgs e)
        {
            FirstActionClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
