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
using Microsoft.Phone.Tasks;

namespace SplitTheBill
{
    public partial class Results : PhoneApplicationPage
    {
        Party party;
        int i = 0;
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        public Results()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            settings.TryGetValue<Party>("party", out party);
            for (int i = 0, j = party.People.Count; i < j; i++)
            {
                MetroFlowData data = new MetroFlowData();
                if (party.People[i].Name == null || party.People[i].Name == "")
                    data.Title = (i + 1) + "";
                else
                    data.Title = party.People[i].Name;
                metroFlow1.Items.Add(data);
            }

            subBox.Text = String.Format("{0:C}", party.People[0].Total);
            tipBox.Text = String.Format("{0:C}", party.People[0].Total * party.TipRate);
            taxBox.Text = String.Format("{0:C}", party.People[0].Total * party.TaxRate);
            totalBox.Text = String.Format("{0:C}", party.People[0].Total + party.People[0].Total * party.TaxRate + party.People[0].Total * party.TipRate);


        }

        private void metroFlow1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            i = metroFlow1.SelectedColumnIndex;
            subBox.Text = String.Format("{0:C}", party.People[i].Total);
            tipBox.Text = String.Format("{0:C}", party.People[i].Total * party.TipRate);
            taxBox.Text = String.Format("{0:C}", party.People[i].Total * party.TaxRate);
            totalBox.Text = String.Format("{0:C}", party.People[i].Total + party.People[i].Total * party.TaxRate + party.People[i].Total * party.TipRate);
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            SmsComposeTask composeSMS = new SmsComposeTask();
            composeSMS.Body = "You Owe Tip: $" + party.People[i].Total * party.TipRate + " Tax: $" + party.People[i].Total * party.TaxRate + " Total: $" + (party.People[i].Total + party.People[i].Total * party.TipRate + party.People[i].Total * party.TaxRate);
            composeSMS.Show();
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            EmailComposeTask composeEmail = new EmailComposeTask();
            composeEmail.Body = "You Owe Tip: $" + party.People[i].Total * party.TipRate + " Tax: $" + party.People[i].Total * party.TaxRate + " Total: $" + (party.People[i].Total + party.People[i].Total * party.TipRate + party.People[i].Total * party.TaxRate);
            composeEmail.Subject = "Split The Bill";
            composeEmail.Show();
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            settings.Clear();
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            MarketplaceReviewTask review = new MarketplaceReviewTask();
            review.Show();
        }

        private void ApplicationBarIconButton_Click_3(object sender, EventArgs e)
        {
            AboutPrompt about = new AboutPrompt();
            about.Title = "SplitTheBill";
            about.Footer = "GridWorksApps@gmail.com";
            about.VersionNumber = "Version 1.0.0";
            about.Body = new TextBlock { Text="Please Rate and Review in the Marketplace.\nIcon is located below!", TextWrapping = TextWrapping.Wrap };
            //about.Completed +=new EventHandler<PopUpEventArgs<object,PopUpResult>>(about_Completed);
            about.Show();
        }
       

    }
}