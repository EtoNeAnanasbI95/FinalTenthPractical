﻿using FinalTenthPractical.View.USERCONTROLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalTenthPractical.View.PAGES
{
    /// <summary>
    /// Логика взаимодействия для MedicalCardPatient.xaml
    /// </summary>
    public partial class MedicalCardPatient : Page
    {
        public MedicalCardPatient()
        {
            InitializeComponent();

            ReceptionUC th = new ReceptionUC();
            th.FirstTB.Text = "Осмотр письки";
            th.SecondTB.Text = "Пиздаворот Х.У.";
            th.ThirdTB.Text = "21 хуебря 2024 г.";

            List<Object> Cards = new List<Object>() { th };
            LBUC.ItemsSource = Cards;
        }
    }
}