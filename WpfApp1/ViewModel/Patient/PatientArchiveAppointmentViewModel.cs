using System.IO;
using System.Windows;
using System.Windows.Documents;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View.USERCONTROLS;
using SecondLibPractice;

namespace WpfApp1.ViewModel;

public class PatientArchiveAppointmentViewModel : BindingHelper
{
    private string _address;

    private List<ReceptionUC> _cards;
    private string _dateTime;
    private string _doc;
    private string _doctorName;

    private string _title;

    private List<AppointmentDocument> AppointmentDocuments;
    private List<Appointment> Appointments = new();
    private List<Doctor> Doctors;
    public FlowDocument RTB = new();

    public List<ReceptionUC> Cards
    {
        get => _cards;
        set => SetField(ref _cards, value);
    }

    public string Title
    {
        get => _title;
        set => SetField(ref _title, value);
    }

    public string Address
    {
        get => _address;
        set => SetField(ref _address, value);
    }

    public string doc
    {
        get => _doc;
        set => SetField(ref _doc, value);
    }

    public string DoctorName
    {
        get => _doctorName;
        set => SetField(ref _doctorName, value);
    }

    public string DateTime
    {
        get => _dateTime;
        set => SetField(ref _dateTime, value);
    }

    public void Load()
    {
        AppointmentDocuments =
            ApiHelper.ApiHelper.Get<List<AppointmentDocument>>("AppointmentDocuments");
        Appointments = MainViewModel.Appointments
            .Where(item => item.StatusId == 4 && item.Oms == Settings.Default.CurrentPatient).ToList();
        Doctors = MainViewModel.Doctors;
        Cards = new List<ReceptionUC>();
        foreach (var appointment in Appointments)
        {
            var card = new ReceptionUC();
            var curDoctor = Doctors.First(item => item.IdDoctor == appointment.DoctorId);
            card.doctorName.Text =
                $"{curDoctor.Surname} {curDoctor.FirstName.Substring(0, 1).ToUpper()} {curDoctor.Patronymic.Substring(0, 1).ToUpper()}";
            card.Address.Text = curDoctor.WorkAddress;
            card.Date.Text = appointment.AppointmentDate.ToString();
            card.Title.Text = AppointmentDocuments.First(item => item.IdAppointment == appointment.IdAppointment).DocumentName;
            card.Click += (sender, args) => GoDoc(sender, args);
            card.AppointmentId = appointment.IdAppointment.Value;
            Cards.Add(card);
        }
    }

    private void GoDoc(object sender, EventArgs e)
    {
        var card = sender as ReceptionUC;
        var document = AppointmentDocuments.Find(item => item.IdAppointment == card.AppointmentId);
        File.WriteAllText("buffer.rtf", document.Rtf);
        var range = new TextRange(RTB.ContentStart, RTB.ContentEnd);
        var fs = new FileStream("buffer.rtf", FileMode.Open);
        range.Load(fs, DataFormats.Rtf);
        fs.Close();
        File.Delete("buffer.rtf");

        Title = card.Title.Text;
        Address = card.Address.Text;
        DoctorName = card.doctorName.Text;
        DateTime = card.Date.Text;
        doc = "Врач";
    }
}