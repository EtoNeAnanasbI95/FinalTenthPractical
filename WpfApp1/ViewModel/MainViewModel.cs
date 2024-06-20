using System.IO;
using System.Windows;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using Newtonsoft.Json;

namespace WpfApp1.ViewModel;

public static class MainViewModel
{
    public static List<AnalysDocument> AnalysDocuments;
    
    public static List<Appointment> Appointments;
    
    public static List<Doctor> Doctors;

    public static int AppointmentidForDelete;

    public async static void ReloadAll()
    {
        Appointments = ApiHelper.ApiHelper.Get<List<Appointment>>("Appointments");
        AnalysDocuments = ApiHelper.ApiHelper.Get<List<AnalysDocument>>("AnalysDocuments");
        Doctors = ApiHelper.ApiHelper.Get<List<Doctor>>("Doctors");
    }
    
    public async static void ReloadAnalysDocuments()
    {
        AnalysDocuments = ApiHelper.ApiHelper.Get<List<AnalysDocument>>("AnalysDocuments");
    }
    
    public async static void ReloadAppointments()
    {
        Appointments = ApiHelper.ApiHelper.Get<List<Appointment>>("Appointments");
    }
    
    public async static void ReloadDoctors()
    {
        Doctors = ApiHelper.ApiHelper.Get<List<Doctor>>("Doctors");
    }

    public static List<Patient> Users = new();

    public static void NewUser()
    {
        if (File.Exists("UserData.json"))
        {
            var json = File.ReadAllText("UserData.json");
            Users = JsonConvert.DeserializeObject<List<Patient>>(json);
            if (Users.Count == 0) GoUser();
            else
            {
                var user = ApiHelper.ApiHelper.Get<Patient>("Patients", Settings.Default.CurrentPatient);
                var checkpoint = Users.Find(item => item.Oms == Settings.Default.CurrentPatient);
                if (checkpoint == null) Users.Add(user);
                json = JsonConvert.SerializeObject(Users);
                File.WriteAllText("UserData.json", json);
            }
        }
        else GoUser();
    }

    private static void GoUser()
    {
        var user = ApiHelper.ApiHelper.Get<Patient>("Patients", Settings.Default.CurrentPatient);
        Users.Add(user);
        var json = JsonConvert.SerializeObject(Users);
        File.WriteAllText("UserData.json", json);
    }

    public static void ExitFromAcc()
    {
        Users.Remove(Users.Find(item => item.Oms == Settings.Default.CurrentPatient));
        var json = JsonConvert.SerializeObject(Users);
        File.WriteAllText("UserData.json", json);
    }

    public static void LoadUsers()
    {
        if (File.Exists("UserData.json"))
        {
            var json = File.ReadAllText("UserData.json");
            Users = JsonConvert.DeserializeObject<List<Patient>>(json);
            Users.Distinct();
        }
    }
}