using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View.USERCONTROLS;
using Microsoft.Win32;
using SecondLibPractice;
using Spire.Doc;

namespace WpfApp1.ViewModel;

public class PatientResearchDocumentsViewModel : BindingHelper
{
    private string _address;

    private List<ReceptionUC> _cards;

    private string _dateTime;

    private string _doc;

    private string _doctorName;

    private bool _download;

    private int _id;

    private string _title;
    private List<Appointment> Appointments = new();
    private List<Doctor> Doctors;

    private List<ResearchDocument> ResearchDocuments;
    public FlowDocument RTB = new();

    public PatientResearchDocumentsViewModel()
    {
        Download = false;
    }

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

    public bool Download
    {
        get => _download;
        set => SetField(ref _download, value);
    }

    public void Load()
    {
        ResearchDocuments =
            ApiHelper.ApiHelper.Get<List<ResearchDocument>>("ResearchDocuments");
        Appointments =
            MainViewModel.Appointments
                .Where(item => item.StatusId == 4 && item.Oms == Settings.Default.CurrentPatient).ToList();
        Doctors =
            ApiHelper.ApiHelper.Get<List<Doctor>>("Doctors");
        Cards = new List<ReceptionUC>();
        foreach (var appointment in Appointments)
            if (ResearchDocuments.Find(item => item.IdAppointment == appointment.IdAppointment) != null)
            {
                var card = new ReceptionUC();
                var curDoctor = Doctors.First(item => item.IdDoctor == appointment.DoctorId);
                card.doctorName.Text =
                    $"{curDoctor.Surname} {curDoctor.FirstName.Substring(0, 1).ToUpper()} {curDoctor.Patronymic.Substring(0, 1).ToUpper()}";
                card.Address.Text = curDoctor.WorkAddress;
                card.Date.Text = appointment.AppointmentDate.ToString();
                card.Title.Text = ResearchDocuments.First(item => item.IdAppointment == appointment.IdAppointment)
                    .DocumentName;
                card.Click += (sender, args) => GoDoc(sender, args);
                card.AppointmentId = appointment.IdAppointment.Value;
                Cards.Add(card);
            }
    }

    private void GoDoc(object sender, EventArgs e)
    {
        var card = sender as ReceptionUC;
        var document = ResearchDocuments.Find(item => item.IdAppointment == card.AppointmentId);
        _id = card.AppointmentId;
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
        Download = true;
    }

    public void GoDownload(object sender, EventArgs e)
    {
        var attachment = ResearchDocuments.Find(item => item.IdAppointment == _id).Attachment;
        if (attachment != null)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg;*.jpeg)|*.jpg;*.jpeg|Bitmap Image (*.bmp)|*.bmp",
                Title = "Save an Image File"
            };
            var result = dialog.ShowDialog();
            if (result == true)
            {
                var ms = new MemoryStream(ResearchDocuments.Find(item => item.IdAppointment == _id).Attachment);
                var image = Image.FromStream(ms);
                try
                {
                    image.Save(dialog.FileName);
                }
                catch (Exception ex)
                {
                }

                ms.Dispose();
            }
        }
        else
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Word file (*.docx)|*.docx|All files (*.*)|*.*",
                Title = "Save a Word File"
            };
            var result = dialog.ShowDialog();
            if (result == true)
            {
                var range = new TextRange(RTB.ContentStart, RTB.ContentEnd);
                var fs = new FileStream("buffer.rtf", FileMode.Create);
                range.Save(fs, DataFormats.Rtf);
                fs.Close();

                var doc = new Document();
                doc.LoadFromFile("buffer.rtf");
                doc.SaveToFile(dialog.FileName, FileFormat.Docx);
                File.Delete("buffer.rtf");
            }
        }
    }
}