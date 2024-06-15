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
    /// Логика взаимодействия для MedicalCardAnaliz.xaml
    /// </summary>
    public partial class MedicalCardAnaliz : Page
    {
        public MedicalCardAnaliz()
        {
            InitializeComponent();

            AnalizUC th = new AnalizUC();
            th.FirstTB.Text = "Общий клинический анализ крови; микроскопическое исследование мазка";
            th.SecondTB.Text = "29 хуебря 2023 г.";

            List<Object> Cards = new List<Object>() { th };
            LBUC.ItemsSource = Cards;
        }
    }
}
