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
    /// Логика взаимодействия для MounthPatient.xaml
    /// </summary>
    public partial class MounthPatient : UserControl
    {
        public MounthPatient()
        {
            InitializeComponent();


            MounthAppointmentPatient oihgf = new MounthAppointmentPatient();
            oihgf.tbt.Text = "мать его ебал";

            MounthAppointmentPatient vgyu = new MounthAppointmentPatient();
            vgyu.tbt.Text = "мать его ебал";

            List<MounthAppointmentPatient> users = new List<MounthAppointmentPatient>() {oihgf, vgyu };
            LBBB.ItemsSource = users;
        }
    }
}
