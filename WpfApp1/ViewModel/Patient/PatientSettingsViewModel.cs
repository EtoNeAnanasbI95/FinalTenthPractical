﻿using System.IO;
using System.Windows;
using System.Windows.Controls;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using FinalTenthPractical.View.PAGES;
using Newtonsoft.Json;
using SecondLibPractice;

namespace WpfApp1.ViewModel;

public class PatientSettingsViewModel : BindingHelper
{
    public string _address;

    private string _birthDay;

    public string _email;

    public string _firstName;

    private string _fullName;

    public string _livingAddress;

    public string _phoneNumber;

    private List<Patient> _users;

    private readonly Frame MainFrame;

    private Patient user;

    public PatientSettingsViewModel()
    {
        Users = MainViewModel.Users;
    }

    public PatientSettingsViewModel(Frame frame)
    {
        MainFrame = frame;
        Users = MainViewModel.Users;
    }

    public string FullName
    {
        get => _fullName;
        set => SetField(ref _fullName, value);
    }

    public string BirthDay
    {
        get => _birthDay;
        set => SetField(ref _birthDay, value);
    }

    public string FirstName
    {
        get => _firstName;
        set => SetField(ref _firstName, value);
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set => SetField(ref _phoneNumber, value);
    }

    public string Email
    {
        get => _email;
        set => SetField(ref _email, value);
    }

    public string Address
    {
        get => _address;
        set => SetField(ref _address, value);
    }

    public string LivingAddress
    {
        get => _livingAddress;
        set => SetField(ref _livingAddress, value);
    }

    public List<Patient> Users
    {
        get => _users;
        set => SetField(ref _users, value);
    }

    public void Copy(object sender, EventArgs e)
    {
        Clipboard.SetText(LivingAddress);
    }

    public void Save(object sender, EventArgs e)
    {
        var user = Users.Find(item => item.Oms == Settings.Default.CurrentPatient);
        user.Surname = FullName.Split(' ')[0];
        user.FirstName = FullName.Split(' ')[1];
        user.Patronymic = FullName.Split(' ')[2];
        user.BirthDay = DateOnly.Parse(BirthDay);
        user.Phone = PhoneNumber;
        user.Email = Email;
        user.AddressPatient = Address;
        user.LivingAddress = LivingAddress;
        user.Nickname = FirstName;
        var json = JsonConvert.SerializeObject(Users);
        File.WriteAllText("UserData.json", json);
        json = JsonConvert.SerializeObject(user);
        var res = ApiHelper.ApiHelper.Put<Patient>(json, "Patients", Settings.Default.CurrentPatient);
        if (res) MessageBox.Show("Настройки успешно сохранены");
        else MessageBox.Show("Данные введены не верно");
    }

    public void LoadData()
    {
        Users = MainViewModel.Users;
        user = Users.Find(item => item.Oms == Settings.Default.CurrentPatient);
        FullName = $"{user.Surname} {user.FirstName} {user.Patronymic}";
        BirthDay = user.BirthDay.ToString();
        PhoneNumber = user.Phone;
        Email = user.Email;
        Address = user.AddressPatient;
        FirstName = user.Nickname;
        LivingAddress = user.LivingAddress;
    }

    public void SwithAcc(object sender, EventArgs e)
    {
        var choisedUser = (sender as ComboBox).SelectedItem as Patient;
        Settings.Default.CurrentPatient = choisedUser.Oms.Value;
        Settings.Default.Save();
        MainFrame.Navigate(new PatientAppointmentPage(MainFrame));
    }
}