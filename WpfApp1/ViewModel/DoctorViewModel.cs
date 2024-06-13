using EMIAS.Models;

namespace WpfApp1.ViewModel;

public class DoctorViewModel : ApiHelper.ApiHelper
{
    private string _NumberOfDoctor;

    public string NumberOfDoctor
    {
        get => _NumberOfDoctor;
        set => SetField(ref _NumberOfDoctor, value);
    }
    private string _PasswordDoctor;

    public string PasswordDoctor
    {
        get => _PasswordDoctor;
        set => SetField(ref _PasswordDoctor, value);
    }

    public event EventHandler GodoctorPage;

    public void AuthDoctor(object sender, EventArgs e)
    {
        Console.WriteLine("Try auth");
        try
        {
            var doctor = Get<Doctor>("Doctors", Convert.ToInt32(NumberOfDoctor));
            if (doctor.EnterPassword == PasswordDoctor) GodoctorPage?.Invoke(this, EventArgs.Empty);
            Console.WriteLine("Auth successful");
        } 
        catch (Exception) {Console.WriteLine("Auth bad request");}
    }
}