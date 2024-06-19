using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View;
using FinalTenthPractical.View.USERCONTROLS;
using Newtonsoft.Json;
using SecondLibPractice;

namespace WpfApp1.ViewModel;

public class PatientChooseDoctorViewModel : BindingHelper
{
    private string _doctorName;
    public string DoctorName
    {
        get => _doctorName;
        set => SetField(ref _doctorName, value);
    }
    
    private string _doctor;
    public string Doctor
    {
        get => _doctor;
        set => SetField(ref _doctor, value);
    }

    private ObservableCollection<ToggleButton> _currentWeek;
    public ObservableCollection<ToggleButton> CurrentWeek
    {
        get => _currentWeek;
        set => SetField(ref _currentWeek, value);
    }
    
    private ObservableCollection<ToggleButton> _nextWeek;
    public ObservableCollection<ToggleButton> NextWeek
    {
        get => _nextWeek;
        set => SetField(ref _nextWeek, value);
    }
    
    private ObservableCollection<ToggleButton> _morning;
    public ObservableCollection<ToggleButton> Morning
    {
        get => _morning;
        set => SetField(ref _morning, value);
    }
    
    private ObservableCollection<ToggleButton> _day;
    public ObservableCollection<ToggleButton> Day
    {
        get => _day;
        set => SetField(ref _day, value);
    }
    
    private ObservableCollection<ToggleButton> _evening;
    public ObservableCollection<ToggleButton> Evening
    {
        get => _evening;
        set => SetField(ref _evening, value);
    }
    
    private ObservableCollection<ReceptionUC> _cards;
    public ObservableCollection<ReceptionUC> Cards
    {
        get => _cards;
        set => SetField(ref _cards, value);
    }
    
    public Frame mainFrame;
    public DoctorsPatient button;

    public PatientChooseDoctorViewModel(Frame Frame, DoctorsPatient target)
    {
        mainFrame = Frame;
        button = target;
    }
    
    public void GoBack(object sender, EventArgs e)
    {
        if (mainFrame.CanGoBack) mainFrame.GoBack();
    }
    
    private void GenerateToggleButtons()
    {
        Morning = new();
        Day = new();
        Evening = new();

        List<TimeOnly> times = busyDays.Where(item => item.AppointmentDate == GetCorrectDate(lastButtonDay.Content.ToString())).Select(item => item.AppointmentTime).ToList();
        AddButtonsToPanel(Morning, new TimeOnly(8, 00), new TimeOnly(12, 00), times);
        AddButtonsToPanel(Day, new TimeOnly(12, 10), new TimeOnly(16, 50), times);
        AddButtonsToPanel(Evening, new TimeOnly(17, 10), new TimeOnly(19, 50), times);
    }

    private void AddButtonsToPanel(ObservableCollection<ToggleButton> cards, TimeOnly timesOf, TimeOnly timesTo, List<TimeOnly> timeStrings)
    {
        while (timesOf <= timesTo)
        {
            ToggleButton toggleButton = new ToggleButton
            {
                Content = timesOf.ToString("HH:mm", CultureInfo.GetCultureInfo("ru-RU")),
                Style = style
            };
            
            if (!timeStrings.Contains(timesOf))
            {
                toggleButton.Click += (sender, e) => DisableAllButtonsHour(sender, e);
                cards.Add(toggleButton);
            }
            timesOf = timesOf.AddMinutes(10);
        }
    }

    private Style style;
    private IEnumerable<Appointment> busyDays;
    private int _doctorId;

