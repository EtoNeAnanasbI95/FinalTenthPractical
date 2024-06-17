using EMIAS.Models;
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

    AdminPatient patpage = new AdminPatient();
    AdminDoctor docpage = new AdminDoctor();
    AdminAdministrator adminpage = new AdminAdministrator();

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
                OnPropertyChanged(nameof(SelectedIndexCombo));
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
                OnPropertyChanged(nameof(SelectedIndexData));
            }
        }
    }

    public Admin selectedadmin { get; set; }
    public Patient selectedpatient { get; set; }
    public Doctor selecteddoctor { get; set; }

    public AdminViewModel()
    {
        selectedpatient = new Patient();
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
                selectedpatient.Oms = long.Parse(patpage.OMS.Text);
                selectedpatient.Surname = patpage.Surname.Text;
                selectedpatient.FirstName = patpage.Firstname.Text;
                selectedpatient.Patronymic = patpage.Patro.Text;
                selectedpatient.BirthDay = DateOnly.Parse(patpage.BirthDay.Text);
                selectedpatient.LivingAddress = patpage.Addr.Text;
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
        bool check = false;

        switch (SelectedIndexCombo)
        {
            case 0:
                Read();
                check = Post<Patient>(JsonConvert.SerializeObject(selectedpatient), "Patients");
                MessageBox.Show(check.ToString());
                break;
            case 1:
                Read();
                check = Post<Doctor>(JsonConvert.SerializeObject(selecteddoctor), "Doctors");
                break;
            case 2:
                Read();
                check = Post<Admin>(JsonConvert.SerializeObject(selectedadmin), "Admins");
                break;
        }
    }
    public void Update()
    {
        bool check = false;

        switch (SelectedIndexCombo)
        {
            case 0:
                Read();
                check = Post<Patient>(JsonConvert.SerializeObject(selectedpatient), "Patients");
                MessageBox.Show(check.ToString());
                break;
            case 1:
                Read();
                check = Post<Doctor>(JsonConvert.SerializeObject(selecteddoctor), "Doctors");
                break;
            case 2:
                Read();
                check = Post<Admin>(JsonConvert.SerializeObject(selectedadmin), "Admins");
                break;
        }
    }

    public void Delete()
    {
        bool check = false;
        switch (SelectedIndexCombo)
        {
            case 0:
                check = Delete<Patient>("Patients", SelectedIndexData);
                MessageBox.Show(check.ToString());
                break;
            case 1:
                Read();
                check = Delete<Doctor>("Doctors", SelectedIndexData);
                MessageBox.Show(check.ToString());
                break;
            case 2:
                Read();
                check = Delete<Admin>("Admins", SelectedIndexData);
                MessageBox.Show(check.ToString());
                break;
        }
    }
}