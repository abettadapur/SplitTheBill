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
using Microsoft.Phone.Shell;

namespace SplitTheBill
{
    public partial class TipAndTax : PhoneApplicationPage
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        Party party;
        public TipAndTax()
        {
            InitializeComponent();
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Results.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            settings.TryGetValue<Party>("party", out party);
            subBlock.Text = String.Format("{0:C}", party.computeSubTotal());
            tipBlock.Text = String.Format("{0:C}",party.computeTip(0.0));
            taxBlock.Text = String.Format("{0:C}",party.computeTax(0.0));
            tot1Block.Text = String.Format("{0:C}" , party.computeTotal());
            tot2Block.Text = String.Format("{0:C}", party.computeTotal());
        }

        private void tipSliderBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                string ratestr = tipSliderBlock.Text;
                ratestr = ratestr.Trim();
                double rate;
                if (ratestr == "." || ratestr == "")
                    rate = 0.0;
                else
                    rate = double.Parse(ratestr);

                tipBlock.Text = String.Format("{0:C}", party.computeTip(rate));
                double wotip = party.computeTotal() - party.Tip;
                tot1Block.Text = String.Format("{0:C}", wotip);
                tot2Block.Text = String.Format("{0:C}", party.Total);
            }
            catch (Exception ex)
            {
                tipSliderBlock.Text = "";
            }
        }

        private void sliderBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string ratestr = sliderBlock.Text;
                ratestr = ratestr.Trim();
                double rate;
                if (ratestr == "" || ratestr == ".")
                {
                    rate = 0.0;
                }
                else
                    rate = double.Parse(ratestr);

                taxBlock.Text = String.Format("{0:C}", party.computeTax(rate));
                double wotip = party.computeTotal() - party.Tip;
                tot1Block.Text = String.Format("{0:C}", wotip);
                tot2Block.Text = String.Format("{0:C}", party.Total);
            }
            catch (Exception ex)
            {
                sliderBlock.Text = "";
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            PhoneApplicationService.Current.State["isBackNav"] = true;

        }


       

       
    }
}