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

namespace FinalTenthPractical.View.USERCONTROLS
{
    /// <summary>
    /// Логика взаимодействия для MounthPatient.xaml
    /// </summary>
    public partial class MounthPatient : UserControl
    {
        public ObservableCollection<MounthAppointmentPatient> Items { get; set; }
        
        public MounthPatient()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void MounthPatient_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Items.Count == 0) IsEmpty.Text = "В этом месяце нет записей";
        }
    }
}
