using EMIAS.Models;
using FinalTenthPractical.Properties;
using SecondLibPractice;

namespace WpfApp1.ViewModel;

public class DoctorViewModel : BindingHelper
{
    private string _NumberOfDoctor;
    private string _PasswordDoctor;

    public string NumberOfDoctor
    {
        get => _NumberOfDoctor;
        set => SetField(ref _NumberOfDoctor, value);
    }

    public string PasswordDoctor
    {
        get => _PasswordDoctor;
        set => SetField(ref _PasswordDoctor, value);
    }

    public event EventHandler GoDoctor;
    public event EventHandler GoAdmin;

    public void AuthDoctor(object sender, EventArgs e)
    {
        try
        {
            var doctor = MainViewModel.Doctors.Find(item => item.IdDoctor == Convert.ToInt32(NumberOfDoctor));
            var admin = ApiHelper.ApiHelper.Get<Admin>("Admins", Convert.ToInt32(NumberOfDoctor));
            if (doctor.EnterPassword == PasswordDoctor)
            {
                GoDoctor?.Invoke(this, EventArgs.Empty);
                Settings.Default.CurrentDoctor = Convert.ToInt32(NumberOfDoctor);
                Settings.Default.CurrentDoctorPassword = PasswordDoctor;
                Settings.Default.Save();
            }
            else if (admin.EnterPassword == PasswordDoctor)
            {
                GoAdmin?.Invoke(this, EventArgs.Empty);
                Settings.Default.CurrentAdmin = Convert.ToInt32(NumberOfDoctor);
                Settings.Default.CurrentAdminPassword = PasswordDoctor;
                Settings.Default.Save();
            }
        }
        catch (Exception)
        {
        }
    }
}