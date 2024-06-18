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
using EMIAS.Models;

namespace FinalTenthPractical.View.USERCONTROLS
{
    /// <summary>
    /// Логика взаимодействия для AnalizUC.xaml
    /// </summary>
    public partial class AnalizUC : UserControl
    {
        public event EventHandler Click;
        
        public AnalizUC()
        {
            InitializeComponent();
            OnClick.Click += (sender, e) => GoClick(sender, e);
        }

        public Appointment Appointment;

        private void GoClick(object sender, EventArgs e)
        {
            Click?.Invoke(this, e);
        }
    }
}
