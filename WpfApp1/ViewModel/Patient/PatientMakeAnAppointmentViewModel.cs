using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View.PAGES;
using FinalTenthPractical.View.USERCONTROLS;
using Microsoft.Win32;
using SecondLibPractice;

namespace WpfApp1.ViewModel;

public class PatientMakeAnAppointmentViewModel : BindingHelper
{
    public PatientMakeAnAppointmentViewModel(Frame frame)
    {
        _mainFrame = frame;
    }

    private Frame _mainFrame;
    
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

    private void GoChooseDoctor(object sender, EventArgs e)
    {
        _mainFrame.Navigate(new DateAndTimeOfAppintment(_mainFrame, sender as DoctorsPatient));
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
            doctor.Click += (sender, e) => GoChooseDoctor(sender, e);
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