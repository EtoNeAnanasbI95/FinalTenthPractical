﻿using EMIAS.Models;

namespace WpfApp1.ViewModel;

public static class MainViewModel
{
    public static List<AnalysDocument> AnalysDocuments;

    // = ApiHelper.ApiHelper.Get<List<AnalysDocument>>("AnalysDocuments");
    public static List<Appointment> Appointments;

    // = ApiHelper.ApiHelper.Get<List<Appointment>>("Appointments");
    public static List<Doctor> Doctors;
    // = ApiHelper.ApiHelper.Get<List<Doctor>>("Doctors");
}