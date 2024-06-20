using System.Collections.ObjectModel;
using System.Windows.Controls;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View.PAGES;
using FinalTenthPractical.View.USERCONTROLS;
using SecondLibPractice;

namespace WpfApp1.ViewModel;

public class PatientMainAppointmentViewModel : BindingHelper
{
    private ObservableCollection<MounthPatient> _appointmentCards;

    private ObservableCollection<MounthPatient> _archiveAppointmentCards;
    private readonly Frame _frame;

    private string _OMS;

    private ObservableCollection<DoctorsPatient> _specialitiesCards;

    public DateOnly _timeOf;

    public DateOnly _timeOfArchive;

    public DateOnly _timeTo;

    public DateOnly _timeToArchive;

    public PatientMainAppointmentViewModel(Frame frame)
    {
        _frame = frame;
    }

    public PatientMainAppointmentViewModel()
    {
    }

    public string OMS
    {
        get => _OMS;
        set => SetField(ref _OMS, value);
    }

    public ObservableCollection<DoctorsPatient> SpecialitiesCards
    {
        get => _specialitiesCards;
        set => SetField(ref _specialitiesCards, value);
    }

    public ObservableCollection<MounthPatient> AppointmentCards
    {
        get => _appointmentCards;
        set => SetField(ref _appointmentCards, value);
    }

    public ObservableCollection<MounthPatient> ArchiveAppointmentCards
    {
        get => _archiveAppointmentCards;
        set => SetField(ref _archiveAppointmentCards, value);
    }

    private void GoChooseDoctor(object sender, EventArgs e)
    {
        _frame.Navigate(new DateAndTimeOfAppintment(_frame, (sender as DoctorsPatient).IdSpecials));
    }

    public event EventHandler GoPatient;

    public void Auth(object sender, EventArgs e)
    {
        try
        {
            var doctor = ApiHelper.ApiHelper.Get<Patient>("Patients", Convert.ToInt32(OMS));
            Settings.Default.CurrentPatient = Convert.ToInt32(OMS);
            Settings.Default.Save();
            MainViewModel.NewUser();
            GoPatient?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception)
        {
        }
    }

    public void Specialisations()
    {
        var specialities = ApiHelper.ApiHelper.Get<List<Speciality>>("Specialities");
        SpecialitiesCards = new ObservableCollection<DoctorsPatient>();
        foreach (var item in specialities)
        {
            var doctor = new DoctorsPatient();
            doctor.IdSpecials = item.IdSpeciality.Value;
            doctor.Click += (sender, e) => GoChooseDoctor(sender, e);
            SpecialitiesCards.Add(doctor);
        }
    }

    public void DataOfPick(object sender, SelectionChangedEventArgs e)
    {
        _timeOf = DateOnly.FromDateTime((DateTime)(sender as DatePicker)!.SelectedDate!);
        ActiveAppointments();
    }

    public void DataToPick(object sender, SelectionChangedEventArgs e)
    {
        _timeTo = DateOnly.FromDateTime((DateTime)(sender as DatePicker)!.SelectedDate!);
        ActiveAppointments();
    }

    public void DataOfPickArchive(object sender, SelectionChangedEventArgs e)
    {
        _timeOfArchive = DateOnly.FromDateTime((DateTime)(sender as DatePicker)!.SelectedDate!);
        ArchiveAppointments();
    }

    public void DataToPickArchive(object sender, SelectionChangedEventArgs e)
    {
        _timeToArchive = DateOnly.FromDateTime((DateTime)(sender as DatePicker)!.SelectedDate!);
        ArchiveAppointments();
    }

    private int CalculateMonthsDifference(DateOnly startDate, DateOnly endDate)
    {
        var yearsDifference = endDate.Year - startDate.Year;
        var monthsDifference = endDate.Month - startDate.Month;

        return yearsDifference * 12 + monthsDifference;
    }

