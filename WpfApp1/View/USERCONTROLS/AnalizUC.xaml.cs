using System.Windows.Controls;
using EMIAS.Models;

namespace FinalTenthPractical.View.USERCONTROLS;

/// <summary>
///     Логика взаимодействия для AnalizUC.xaml
/// </summary>
public partial class AnalizUC : UserControl
{
    public Appointment Appointment;

    public AnalizUC()
    {
        InitializeComponent();
        OnClick.Click += (sender, e) => GoClick(sender, e);
    }

    public event EventHandler Click;

    private void GoClick(object sender, EventArgs e)
    {
        Click?.Invoke(this, e);
    }
}