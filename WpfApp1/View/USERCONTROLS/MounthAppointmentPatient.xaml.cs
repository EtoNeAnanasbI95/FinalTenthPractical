using System.Windows;
using System.Windows.Controls;

namespace FinalTenthPractical.View.USERCONTROLS;

/// <summary>
///     Логика взаимодействия для MounthAppointmentPatient.xaml
/// </summary>
public partial class MounthAppointmentPatient : UserControl
{
    public int CurrentAppointmentId;
    public int CycleStage;
    public int NumberOfCard;

    public MounthAppointmentPatient()
    {
        InitializeComponent();
    }

    public event EventHandler SecondActionClick;

    private void secondAction(object sender, RoutedEventArgs e)
    {
        SecondActionClick?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler FirstActionClick;

    private void fistAction(object sender, RoutedEventArgs e)
    {
        FirstActionClick?.Invoke(this, EventArgs.Empty);
    }
}