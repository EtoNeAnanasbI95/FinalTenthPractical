using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FinalTenthPractical.View.USERCONTROLS;

/// <summary>
///     Логика взаимодействия для MounthPatient.xaml
/// </summary>
public partial class MounthPatient : UserControl
{
    public MounthPatient()
    {
        InitializeComponent();
        DataContext = this;
    }

    public ObservableCollection<MounthAppointmentPatient> Items { get; set; }

    private void MounthPatient_OnLoaded(object sender, RoutedEventArgs e)
    {
        if (Items.Count == 0) IsEmpty.Text = "В этом месяце нет записей";
    }
}