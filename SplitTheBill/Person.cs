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
    public class Person
    {
       public ObservableCollection<Transaction> Transactions { get; set; }
        public double Total { get; set; }
        public string Name { get; set; }
        public Person()
        {
            Total = 0;
            Transactions = new ObservableCollection<Transaction>();
        }
        public double getSum()
        {
            double total = 0;
            foreach (Transaction t in Transactions)
            {
                total += t.Amount;
            }
            return total;
        }

    }
}
