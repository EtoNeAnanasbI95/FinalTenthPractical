using System.Windows;
using System.Windows.Controls;

namespace FinalTenthPractical.View.PAGES;

public partial class AppointmentPatient : Page
{
    public AppointmentPatient()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        var MakeAnAppo = Window.GetWindow(this);

        if (MakeAnAppo != null && MakeAnAppo is PatientWindow autorized)
        {
            autorized.Frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            autorized.Frame.Content = new MakeAnAppointmentPatient();
        }
    }
}