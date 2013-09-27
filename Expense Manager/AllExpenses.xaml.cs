using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.Diagnostics;

namespace Expense_Manager
{
    public partial class AllExpenses : PhoneApplicationPage
    {
        public class Expense
        {
            public string Name
            {
                get;
                set;
            }
            public int Value
            {
                get;
                set;
            }
        }
        public AllExpenses()
        {
            InitializeComponent();
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            List<Expense> list = new List<Expense>();
            foreach (string key in settings.Keys)
            {
                if(!key.Equals("total_expense"))
                list.Add(new Expense(){Name = key , Value = int.Parse(settings[key].ToString())});
            }
            this.barSeries.Series[0].ItemsSource = list;
        }


    }
}