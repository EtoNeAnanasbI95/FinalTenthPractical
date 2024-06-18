using EMIAS.Models;
using FinalTenthPractical.View;
using FinalTenthPractical.View.PAGES;
using Newtonsoft.Json;
using Spire.Pdf.Security;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;

namespace WpfApp1.ViewModel;

public class AdminViewModel : ApiHelper.ApiHelper, INotifyPropertyChanged
{
    private string _LoginOfAdmin;

    AdminPatient patpage = new AdminPatient(null);
    AdminDoctor docpage = new AdminDoctor(null);
    AdminAdministrator adminpage = new AdminAdministrator(null);

    public string LoginOfAdmin
    {
        get => _LoginOfAdmin;
        set => SetField(ref _LoginOfAdmin, value);
    }
    private string _PasswordAdmin;

    public string PasswordAdmin
    {
        get => _PasswordAdmin;
        set => SetField(ref _PasswordAdmin, value);
    }

    public event EventHandler GodoctorPage;

    public void AuthAdmin(object sender, EventArgs e)
    {
        Console.WriteLine("Try auth");
        try
        {
            var admin = Get<Admin>("Admins", Convert.ToInt32(LoginOfAdmin));
            if (admin.EnterPassword == PasswordAdmin) GodoctorPage?.Invoke(this, EventArgs.Empty);
            Console.WriteLine("Auth successful");
        }
        catch (Exception) { Console.WriteLine("Auth bad request"); }
    }

    private int _selectedIndexCombo;
    public int SelectedIndexCombo
    {
        get { return _selectedIndexCombo; }
        set
        {
            if (_selectedIndexCombo != value)
            {
                _selectedIndexCombo = value;
                OnPropertyChanged();
            }
        }
    }

