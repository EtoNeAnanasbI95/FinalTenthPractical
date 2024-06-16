using FinalTenthPractical.View.USERCONTROLS;
using System.Windows;
using System.Windows.Controls;

namespace FinalTenthPractical.View.PAGES;

public partial class AppointmentPatient : Page
{
    public AppointmentPatient()
    {
        InitializeComponent();

        DoctorsPatient th = new DoctorsPatient();
        th.first.Text = "Jadsjskd";
        DoctorsPatient qw = new DoctorsPatient();
        qw.first.Text = "Jadsjskd";

        DoctorsPatient tccvh = new DoctorsPatient();
        tccvh.first.Text = "Jadsjskd";

        DoctorsPatient sdsdsd = new DoctorsPatient();
        sdsdsd.first.Text = "Jadsjskd";

        DoctorsPatient ghjk = new DoctorsPatient();
        ghjk.first.Text = "Jadsjskd";
        
        DoctorsPatient wefgbn = new DoctorsPatient();
        wefgbn.first.Text = "Jadsjskd";
        
        DoctorsPatient txcvbhgtr4h = new DoctorsPatient();
        txcvbhgtr4h.first.Text = "Jadsjskd";
        
        DoctorsPatient tsdhth = new DoctorsPatient();
        tsdhth.first.Text = "Jadsjskd";

        List<DoctorsPatient> users = new List<DoctorsPatient>() { th, qw, tccvh, sdsdsd, ghjk, wefgbn, txcvbhgtr4h, tsdhth };
        LB1.ItemsSource = users;

        MounthPatient tyui = new MounthPatient();
        tyui.mounth.Text = "Хуябрь 2023";

        MounthPatient jhsdksj = new MounthPatient();
        jhsdksj.mounth.Text = "Хуябрь 2023";
        
        MounthPatient sdfc = new MounthPatient();
        sdfc.mounth.Text = "Хуябрь 2023";
        
        MounthPatient defc = new MounthPatient();
        defc.mounth.Text = "Хуябрь 2023";
        
        MounthPatient sdcx = new MounthPatient();
        sdcx.mounth.Text = "Хуябрь 2023";

        List<MounthPatient> mounthhh = new List<MounthPatient>() { tyui, jhsdksj, sdfc, defc, sdcx};
        LB2.ItemsSource = mounthhh;


        MounthPatient s = new MounthPatient();
        tyui.mounth.Text = "Хуябрь 2023";

        MounthPatient q = new MounthPatient();
        jhsdksj.mounth.Text = "Хуябрь 2023";
        
        MounthPatient w = new MounthPatient();
        sdfc.mounth.Text = "Хуябрь 2023";
        
        MounthPatient e = new MounthPatient();
        defc.mounth.Text = "Хуябрь 2023";
        
        MounthPatient r = new MounthPatient();
        sdcx.mounth.Text = "Хуябрь 2023";

        List<MounthPatient> qqqqq = new List<MounthPatient>() { s, q, w, e, r};
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