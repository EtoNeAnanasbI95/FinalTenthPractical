using System.Windows.Controls;
using System.Xml;
using WpfApp1.ViewModel;

namespace FinalTenthPractical.View.PAGES
{
    /// <summary>
    /// Логика взаимодействия для AdminPatient.xaml
    /// </summary>
    public partial class AdminPatient : Page
    {
        public AdminPatient(object data)
        {
            InitializeComponent();
            DataContext = data;
        }
    }
}
