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
    /// Логика взаимодействия для DateAndTimeOfAppintmentSecond.xaml
    /// </summary>
    public partial class DateAndTimeOfAppintmentSecond : Page
    {
        public DateAndTimeOfAppintmentSecond()
        {


            InitializeComponent();

            DateOfAppointment aa = new DateOfAppointment();
            aa.tbl.Text = "29 мая, ср";

            DateOfAppointment aaa = new DateOfAppointment();
            aaa.tbl.Text = "29 мая, ср";

            DateOfAppointment aaaa = new DateOfAppointment();
            aaaa.tbl.Text = "29 мая, ср";

            DateOfAppointment aaaaa = new DateOfAppointment();
            aaaaa.tbl.Text = "29 мая, ср";

            DateOfAppointment aaaaaa = new DateOfAppointment();
            aaaaaa.tbl.Text = "29 мая, ср";


            List<DateOfAppointment> users = new List<DateOfAppointment>() { aa, aaa, aaaa, aaaaa, aaaaaa };
            LB.ItemsSource = users;
        }

    }
}
