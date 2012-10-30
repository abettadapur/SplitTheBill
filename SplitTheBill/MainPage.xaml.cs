using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Coding4Fun.Phone.Controls;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Shell;

namespace SplitTheBill
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
        bool isbacknav = false;
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            isbacknav = false;
            if (PhoneApplicationService.Current.State.ContainsKey("isBackNav"))
            {
                isbacknav = (bool)PhoneApplicationService.Current.State["isBackNav"];
                PhoneApplicationService.Current.State["isBackNav"] = false;
            }
        }

        private void ImageUp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            peopleSlider.Value++;
        }
        private void ImageDown_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (peopleSlider.Value > 2) 
            peopleSlider.Value--;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void peopleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (peopleSlider.Value < 2)
                peopleSlider.Value = 2;
           sliderBlock.Text= peopleSlider.Value +"" ;
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (isbacknav)
            {
                //int prevPeople = (int)settings["people"];

                //settings["people"] = (int)peopleSlider.Value - prevPeople;
                //MessageBox.Show((int)settings["people"] + "");
                settings["people"] = (int)peopleSlider.Value;
                NavigationService.Navigate(new Uri("/PurchasePage.xaml", UriKind.Relative));

            }
            else
            {
                int people = (int)peopleSlider.Value;

                settings.Add("people", people);
                NavigationService.Navigate(new Uri("/PurchasePage.xaml", UriKind.Relative));
            }
        }

       
    }
}