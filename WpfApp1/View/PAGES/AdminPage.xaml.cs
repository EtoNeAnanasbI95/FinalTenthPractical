using System.Windows.Controls;

namespace FinalTenthPractical.View.PAGES;

/// <summary>
///     Логика взаимодействия для AdminAdministrator.xaml
/// </summary>
public partial class AdminPage : Page
{
    public AdminPage(object data)
    {
        InitializeComponent();
        DataContext = data;
    }
}