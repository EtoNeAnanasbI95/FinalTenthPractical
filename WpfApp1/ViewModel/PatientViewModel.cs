namespace WpfApp1.ViewModel;

public class PatientViewModel : ApiHelper.ApiHelper
{
    private string _OMS;
    
    public string OMS
    {
        get => _OMS;
        set => SetField(ref _OMS, value);
    }
}