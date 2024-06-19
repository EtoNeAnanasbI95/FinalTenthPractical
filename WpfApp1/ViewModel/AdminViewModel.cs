using System.ComponentModel;
using System.Windows;
using EMIAS.Models;
using FinalTenthPractical.View.PAGES;
using Newtonsoft.Json;
using SecondLibPractice;

namespace WpfApp1.ViewModel;

public class AdminViewModel : BindingHelper
{
    private string _LoginOfAdmin;
    private string _PasswordAdmin;

    private int _selectedIndexCombo;

    private int _selectedIndexData;
    private readonly AdminPage adminpage = new(null);

    private string birthday;
    private readonly AdminDoctorLBPage docpage = new(null);

    private string firstname;

    private string livaddr;
    private string oms;

    private string password;

    private readonly AdminPatientLBPage patpage = new(null);

    private string patronymic;

    private int special;

    private string surname;

    private string workaddr;

    public string LoginOfAdmin
    {
        get => _LoginOfAdmin;
        set => SetField(ref _LoginOfAdmin, value);
    }

    public string PasswordAdmin
    {
        get => _PasswordAdmin;
        set => SetField(ref _PasswordAdmin, value);
    }

    public int SelectedIndexCombo
    {
        get => _selectedIndexCombo;
        set
        {
            if (_selectedIndexCombo != value)
            {
                _selectedIndexCombo = value;
                OnPropertyChanged();
            }
        }
    }

    public int SelectedIndexData
    {
        get => _selectedIndexData;
        set
        {
            if (_selectedIndexData != value)
            {
                _selectedIndexData = value;
                OnPropertyChanged();
            }
        }
    }

    public Admin selectedadmin { get; set; }
    public Patient selectedpatient { get; set; }
    public Doctor selecteddoctor { get; set; }

    public string Oms
    {
        get => oms;
        set
        {
            oms = value;
            OnPropertyChanged();
        }
    }

    public string Surname
    {
        get => surname;
        set
        {
            surname = value;
            OnPropertyChanged();
        }
    }

    public string Firstname
    {
        get => firstname;
        set
        {
            firstname = value;
            OnPropertyChanged();
        }
    }

    public string Patronymic
    {
        get => patronymic;
        set
        {
            patronymic = value;
            OnPropertyChanged();
        }
    }

    public string Password
    {
        get => password;
        set
        {
            password = value;
            OnPropertyChanged();
        }
    }

    public string Birthday
    {
        get => birthday;
        set
        {
            birthday = value;
            OnPropertyChanged();
        }
    }

    public string Livaddr
    {
        get => livaddr;
        set
        {
            livaddr = value;
            OnPropertyChanged();
        }
    }

    public string Workaddr
    {
        get => workaddr;
        set
        {
            workaddr = value;
            OnPropertyChanged();
        }
    }

    public int Special
    {
        get => special;
        set
        {
            special = value;
            OnPropertyChanged();
        }
    }

    public event EventHandler GodoctorPage;

