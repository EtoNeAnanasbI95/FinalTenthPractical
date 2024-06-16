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
    /// Логика взаимодействия для ChoiseDatePatient.xaml
    /// </summary>
    public partial class ChoiseDatePatient : Page
    {
        public ChoiseDatePatient()
        {
            InitializeComponent();

            DateOfChoiseDate th = new DateOfChoiseDate();
            th.date.Text = "09 мая, чт";

            DateOfChoiseDate q = new DateOfChoiseDate();
            q.date.Text = "29 июня, ср";

            DateOfChoiseDate w = new DateOfChoiseDate();
            w.date.Text = "03 августа, пон";

            DateOfChoiseDate e = new DateOfChoiseDate();
            e.date.Text = "23 сентября, ср";

            DateOfChoiseDate r = new DateOfChoiseDate();
            r.date.Text = "29 ноября, вскр";

            DateOfChoiseDate t = new DateOfChoiseDate();
            t.date.Text = "12 мая, ср";

            DateOfChoiseDate y = new DateOfChoiseDate();
            y.date.Text = "29 января, сб";

            List<DateOfChoiseDate> users = new List<DateOfChoiseDate>() { th, q, w, e,r ,t, y };
            LB1.ItemsSource = users;
        }
    }
}
