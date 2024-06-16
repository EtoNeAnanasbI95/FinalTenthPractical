using EMIAS.Models;
using FinalTenthPractical.Properties;
using SecondLibPractice;

namespace WpfApp1.ViewModel;

public class PatientViewModel : BindingHelper
{
    private string _OMS;
    
    public string OMS
    {
        get => _OMS;
        set => SetField(ref _OMS, value);
    }

    public event EventHandler GoPatient;

    public void Auth(object sender, EventArgs e)
    {
        Console.WriteLine("Try auth patient");
        try
        {
            var doctor = ApiHelper.ApiHelper.Get<Patient>("Patients", Convert.ToInt32(OMS));
            GoPatient?.Invoke(this, EventArgs.Empty);
            Console.WriteLine("Patient auth successful");
            Settings.Default.CurrentPatient = Convert.ToInt32(OMS);
            Settings.Default.Save();
        } 
        catch (Exception) {Console.WriteLine("Patient auth bad request");}
    }
}