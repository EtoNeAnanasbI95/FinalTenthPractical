using FinalTenthPractical.View.USERCONTROLS;
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

namespace FinalTenthPractical.View.PAGES
{
    /// <summary>
    /// Логика взаимодействия для SelectingSpecialistPatient.xaml
    /// </summary>
    public partial class SelectingSpecialistPatient : Page
    {
        public SelectingSpecialistPatient()
        {
            InitializeComponent();

            SelectionSpecialistUC th = new SelectionSpecialistUC();
            th.FirstTB.Text = "Пахтусов Андрей Александрович";
            th.ThirdTB.Text = "Послезавтра";

            List<SelectionSpecialistUC> users = new List<SelectionSpecialistUC>() { th };
            LBUC.ItemsSource = users;

            Frame.Navigate(new ChoiseDatePatient());

        }
    }
}
