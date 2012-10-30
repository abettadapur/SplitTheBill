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
using System.IO.IsolatedStorage;
using Coding4Fun.Phone.Controls;
using System.Collections.ObjectModel;
using AgiliTrain.PhoneyTools.Converters;
using Microsoft.Phone.Shell;

namespace SplitTheBill
{
    public partial class PurchasePage : PhoneApplicationPage
    {
         IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
         ObservableCollection<Person> peopleCollection;
        Party party = new Party();
        bool loaded = false;
        int selectedPerson = 0;
        bool isbacknav = false;
        public PurchasePage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isbacknav)
            {
                int people = 0;
                peopleCollection = new ObservableCollection<Person>();
                settings.TryGetValue<int>("people", out people);

                //if (people < 0)
                //{
                //    for (int i = peopleCollection.Count - 1; i > peopleCollection.Count - 1 + people; i--)
                //    {
                //        peopleCollection.RemoveAt(i);
                //    }

                for (int i = 0, j = people; i < j; i++)
                {
                    MetroFlowData data = new MetroFlowData();
                    if (i == 0)
                    {
                        data.Title = "Tap To Rename";
                    }
                    else
                        data.Title = (i + 1) + "";

                    metroFlow1.Items.Add(data);
                    peopleCollection.Add(new Person());
                    party.People = peopleCollection;

                }
            }

            

        }

        private void metroFlow1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MoneyConverter converter = new MoneyConverter();
            selectedPerson = metroFlow1.SelectedColumnIndex;
            listBox1.ItemsSource = peopleCollection[selectedPerson].Transactions;
            updateTotal();
 
        }
        private void updateTotal()
        {
            string total = String.Format("{0:C}", Convert.ToDouble(peopleCollection[selectedPerson].Total));
            totalBlock.Text = total;
        }

        private void RoundButton_Click(object sender, RoutedEventArgs e)
        {
            var trns = peopleCollection[selectedPerson].Transactions.Where(a => a.Count.Equals(((System.Windows.FrameworkElement)(e.OriginalSource)).Tag)).ToList();
            if (trns.Count == 1)
                peopleCollection[selectedPerson].Transactions.Remove(trns.First());
            peopleCollection[selectedPerson].Total -= trns.First().Amount;
            updateTotal();
        }

        private void roundButton1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value = double.Parse(textBox1.Text);
                string count;
                if (peopleCollection[selectedPerson].Transactions == null)
                    count = "0";
                else
                    count = peopleCollection[selectedPerson].Transactions.Count + "";

                peopleCollection[selectedPerson].Transactions.Add(new Transaction(count, value));
                listBox1.ItemsSource = peopleCollection[selectedPerson].Transactions;
                peopleCollection[selectedPerson].Total += value;
                updateTotal();
                textBox1.Text = "";
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Amount must be a number!");
                
            }
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            if (settings.Contains("party"))
            {
                settings["party"] = party;
            }
            else
                settings.Add("party", party);

            NavigationService.Navigate(new Uri("/TipAndTax.xaml", UriKind.Relative));
        }

        private void metroFlow1_SelectionTap(object sender, SelectionTapEventArgs e)
        {
            InputPrompt input = new InputPrompt();
            input.Completed += new EventHandler<PopUpEventArgs<string, PopUpResult>>(input_Completed);
            input.Title = "Enter Name";
            input.Show();
        }
        private void input_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        {  
            peopleCollection[selectedPerson].Name = e.Result;
            var data = metroFlow1.Items;
            int index = metroFlow1.SelectedColumnIndex;
            MetroFlowData mfdata = (MetroFlowData)data[index];
            data.Remove(mfdata);
            mfdata.Title = e.Result;
            data.Insert(index, mfdata);
            metroFlow1.SelectedColumnIndex = index;
            
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Going back at this point will cause current progress to be lost. Are you sure?", "Go Back", MessageBoxButton.OKCancel);
            if( result==MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            else

            {
                PhoneApplicationService.Current.State["isBackNav"] = true;
                NavigationService.GoBack();
            }
            
            
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (PhoneApplicationService.Current.State.ContainsKey("isBackNav"))
            {
                isbacknav = (bool)PhoneApplicationService.Current.State["isBackNav"];
            }

        }
    }
}