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
    /// Логика взаимодействия для PageDoctor.xaml
    /// </summary>
    public partial class PageDoctor : Page
    {
        public PageDoctor()
        {
            InitializeComponent();
            DoctorWay first = new DoctorWay();
            first.TxtBlock.Text = "Ебать в рот";

            List<DoctorWay> users = new List<DoctorWay>() { first};
            ListSecond.ItemsSourse = users;
        }
    }
}
