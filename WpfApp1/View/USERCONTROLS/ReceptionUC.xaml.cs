using System.Windows.Controls;

namespace FinalTenthPractical.View.USERCONTROLS;

/// <summary>
///     Логика взаимодействия для ReceptionUC.xaml
/// </summary>
public partial class ReceptionUC : UserControl
{
    public int AppointmentId;

    public ReceptionUC()
    {
        InitializeComponent();
        OnClick.Click += (sender, args) => OnCardClick(sender, args);
    }

    public event EventHandler Click;

    private void OnCardClick(object sender, EventArgs e)
    {
        Click?.Invoke(this, e);
    }
}