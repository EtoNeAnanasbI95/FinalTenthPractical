using FinalTenthPractical.View.USERCONTROLS;
using System.Windows;
using System.Windows.Controls;
using EMIAS.Models;
using WpfApp1.ViewModel.ApiHelper;

namespace FinalTenthPractical.View.PAGES;

public partial class PatientAppointmentPage : Page
{
    
    
    public PatientAppointmentPage()
    {
        InitializeComponent();
        var specialities = ApiHelper.Get<List<Speciality>>("Specialities");
        List<DoctorsPatient> users = new List<DoctorsPatient>();
        foreach (var item in specialities)
        {
            Console.WriteLine(item.IdSpeciality);
            DoctorsPatient doctor = new DoctorsPatient();
            doctor.IdSpecials = item.IdSpeciality.Value;
            users.Add(doctor);
        }
        LB1.ItemsSource = users;
        
        MounthPatient sdcx = new MounthPatient();
        sdcx.mounth.Text = "Хуябрь 2023";

        List<MounthPatient> mounthhh = new List<MounthPatient>() {sdcx};
        LB2.ItemsSource = mounthhh;
        
        MounthPatient r = new MounthPatient();
        sdcx.mounth.Text = "Хуябрь 2023";

        List<MounthPatient> qqqqq = new List<MounthPatient>() {r};
        LB3.ItemsSource = qqqqq;
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