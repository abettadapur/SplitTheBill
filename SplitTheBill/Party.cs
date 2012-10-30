using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace SplitTheBill
{
    public class Party
    {
        public double Subtotal { get; set; }
        public double Tax { get; set; }
        public double TipRate { get; set; }
        public double TaxRate { get; set; }
        public double Tip { get; set; }
        public double Total { get; set; }
        public ObservableCollection<Person> People { get; set; }

        public double computeSubTotal()
        {
            double total = 0;
            foreach (Person p in People)
            {
                total += p.Total;
            }
            Subtotal = total;
            return total;
        }
        public double computeTax(double rate)
        {
            rate /= 100.0;
            TaxRate = rate;
            double tax = Subtotal * rate;
            Tax = tax;
            return tax;
        }
        public double computeTip(double rate)
        {
            
            rate /= 100.0;
            TipRate = rate;
            double tip = Subtotal * rate;
            Tip = tip;
            return tip;
        }
        public double computeTotal()
        {
            double total = Subtotal + Tax + Tip;
            Total = total;
            return total;
        }

    }
}
