using EMIAS.Models;

namespace WpfApp1.ViewModel;

public class DoctorViewModel : ApiHelper.ApiHelper
{
    public string NumberOfDoctor { get; set; }
    public string PasswordDoctor { get; set; }

    public event EventHandler GodoctorPage;

    public void AuthDoctor(object sender, EventArgs e)
    {
        Console.WriteLine("Try auth");
        try
        {
            var doctor = Get<Doctor>("Doctors", Convert.ToInt32(NumberOfDoctor));
            if (doctor.EnterPassword == PasswordDoctor) GodoctorPage?.Invoke(this, EventArgs.Empty);
            Console.WriteLine("Auth successful");
        } catch (Exception) {Console.WriteLine("Auth bad request");}
    }
}