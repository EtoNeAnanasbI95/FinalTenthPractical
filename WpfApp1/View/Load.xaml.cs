﻿using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View;
using FinalTenthPractical.View.WINDOWS;
using WpfApp1.ViewModel;
using WpfApp1.ViewModel.ApiHelper;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Load : Window
{
    private System.Timers.Timer timer;

    public Load()
    {
        InitializeComponent();
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        
        MainViewModel.Appointments = ApiHelper.Get<List<Appointment>>("Appointments");
        MainViewModel.Doctors = ApiHelper.Get<List<Doctor>>("Doctors");
        MainViewModel.AnalysDocuments = ApiHelper.Get<List<AnalysDocument>>("AnalysDocuments");
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        timer = new System.Timers.Timer(100);
        timer.Elapsed += Timer_Elapsed;
        timer.AutoReset = false;
        timer.Start();
    }

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        Dispatcher.Invoke(() =>
        {
            if (Settings.Default.CurrentPatient != 0)
            {
                PatientWindow window = new PatientWindow();
                window.Show();
                Close();
            }
            else if (Settings.Default.CurrentDoctor != 0)
            {
                DoctorWindow window = new DoctorWindow();
                window.Show();
                Close();
            }
            else if (Settings.Default.CurrentAdmin != 0)
            {
                AdministratorWindow window = new AdministratorWindow();
                window.Show();
                Close();
            }
            else
            {
                var authorizedWindow = new AuthorizationWindow();
                authorizedWindow.Show();
                Close();
            }
        });
    }
}


   
