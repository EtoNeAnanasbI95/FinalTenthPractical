using System.Windows;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View.USERCONTROLS;
using FinalTenthPractical.View.WINDOWS;
using WpfApp1;

namespace FinalTenthPractical.View;

public partial class DEVELOPING_WINDOW : Window
{
    public DEVELOPING_WINDOW()
    {
        InitializeComponent();
        Console.WriteLine(Settings.Default.CurrentTheme);
        Console.WriteLine(Settings.Default.CurrentPatient);
        Console.WriteLine(Settings.Default.CurrentDoctor);
        Console.WriteLine(Settings.Default.CurrentAdmin);
        Console.WriteLine(Settings.Default.CurrentDoctorPassword);
        Console.WriteLine(Settings.Default.CurrentAdminPassword);
    }

    private void GO_ADMIN(object sender, RoutedEventArgs e)
    {
        AdministratorWindow admin = new AdministratorWindow();
        admin.Show();
        this.Close();
    }

    private void GO_AUTH(object sender, RoutedEventArgs e)
    {
        AuthorizationWindow windows = new AuthorizationWindow();
        windows.Show();
        this.Close();
    }

    private void GO_DOCTOR(object sender, RoutedEventArgs e)
    {
        DoctorWindow windows = new DoctorWindow();
        windows.Show();
        this.Close();
    }

    private void GO_PATIENT(object sender, RoutedEventArgs e)
    {
        PatientWindow windows = new PatientWindow();
        windows.Show();
        this.Close();
    }
    
    private void GO_LOAD(object sender, RoutedEventArgs e)
    {
        Load windows = new Load();
        windows.Show();
        this.Close();
    }

    private void CHANGE_THEME(object sender, RoutedEventArgs e)
    {   
        if (Settings.Default.CurrentTheme == "Dark")
        {
            App.Theme = "Light";
        }
        else
        {
            App.Theme = "Dark";
        }
    }
    private void DEV_BUTTON(object sender, RoutedEventArgs e)
    {
        ReceptionUC rcu = new ReceptionUC();
        rcu.Click = test;
        Panel.Children.Add(rcu);
    }
    
    private void test()
    {
        MessageBox.Show("AHAHHHA");

    }
}