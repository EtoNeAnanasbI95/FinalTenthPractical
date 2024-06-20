using System.Windows.Controls;

namespace FinalTenthPractical.View.PAGES;

/// <summary>
///     Логика взаимодействия для AdminDoctor.xaml
/// </summary>
public partial class AdminDoctorLBPage : Page
{
    public AdminDoctorLBPage(object data)
    {
        InitializeComponent();
        DataContext = data;
    }
}