    public void LoadRoutine(int doctorId)
    {
        _doctorId = doctorId;
        var doc = MainViewModel.Doctors.Find(item => item.IdDoctor == doctorId);
        busyDays = MainViewModel.Appointments.Where(item => item.DoctorId == doctorId);
        DoctorName = $"{doc.Surname} {doc.FirstName} {doc.Patronymic}";
        style = Application.Current.TryFindResource("ClearToggleButton") as Style;
        CurrentWeek = new();
        for (int i = 0; i < 7; i++)
        {
            DateTime date = DateTime.Now.AddDays(i);
            string dayOfWeek = date.ToString("ddd", new CultureInfo("ru-RU")).Substring(0, 2);
            string content = $"{date.Day} {date.ToString("MMMM", new CultureInfo("ru-RU"))}, {dayOfWeek}";

            ToggleButton toggleButton = new ToggleButton
            {
                Content = content,
                Style = style
            };
            toggleButton.Click += (sender, e) => DisableAllButtonsDay(sender, e);
            CurrentWeek.Add(toggleButton);
        }

        NextWeek = new();
        for (int i = 7; i < 14; i++)
        {
            DateTime date = DateTime.Now.AddDays(i);
            string dayOfWeek = date.ToString("ddd", new CultureInfo("ru-RU")).Substring(0, 2);
            string content = $"{date.Day} {date.ToString("MMMM", new CultureInfo("ru-RU"))}, {dayOfWeek}";

            ToggleButton toggleButton = new ToggleButton
            {
                Content = content,
                Style = style
            };
            toggleButton.Click += (sender, e) => DisableAllButtonsDay(sender, e);
            NextWeek.Add(toggleButton);
        }
    }

    private ToggleButton lastButtonDay;
    private ToggleButton lastButtonHour;

    private void DisableAllButtonsDay(object sender, EventArgs e)
    {
        if (lastButtonDay == null) lastButtonDay = new();
        lastButtonDay.IsChecked = false;
        lastButtonDay = sender as ToggleButton;
        GenerateToggleButtons();
    }
    
    private void DisableAllButtonsHour(object sender, EventArgs e)
    {
        if (lastButtonHour == null) lastButtonHour = new();
        lastButtonHour.IsChecked = false;
        lastButtonHour = sender as ToggleButton;
    }

    public void Load()
    {
        var Doctors =
            ApiHelper.ApiHelper.Get<List<Doctor>>("Doctors").Where(item => item.SpecialityId == button.IdSpecials);
        Cards = new ObservableCollection<ReceptionUC>();
        foreach (var doctor in Doctors)
        {
            ReceptionUC card = new ReceptionUC();
            card.Title.Text = $"{doctor.Surname} {doctor.FirstName} {doctor.Patronymic}";
            card.doctorName.Text = "Ближайшая дата";
            card.Date.Text = "pass";
            card.Address.Text = doctor.WorkAddress;
            card.Click += (sender, args) => GoDoc(sender, args);
            card.AppointmentId = doctor.IdDoctor.Value;
            Cards.Add(card);
        }
    }

    public void SendAppointment(object sender, EventArgs e)
    {
        if (lastButtonDay != null && lastButtonHour != null)
        {
            var appointment = new Appointment();
            appointment.Oms = Settings.Default.CurrentPatient;
            appointment.AppointmentDate = GetCorrectDate(lastButtonDay.Content.ToString());
            appointment.AppointmentTime = TimeOnly.Parse(lastButtonHour.Content.ToString());
            appointment.DoctorId = _doctorId;
            appointment.StatusId = 1;

            var response =
                ApiHelper.ApiHelper.Post<Appointment>(JsonConvert.SerializeObject(appointment), "Appointments");

            if (response)
                MessageBox.Show(
                    $"Вы успешно записаны на приём {GetCorrectDate(lastButtonDay.Content.ToString()).ToString()}");
            else MessageBox.Show("Что-то пошло не так");
        }
        else MessageBox.Show("Некорректный ввод");
    }

    private void GoDoc(object sender, EventArgs e)
    {
        LoadRoutine((sender as ReceptionUC).AppointmentId);
    }

    private DateOnly GetCorrectDate(string date)
    {
        DateTime dateTime;
        const string format = "dd MMMM, ddd";
        CultureInfo ruCulture = new CultureInfo("ru-RU");
        DateTime.TryParseExact(lastButtonDay.Content.ToString(), format, ruCulture, DateTimeStyles.None, out dateTime);
        return DateOnly.FromDateTime(dateTime);
    }
}