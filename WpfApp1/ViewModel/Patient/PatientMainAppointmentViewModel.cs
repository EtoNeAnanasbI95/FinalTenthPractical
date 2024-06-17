using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View.USERCONTROLS;
using SecondLibPractice;

namespace WpfApp1.ViewModel;

public class PatientMainAppointmentViewModel : BindingHelper
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

    private ObservableCollection<DoctorsPatient> _specialitiesCards;

    public ObservableCollection<DoctorsPatient> SpecialitiesCards
    {
        get => _specialitiesCards;
        set => SetField(ref _specialitiesCards, value);
    }

    public void Specialisations()
    {
        var specialities = ApiHelper.ApiHelper.Get<List<Speciality>>("Specialities");
        SpecialitiesCards = new ObservableCollection<DoctorsPatient>();
        foreach (var item in specialities)
        {
            Console.WriteLine(item.IdSpeciality);
            DoctorsPatient doctor = new DoctorsPatient();
            doctor.IdSpecials = item.IdSpeciality.Value;
            SpecialitiesCards.Add(doctor);
        }
        
        MounthPatient sdcx = new MounthPatient();
        sdcx.mounth.Text = "Хуябрь 2023";
    }
    
    private ObservableCollection<MounthPatient> _appointmentCards;

    public ObservableCollection<MounthPatient> AppointmentCards
    {
        get => _appointmentCards;
        set => SetField(ref _appointmentCards, value);
    }
    
    private ObservableCollection<MounthPatient> _archiveAppointmentCards;

    public ObservableCollection<MounthPatient> ArchiveAppointmentCards
    {
        get => _archiveAppointmentCards;
        set => SetField(ref _archiveAppointmentCards, value);
    }

    private DateOnly _timeOf = DateOnly.FromDateTime(DateTime.Today);

    public void DataOfPick(object sender, SelectionChangedEventArgs  e)
    {
        _timeOf = DateOnly.FromDateTime((DateTime)((sender as DatePicker)!).SelectedDate!);
        ActiveAppointments();
    }
    
    private DateOnly _timeTo = DateOnly.FromDateTime(DateTime.Today.AddMonths(3));
    
    public void DataToPick(object sender, SelectionChangedEventArgs  e)
    {
        _timeTo = DateOnly.FromDateTime((DateTime)((sender as DatePicker)!).SelectedDate!);
        ActiveAppointments();
    }
    
    private DateOnly _timeOfArchive = DateOnly.FromDateTime(DateTime.Today.AddMonths(-1));

    public void DataOfPickArchive(object sender, SelectionChangedEventArgs  e)
    {
        _timeOfArchive = DateOnly.FromDateTime((DateTime)((sender as DatePicker)!).SelectedDate!);
        ArchiveAppointments();
    }
    
    private DateOnly _timeToArchive = DateOnly.FromDateTime(DateTime.Today.AddMonths(1));
    
    public void DataToPickArchive(object sender, SelectionChangedEventArgs  e)
    {
        _timeToArchive = DateOnly.FromDateTime((DateTime)((sender as DatePicker)!).SelectedDate!);
        ArchiveAppointments();
    }

    private int CalculateMonthsDifference(DateOnly startDate, DateOnly endDate)
    {
        int yearsDifference = endDate.Year - startDate.Year;
        int monthsDifference = endDate.Month - startDate.Month;

        return yearsDifference * 12 + monthsDifference;
    }

    public void ActiveAppointments()
    {
        if (_timeOf != DateOnly.MinValue && _timeTo != DateOnly.MinValue)
        {
            var appointments = ApiHelper.ApiHelper.Get<List<Appointment>>("Appointments").Where(item =>
                item.Oms == Settings.Default.CurrentPatient && item.AppointmentDate > _timeOf &&
                item.AppointmentDate < _timeTo);
            var doctors = ApiHelper.ApiHelper.Get<List<Doctor>>("Doctors");

            var arhiveAppointments = appointments.Where(item => item.StatusId == 4);
            var activeAppointments = appointments.Except(arhiveAppointments);
            var Cards = new ObservableCollection<MounthPatient>();
            ArchiveAppointmentCards = new ObservableCollection<MounthPatient>();
            for (int i = 0; i <= CalculateMonthsDifference(_timeOf, _timeTo); i++)
            {
                ObservableCollection<MounthAppointmentPatient> cards = new ObservableCollection<MounthAppointmentPatient>();
                var activeAppointmentsMounth = activeAppointments.Where(item =>
                    item.AppointmentDate.Month == _timeOf.AddMonths(i).Month &&
                    item.AppointmentDate.Day >= _timeOf.AddMonths(i).Day).ToList();
                if (activeAppointmentsMounth != null)
                {
                    for (int g = 0; g < activeAppointmentsMounth.Count(); g++)
                    {
                        MounthAppointmentPatient card = new MounthAppointmentPatient();
                        card.CurrentAppointmentId = activeAppointmentsMounth[g].IdAppointment.Value;
                        card.CycleStage = i;
                        card.NumberOfCard = g;
                        card.Date.Text = activeAppointmentsMounth[g].AppointmentDate.ToString();
                        var currDoctor = doctors.Find(item => item.IdDoctor == activeAppointmentsMounth[g].DoctorId);
                        card.Specialisation.Text = ApiHelper.ApiHelper
                            .Get<Speciality>("Specialities", currDoctor.SpecialityId.Value).NameSpecialities;
                        card.DoctorName.Text = $"{currDoctor.Surname} {currDoctor.FirstName} {currDoctor.Patronymic}";
                        card.Address.Text = currDoctor.WorkAddress;
                        card.FirstAction.Content = "Перенести";
                        // card.FirstAction.Click += "Перенести";
                        card.SecondAction.Content = "Отменить";
                        card.SecondActionClick += (sender, e) => delete(sender, e);
                        cards.Add(card);
                    }
                }
                var mounthPatient = new MounthPatient();
                mounthPatient.mounth.Text = _timeOf.AddMonths(i).ToString("MMMM yyyy");
                mounthPatient.Items = cards;
                Cards.Add(mounthPatient);
                AppointmentCards = Cards;
            }
        }
    }

    private void delete(object sender, EventArgs e)
    {
        var parent = (sender as MounthAppointmentPatient);
        ApiHelper.ApiHelper.Delete<Appointment>("Appointments",  parent.CurrentAppointmentId);
        ApiHelper.ApiHelper.Delete<AnalysDocument>("AnalysDocuments", parent.CurrentAppointmentId);
        ApiHelper.ApiHelper.Delete<ResearchDocument>("ResearchDocuments", parent.CurrentAppointmentId);
        ApiHelper.ApiHelper.Delete<AppointmentDocument>("AppointmentDocuments", parent.CurrentAppointmentId);
        AppointmentCards[parent.CycleStage].Items.Remove(parent);
    }
    
    
    public void ArchiveAppointments()
    {
        if (_timeOfArchive != DateOnly.MinValue && _timeToArchive != DateOnly.MinValue)
        {
            var appointments = ApiHelper.ApiHelper.Get<List<Appointment>>("Appointments").Where(item =>
                item.Oms == Settings.Default.CurrentPatient && item.AppointmentDate > _timeOfArchive &&
                item.AppointmentDate < _timeToArchive);
            var doctors = ApiHelper.ApiHelper.Get<List<Doctor>>("Doctors");

            var arhiveAppointments = appointments.Where(item => item.StatusId == 4);
            var Cards = new ObservableCollection<MounthPatient>();
            ArchiveAppointmentCards = new ObservableCollection<MounthPatient>();
            for (int i = 0; i <= CalculateMonthsDifference(_timeOfArchive, _timeToArchive); i++)
            {
                ObservableCollection<MounthAppointmentPatient> cards = new ObservableCollection<MounthAppointmentPatient>();
                var activeAppointmentsMounth = arhiveAppointments.Where(item =>
                    item.AppointmentDate.Month == _timeOfArchive.AddMonths(i).Month &&
                    item.AppointmentDate.Day >= _timeOfArchive.AddMonths(i).Day).ToList();
                if (activeAppointmentsMounth != null)
                {
                    for (int g = 0; g < activeAppointmentsMounth.Count(); g++)
                    {
                        MounthAppointmentPatient card = new MounthAppointmentPatient();
                        card.CurrentAppointmentId = activeAppointmentsMounth[g].IdAppointment.Value;
                        card.CycleStage = i;
                        card.NumberOfCard = g;
                        card.Date.Text = activeAppointmentsMounth[g].AppointmentDate.ToString();
                        var currDoctor = doctors.Find(item => item.IdDoctor == activeAppointmentsMounth[g].DoctorId);
                        card.Specialisation.Text = ApiHelper.ApiHelper
                            .Get<Speciality>("Specialities", currDoctor.SpecialityId.Value).NameSpecialities;
                        card.DoctorName.Text = $"{currDoctor.Surname} {currDoctor.FirstName} {currDoctor.Patronymic}";
                        card.Address.Text = currDoctor.WorkAddress;
                        card.FirstAction.Content = "Повторить";
                        // card.FirstAction.Click += "Перенести";
                        card.SecondAction.Content = "Отменить";
                        card.SecondActionClick += (sender, e) => delete(sender, e);
                        cards.Add(card);
                    }
                }
                var mounthPatient = new MounthPatient();
                mounthPatient.mounth.Text = _timeOfArchive.AddMonths(i).ToString("MMMM yyyy");
                mounthPatient.Items = cards;
                Cards.Add(mounthPatient);
                ArchiveAppointmentCards = Cards;
            }
        }
    }
}