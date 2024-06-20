using System.Windows;
using System.Windows.Controls;
using FinalTenthPractical.View.USERCONTROLS;

namespace FinalTenthPractical.View.PAGES;

/// <summary>
///     Логика взаимодействия для PageDoctor.xaml
/// </summary>
public partial class DoctorPage : Page
{
    public DoctorPage()
    {
        InitializeComponent();

        // Document doc = new Document();
        // doc.LoadFromFile(@"C:\Users\Ilyam\Downloads\РЕЗУЛЬТАТЫ_ЛАБЮОРАТОРНЫХ_ИССЛЕДОВАНИЙ.docx");
        // doc.SaveToFile("конвертировать.rtf", FileFormat.Rtf);
        //
        // var range = new TextRange(RTBone.Document.ContentStart, RTBone.Document.ContentEnd);
        // var fs = new FileStream("конвертировать.rtf", FileMode.OpenOrCreate);
        // range.Load(fs, DataFormats.Rtf);
        // fs.Close();

        var first = new DoctorWay();
        first.TxtBlock.Text = "Ебать в рот";

        var second = new DoctorWay();
        first.TxtBlock.Text = "Ебать в рот";

        var th = new DoctorWay();
        first.TxtBlock.Text = "Ебать в рот";

        var users = new List<DoctorWay> { first, second, th };
        ListSecond.ItemsSource = users;
    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
    }
}