    public void ActiveAppointments()
    {
        var appointments = MainViewModel.Appointments.Where(item =>
            item.Oms == Settings.Default.CurrentPatient && item.AppointmentDate > _timeOf &&
            item.AppointmentDate < _timeTo);
        var doctors = ApiHelper.ApiHelper.Get<List<Doctor>>("Doctors");

        var arhiveAppointments = appointments.Where(item => item.StatusId == 4);
        var activeAppointments = appointments.Except(arhiveAppointments);
        var Cards = new ObservableCollection<MounthPatient>();
        ArchiveAppointmentCards = new ObservableCollection<MounthPatient>();
        for (var i = 0; i <= CalculateMonthsDifference(_timeOf, _timeTo); i++)
        {
            var cards = new ObservableCollection<MounthAppointmentPatient>();
            var currnetDate = _timeOf.AddMonths(i);
            var activeAppointmentsMounth = activeAppointments.Where(item =>
                    item.AppointmentDate.Month == currnetDate.Month && (item.AppointmentDate.Day <= currnetDate.Day ||
                                                                        item.AppointmentDate.Day >= currnetDate.Day))
                .ToList();
            for (var g = 0; g < activeAppointmentsMounth.Count(); g++)
            {
                var card = new MounthAppointmentPatient();
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
                card.SecondAction.Content = "Отменить";
                card.FirstActionClick += (sender, e) => Move(sender, e);
                card.SecondActionClick += (sender, e) => delete(sender, e);
                cards.Add(card);
            }
            var mounthPatient = new MounthPatient();
            mounthPatient.mounth.Text = _timeOf.AddMonths(i).ToString("MMMM yyyy");
            mounthPatient.Items = cards;
            Cards.Add(mounthPatient);
            AppointmentCards = Cards;
        }
    }

    private void delete(object sender, EventArgs e)
    {
        var parent = sender as MounthAppointmentPatient;
        ApiHelper.ApiHelper.Delete<Appointment>("Appointments", parent.CurrentAppointmentId);
        ApiHelper.ApiHelper.Delete<AnalysDocument>("AnalysDocuments", parent.CurrentAppointmentId);
        ApiHelper.ApiHelper.Delete<ResearchDocument>("ResearchDocuments", parent.CurrentAppointmentId);
        ApiHelper.ApiHelper.Delete<AppointmentDocument>("AppointmentDocuments", parent.CurrentAppointmentId);
        AppointmentCards[parent.CycleStage].Items.Remove(parent);
        
        MainViewModel.ReloadAppointments();
        MainViewModel.ReloadAnalysDocuments();
    }

    private void Move(object sender, EventArgs e)
    {
        var parent = sender as MounthAppointmentPatient;
        MainViewModel.AppointmentidForDelete = parent.CurrentAppointmentId;
        MainViewModel.ReloadAppointments();
        MainViewModel.ReloadAnalysDocuments();
        var appointment = MainViewModel.Appointments.Find(item => item.IdAppointment == parent.CurrentAppointmentId);
        _frame.Navigate(new DateAndTimeOfAppintment(_frame, MainViewModel.Doctors.Find(item => item.IdDoctor == appointment.DoctorId)));
    }

    public void ArchiveAppointments()
    {
        if (_timeOfArchive != DateOnly.MinValue && _timeToArchive != DateOnly.MinValue)
        {
            var appointments = MainViewModel.Appointments.Where(item =>
                item.Oms == Settings.Default.CurrentPatient && item.AppointmentDate > _timeOfArchive &&
                item.AppointmentDate < _timeToArchive);
            var doctors = MainViewModel.Doctors;

            var arhiveAppointments = appointments.Where(item => item.StatusId == 4);
            var Cards = new ObservableCollection<MounthPatient>();
            ArchiveAppointmentCards = new ObservableCollection<MounthPatient>();
            for (var i = 0; i <= CalculateMonthsDifference(_timeOfArchive, _timeToArchive); i++)
            {
                var cards = new ObservableCollection<MounthAppointmentPatient>();
                var activeAppointmentsMounth = arhiveAppointments.Where(item =>
                    item.AppointmentDate.Month == _timeOfArchive.AddMonths(i).Month &&
                    (item.AppointmentDate.Day <= _timeOfArchive.AddMonths(i).Day ||
                     item.AppointmentDate.Day >= _timeOfArchive.AddMonths(i).Day)).ToList();
                if (activeAppointmentsMounth != null)
                    for (var g = 0; g < activeAppointmentsMounth.Count(); g++)
                    {
                        var card = new MounthAppointmentPatient();
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
                        card.SecondAction.Content = "Отменить";
                        card.SecondActionClick += (sender, e) => delete(sender, e);
                        card.FirstActionClick += (sender, e) => Move(sender, e);
                        cards.Add(card);
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