    private int _selectedIndexData;
    public int SelectedIndexData
    {
        get { return _selectedIndexData; }
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
    private string oms;
    public string Oms
    {
        get { return oms; }
        set
        {
            oms = value;
            OnPropertyChanged();
        }
    }

    private string surname;
    public string Surname
    {
        get { return surname; }
        set
        {
            surname = value;
            OnPropertyChanged();
        }
    }

    private string firstname;
    public string Firstname
    {
        get { return firstname; }
        set
        {
            firstname = value;
            OnPropertyChanged();
        }
    }

    private string patronymic;
    public string Patronymic
    {
        get { return patronymic; }
        set
        {
            patronymic = value;
            OnPropertyChanged();
        }
    }

    private string password;
    public string Password
    {
        get { return password; }
        set
        {
            password = value;
            OnPropertyChanged();
        }
    }

    private string birthday;
    public string Birthday
    {
        get { return birthday; }
        set
        {
            birthday = value;
            OnPropertyChanged();
        }
    }

    private string livaddr;
    public string Livaddr
    {
        get { return livaddr; }
        set
        {
            livaddr = value;
            OnPropertyChanged();
        }
    }

    private string workaddr;
    public string Workaddr
    {
        get { return workaddr; }
        set
        {
            workaddr = value;
            OnPropertyChanged();
        }
    }

    private int special;
    public int Special
    {
        get { return special; }
        set
        {
            special = value;
            OnPropertyChanged();
        }
    }

    public AdminViewModel()
    {
        
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
                Patient patient = new Patient();
                patient.Oms = Convert.ToInt64(oms);
                patient.Surname = surname;
                patient.FirstName = firstname;
                patient.Patronymic = patronymic;
                patient.BirthDay = DateOnly.Parse(birthday);
                patient.AddressPatient = livaddr;
                check = Post<Patient>(JsonConvert.SerializeObject(patient), "Patients");
                MessageBox.Show(check.ToString());
                break;
            case 1:
                Doctor doctor = new Doctor();
                doctor.EnterPassword = password;
                doctor.Surname = surname;
                doctor.FirstName = firstname;
                doctor.Patronymic = patronymic;
                doctor.SpecialityId = special;
                doctor.WorkAddress = workaddr;
                check = Post<Doctor>(JsonConvert.SerializeObject(doctor), "Doctors");
                MessageBox.Show(check.ToString());
                break;
            case 2:
                Admin admin = new Admin();
                admin.EnterPassword = password;
                admin.SurnameAdmin = surname;
                admin.FirstName = firstname;
                admin.Patronymic = patronymic;
                check = Post<Admin>(JsonConvert.SerializeObject(admin), "Admins");
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
                Patient patient = Get<Patient>("Patients", (int)selectedpatient.Oms);
                patient.Oms = oms != null && oms != "" ? Convert.ToInt64(oms) : selectedpatient.Oms;
                patient.Surname = surname != null && surname != "" ? surname : selectedpatient.Surname;
                patient.FirstName = firstname != null && firstname != "" ? firstname : selectedpatient.FirstName;
                patient.Patronymic = patronymic != null && patronymic != "" ? patronymic : selectedpatient.Patronymic;
                patient.BirthDay = birthday != null && birthday != "" ? DateOnly.Parse(birthday) : selectedpatient.BirthDay;
                patient.AddressPatient = livaddr != null && livaddr != "" ? livaddr : selectedpatient.AddressPatient;
                check = Put<Patient>(JsonConvert.SerializeObject(patient), "Patients", (int)selectedpatient.Oms);
                MessageBox.Show(check.ToString());
                break;
            case 1:
                Doctor doctor = Get<Doctor>("Doctors", (int)selecteddoctor.IdDoctor);
                doctor.EnterPassword = password != null && password != "" ? password : selecteddoctor.EnterPassword;
                doctor.Surname = surname != null && surname != "" ? surname : selecteddoctor.Surname;
                doctor.FirstName = firstname != null && firstname != "" ? firstname : selecteddoctor.FirstName;
                doctor.Patronymic = patronymic != null && patronymic != "" ? patronymic : selecteddoctor.Patronymic;
                doctor.SpecialityId = special > -1 ? special : selecteddoctor.SpecialityId;
                doctor.WorkAddress = workaddr != null && workaddr != "" ? workaddr : selecteddoctor.WorkAddress;
                check = Put<Doctor>(JsonConvert.SerializeObject(doctor), "Doctors", (int)selecteddoctor.IdDoctor);
                MessageBox.Show(check.ToString());
                break;
            case 2:
                Admin admin = Get<Admin>("Admins", (int)selectedadmin.IdAdmin);
                admin.EnterPassword = password != null && password != "" ? password : selectedadmin.EnterPassword;
                admin.SurnameAdmin = surname != null && surname != "" ? surname : selectedadmin.SurnameAdmin;
                admin.FirstName = firstname != null && firstname != "" ? firstname : selectedadmin.FirstName;
                admin.Patronymic = patronymic != null && patronymic != "" ? patronymic : selectedadmin.Patronymic;
                check = Put<Admin>(JsonConvert.SerializeObject(admin), "Admins", (int)selectedadmin.IdAdmin);
                MessageBox.Show(check.ToString());
                break;
        }
    }

    public void Delete()
    {
        bool check = false;
        switch (SelectedIndexCombo)
        {
            case 0:
                check = Delete<Patient>("Patients", (int)selectedpatient.Oms);
                MessageBox.Show(check.ToString());
                break;
            case 1:
                Read();
                check = Delete<Doctor>("Doctors", (int)selecteddoctor.IdDoctor);
                MessageBox.Show(check.ToString());
                break;
            case 2:
                Read();
                check = Delete<Admin>("Admins", (int)selectedadmin.IdAdmin);
                MessageBox.Show(check.ToString());
                break;
        }
    }

    public void Exit()
    {
        _LoginOfAdmin = null;
        _PasswordAdmin = null;
        AuthorizationWindow authorizationWindow = new AuthorizationWindow();
        authorizationWindow.Show();
    }
}