using EMIAS.Models;
using Spire.Pdf.Security;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp1.ViewModel;

public class AdminViewModel : ApiHelper.ApiHelper, INotifyPropertyChanged
{
    private string _LoginOfAdmin;

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

    private ObservableCollection<Object> admins;
    public ObservableCollection<Object> Admins
    {
        get { return admins; }
        set
        {
            admins = value;
            OnPropertyChanged(nameof(Admin));
        }
    }

    private ObservableCollection<Object> doctors;
    public ObservableCollection<Object> Doctors
    {
        get { return doctors; }
        set
        {
            doctors = value;
            OnPropertyChanged(nameof(Doctor));
        }
    }

    private ObservableCollection<Object> patiens;
    public ObservableCollection<Object> Patiens
    {
        get { return patiens; }
        set
        {
            patiens = value;
            OnPropertyChanged(nameof(Patient));
        }
    }

    private ObservableCollection<Object> _items;

    public ObservableCollection<Object> Items
    {
        get { return _items; }
        set
        {
            _items = value;
            OnPropertyChanged(nameof(Items));
        }
    }

    private int _selectedIndex;
    public int SelectedIndex
    {
        get { return _selectedIndex; }
        set
        {
            if (_selectedIndex != value)
            {
                _selectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }
    }



    public AdminViewModel()
    {
        doctors = Get<ObservableCollection<Object>>("Doctors");
        patiens = Get<ObservableCollection<Object>>("Patients");
        admins = Get<ObservableCollection<Object>>("Admins");
    }

    

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}