    public void AuthAdmin(object sender, EventArgs e)
    {
        try
        {
            var admin = ApiHelper.ApiHelper.Get<Admin>("Admins", Convert.ToInt32(LoginOfAdmin));
            if (admin.EnterPassword == PasswordAdmin) GodoctorPage?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception)
        {
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Read()
    {
        switch (SelectedIndexCombo)
        {
            case 0:
                patpage.OMS.Text = selectedpatient.Oms.ToString();
                patpage.Surname.Text = selectedpatient.Surname;
                patpage.Firstname.Text = selectedpatient.FirstName;
                patpage.Patro.Text = selectedpatient.Patronymic;
                patpage.BirthDay.Text = selectedpatient.BirthDay.ToString();
                patpage.Addr.Text = selectedpatient.AddressPatient;
                break;
            case 1:
                selecteddoctor.EnterPassword = docpage.Password.Text;
                selecteddoctor.Surname = docpage.Surname.Text;
                selecteddoctor.FirstName = docpage.Firstname.Text;
                selecteddoctor.Patronymic = docpage.Patro.Text;
                selecteddoctor.SpecialityId = docpage.Combo.SelectedIndex;
                break;
            case 2:
                selectedadmin.EnterPassword = adminpage.Password.Text;
                selectedadmin.SurnameAdmin = adminpage.Surname.Text;
                selectedadmin.FirstName = adminpage.Firstname.Text;
                selectedadmin.Patronymic = adminpage.Patro.Text;
                break;
        }
    }

    public void Create()
    {
        bool check;

        switch (SelectedIndexCombo)
        {
            case 0:
                var patient = new Patient();
                patient.Oms = Convert.ToInt64(oms);
                patient.Surname = surname;
                patient.FirstName = firstname;
                patient.Patronymic = patronymic;
                patient.BirthDay = DateOnly.Parse(birthday);
                patient.AddressPatient = livaddr;
                check = ApiHelper.ApiHelper.Post<Patient>(JsonConvert.SerializeObject(patient), "Patients");
                MessageBox.Show(check.ToString());
                break;
            case 1:
                var doctor = new Doctor();
                doctor.EnterPassword = password;
                doctor.Surname = surname;
                doctor.FirstName = firstname;
                doctor.Patronymic = patronymic;
                doctor.SpecialityId = special;
                doctor.WorkAddress = workaddr;
                check = ApiHelper.ApiHelper.Post<Doctor>(JsonConvert.SerializeObject(doctor), "Doctors");
                MessageBox.Show(check.ToString());
                break;
            case 2:
                var admin = new Admin();
                admin.EnterPassword = password;
                admin.SurnameAdmin = surname;
                admin.FirstName = firstname;
                admin.Patronymic = patronymic;
                check = ApiHelper.ApiHelper.Post<Admin>(JsonConvert.SerializeObject(admin), "Admins");
                MessageBox.Show(check.ToString());
                break;
        }
    }

    public void Update()
    {
        bool check;

        switch (SelectedIndexCombo)
        {
            case 0:
                var patient = ApiHelper.ApiHelper.Get<Patient>("Patients", (int)selectedpatient.Oms);
                patient.Oms = oms != null && oms != "" ? Convert.ToInt64(oms) : selectedpatient.Oms;
                patient.Surname = surname != null && surname != "" ? surname : selectedpatient.Surname;
                patient.FirstName = firstname != null && firstname != "" ? firstname : selectedpatient.FirstName;
                patient.Patronymic = patronymic != null && patronymic != "" ? patronymic : selectedpatient.Patronymic;
                patient.BirthDay = birthday != null && birthday != ""
                    ? DateOnly.Parse(birthday)
                    : selectedpatient.BirthDay;
                patient.AddressPatient = livaddr != null && livaddr != "" ? livaddr : selectedpatient.AddressPatient;
                check = ApiHelper.ApiHelper.Put<Patient>(JsonConvert.SerializeObject(patient), "Patients",
                    (int)selectedpatient.Oms);
                MessageBox.Show(check.ToString());
                break;
            case 1:
                var doctor = ApiHelper.ApiHelper.Get<Doctor>("Doctors", (int)selecteddoctor.IdDoctor);
                doctor.EnterPassword = password != null && password != "" ? password : selecteddoctor.EnterPassword;
                doctor.Surname = surname != null && surname != "" ? surname : selecteddoctor.Surname;
                doctor.FirstName = firstname != null && firstname != "" ? firstname : selecteddoctor.FirstName;
                doctor.Patronymic = patronymic != null && patronymic != "" ? patronymic : selecteddoctor.Patronymic;
                doctor.SpecialityId = special > -1 ? special : selecteddoctor.SpecialityId;
                doctor.WorkAddress = workaddr != null && workaddr != "" ? workaddr : selecteddoctor.WorkAddress;
                check = ApiHelper.ApiHelper.Put<Doctor>(JsonConvert.SerializeObject(doctor), "Doctors",
                    (int)selecteddoctor.IdDoctor);
                MessageBox.Show(check.ToString());
                break;
            case 2:
                var admin = ApiHelper.ApiHelper.Get<Admin>("Admins", (int)selectedadmin.IdAdmin);
                admin.EnterPassword = password != null && password != "" ? password : selectedadmin.EnterPassword;
                admin.SurnameAdmin = surname != null && surname != "" ? surname : selectedadmin.SurnameAdmin;
                admin.FirstName = firstname != null && firstname != "" ? firstname : selectedadmin.FirstName;
                admin.Patronymic = patronymic != null && patronymic != "" ? patronymic : selectedadmin.Patronymic;
                check = ApiHelper.ApiHelper.Put<Admin>(JsonConvert.SerializeObject(admin), "Admins",
                    (int)selectedadmin.IdAdmin);
                MessageBox.Show(check.ToString());
                break;
        }
    }

    public void Delete()
    {
        var check = false;
        switch (SelectedIndexCombo)
        {
            case 0:
                check = ApiHelper.ApiHelper.Delete<Patient>("Patients", (int)selectedpatient.Oms);
                MessageBox.Show(check.ToString());
                break;
            case 1:
                Read();
                check = ApiHelper.ApiHelper.Delete<Doctor>("Doctors", (int)selecteddoctor.IdDoctor);
                MessageBox.Show(check.ToString());
                break;
            case 2:
                Read();
                check = ApiHelper.ApiHelper.Delete<Admin>("Admins", (int)selectedadmin.IdAdmin);
                MessageBox.Show(check.ToString());
                break;
        }
    }
}