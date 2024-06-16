using FinalTenthPractical.View.PAGES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace FinalTenthPractical.View
{
    /// <summary>
    /// Логика взаимодействия для Patient.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        public PatientWindow()
        {
            InitializeComponent();
            




            this.MinWidth = 718;
            this.MinHeight = 472;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow auth = new AuthorizationWindow();
            this.Close();
   
        }
     
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Settings(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

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

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Button_Settings(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new SettingsPage());
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeViewItem selectedItem)
            {
                switch (selectedItem.Header)
                {
                    case "Приёмы":
                        Frame.Navigate(new MedicalCardPatient());
                        break; 
                    case "Анализы":
                        Frame.Navigate(new MedicalCardAnaliz());
                        break; 
                    case "Исследования":
                        Frame.Navigate(new MedicalCardStudy());
                        break; 
                    case "Записи и направления":
                        Frame.Navigate(new AppointmentPatient());
                        break;
                    case "Страница выбора врача":
                        Frame.Navigate(new SelectingSpecialistPatient());
                        break;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


    }
}