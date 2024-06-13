using FinalTenthPractical.View.USERCONTROLS;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.IO;
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

            Document doc = new Document();
            doc.LoadFromFile(@"C:\Users\Ilyam\Downloads\РЕЗУЛЬТАТЫ_ЛАБЮОРАТОРНЫХ_ИССЛЕДОВАНИЙ.docx");
            doc.SaveToFile("конвертировать.rtf", FileFormat.Rtf);

            var range = new TextRange(RTBone.Document.ContentStart, RTBone.Document.ContentEnd);
            var fs = new FileStream("конвертировать.rtf", FileMode.OpenOrCreate);
            range.Load(fs, DataFormats.Rtf);
            fs.Close();

            DoctorWay first = new DoctorWay();
            first.TxtBlock.Text = "Ебать в рот";
            
            DoctorWay second = new DoctorWay();
            first.TxtBlock.Text = "Ебать в рот";

            DoctorWay th = new DoctorWay();
            first.TxtBlock.Text = "Ебать в рот";

            List<DoctorWay> users = new List<DoctorWay>() {first, second, th };
            ListSecond.ItemsSource = users;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

      
    }
}
