using System.Collections.ObjectModel;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View.USERCONTROLS;
using SecondLibPractice;

namespace WpfApp1.ViewModel;

public class PatientMakeAnAppointmentViewModel : BindingHelper
{
    private ObservableCollection<DoctorsPatient> _specialities;
    public ObservableCollection<DoctorsPatient> Specialities
    {
        get => _specialities;
        set => SetField(ref _specialities, value);
    }
    
    private ObservableCollection<DoctorsPatient> _directions;

    public ObservableCollection<DoctorsPatient> Directions
    {
        get => _directions;
        set => SetField(ref _directions, value);
    }
    
    private ObservableCollection<DoctorsPatient> _targets;

    public ObservableCollection<DoctorsPatient> Targets
    {
        get => _targets;
        set => SetField(ref _targets, value);
    }
    
    public void GetData()
    {
        Specialities = new ObservableCollection<DoctorsPatient>();
        Directions = new ObservableCollection<DoctorsPatient>();
        Targets = new ObservableCollection<DoctorsPatient>();
        var specialities = ApiHelper.ApiHelper.Get<List<Speciality>>("Specialities");

        foreach (var item in specialities)
        {
            DoctorsPatient doctor = new DoctorsPatient();
            doctor.IdSpecials = item.IdSpeciality.Value;
            Specialities.Add(doctor);
        }
        
        var directions = ApiHelper.ApiHelper.Get<List<Direction>>("Directions").Where(item => item.Oms == Settings.Default.CurrentPatient);
            
        foreach (var direct in directions)
        {
            DoctorsPatient doctor = new DoctorsPatient();
            doctor.IdSpecials = direct.SpecialityId.Value;
            Directions.Add(doctor);
        }
            
        foreach (var item in specialities)
        {
            DoctorsPatient doctor = new DoctorsPatient();
            doctor.IdSpecials = item.IdSpeciality.Value;
            Targets.Add(doctor);
        }
    }
}