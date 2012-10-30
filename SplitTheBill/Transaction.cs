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

namespace SplitTheBill
{
    public class Transaction
    {
        public string Count { get; set; }
        public double Amount { get; set; }
        
        public Transaction(string count, double amount)
        {
            Count = count;
            Amount = amount;
        }
    }
}
