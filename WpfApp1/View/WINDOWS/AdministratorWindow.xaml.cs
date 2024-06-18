using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using EMIAS.Models;
using FinalTenthPractical.Properties;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WpfApp1;
using WpfApp1.ViewModel;
using WpfApp1.ViewModel.ApiHelper;

namespace FinalTenthPractical.View
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow()
        {
            InitializeComponent();
            DataContext = new AdminViewModel();
        }

/*        public AdminViewModel viewmodel;*/

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OnPageSelector(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
            var viewmodel = DataContext as AdminViewModel;

            if (selectedItem != null)
            {
                switch (selectedItem.Content.ToString())
                {
                    case "Пользователь":
                        FrameAdmin.Navigate(new PAGES.AdminPatientLBPage(DataContext));
                        HumanGrid.ItemsSource = ApiHelper.Get<ObservableCollection<Patient>>("Patients");
                        viewmodel.SelectedIndexCombo = comboBox.SelectedIndex;
                        break;
                    case "Сотрудник":
                        FrameAdmin.Navigate(new PAGES.AdminDoctorLBPage(DataContext));
                        HumanGrid.ItemsSource = ApiHelper.Get<ObservableCollection<Doctor>>("Doctors");
                        viewmodel.SelectedIndexCombo = comboBox.SelectedIndex;
                        break; 
                    case "Администратор":
                        FrameAdmin.Navigate(new PAGES.AdminPage(DataContext));
                        HumanGrid.ItemsSource = ApiHelper.Get<ObservableCollection<Admin>>("Admins");
                        viewmodel.SelectedIndexCombo = comboBox.SelectedIndex;
                        break;
                }
            }
        }
        
        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.CurrentTheme == "Dark")
            {
                App.Theme = "Light";
            }
            else
            {
                App.Theme = "Dark";
            }
        }

        private void RollUpButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UnwrapButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (WindowState == WindowState.Normal)
                    WindowState = WindowState.Maximized;
                else
                    WindowState = WindowState.Normal;
            }
        }

        private void HumanGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewmodel = DataContext as AdminViewModel;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    viewmodel.selectedpatient = HumanGrid.SelectedItem as Patient;
                    viewmodel.SelectedIndexData = HumanGrid.SelectedIndex;
                    break;
                case 1:
                    viewmodel.selecteddoctor = HumanGrid.SelectedItem as Doctor;
                    viewmodel.SelectedIndexData = HumanGrid.SelectedIndex;
                    break;
                case 2:
                    viewmodel.selectedadmin = HumanGrid.SelectedItem as Admin;
                    viewmodel.SelectedIndexData = HumanGrid.SelectedIndex;
                    break;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var viewmodel = DataContext as AdminViewModel;
            viewmodel.Create();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var viewmodel = DataContext as AdminViewModel;
            viewmodel.Delete();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewmodel = DataContext as AdminViewModel;
            viewmodel.Update();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            var viewmodel = DataContext as AdminViewModel;
            viewmodel.Exit();
            Close();
        }
    }
}
