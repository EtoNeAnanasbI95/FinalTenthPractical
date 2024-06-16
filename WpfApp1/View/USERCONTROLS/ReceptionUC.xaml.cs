﻿using System;
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

namespace FinalTenthPractical.View.USERCONTROLS
{
    /// <summary>
    /// Логика взаимодействия для ReceptionUC.xaml
    /// </summary>
    public partial class ReceptionUC : UserControl
    {
        public Action Click { get; set; }
        
        public ReceptionUC()
        {   
            InitializeComponent();
            OnClick.Click += (sender, args) => OnCardClick(sender, args);
        }

        private void OnCardClick(object sender, EventArgs e)
        {
            Click?.Invoke();
        }

    }
}
