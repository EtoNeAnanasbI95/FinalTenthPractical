using System.IO;
using System.Windows;
using System.Windows.Documents;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View.USERCONTROLS;
using SecondLibPractice;
using Wpf.Ui.Controls;
using MessageBox = System.Windows.MessageBox;

namespace WpfApp1.ViewModel;

public class PatientAnalysDocumentsViewModel : BindingHelper
{
    public List<AnalizUC> _cards;
    public List<AnalizUC> Cards
    {
        get => _cards;
        set => SetField(ref _cards, value);
    }
    
    public FlowDocument RTB;
    
    public string _address;
    public string Address
    {
        get => _address;
        set => SetField(ref _address, value);
    }
    
    public string _date;
    public string Date
    {
        get => _date;
        set => SetField(ref _date, value);
    }
    
    public string _analysName;
    public string AnalysName
    {
        get => _analysName;
        set => SetField(ref _analysName, value);
    }

    private List<AnalysDocument> AnalysDocuments;
    private List<Appointment> Appointments = new();
    private List<Doctor> Doctors;

    public void Load()
    {
        AnalysDocuments = MainViewModel.AnalysDocuments;
        Appointments = MainViewModel.Appointments.Where(item => item.StatusId == 4 && item.Oms == Settings.Default.CurrentPatient).ToList();
        Doctors = MainViewModel.Doctors;
        Cards = new List<AnalizUC>();
        foreach (var appointment in Appointments)
        {
            AnalizUC card = new AnalizUC();
            card.Appointment = appointment;
            var curDoctor = Doctors.First(item => item.IdDoctor == appointment.DoctorId);
            card.Click += (sender, args) => GoAnalys(sender, args);
            card.Title.Text = AnalysDocuments.Find(item => item.IdAppointment == appointment.IdAppointment).DocumentName;
            card.Date.Text = appointment.AppointmentDate.ToString();
            Cards.Add(card);
        }
    }

    private void GoAnalys(object sender, EventArgs e)
    {
        var realSender = sender as AnalizUC;
        Address = Doctors.Find(item => item.IdDoctor == realSender.Appointment.DoctorId).WorkAddress;
        AnalysName = realSender.Title.Text;
        Date = realSender.Appointment.AppointmentDate.ToString();
        var document = AnalysDocuments.Find(item => item.IdAppointment == realSender.Appointment.IdAppointment);
        File.WriteAllText("buffer.rtf", document.Rtf);
        var range = new TextRange(RTB.ContentStart, RTB.ContentEnd);
        var fs = new FileStream("buffer.rtf", FileMode.Open);
        range.Load(fs, DataFormats.Rtf);
        fs.Close();
        File.Delete("buffer.rtf");
    }
}