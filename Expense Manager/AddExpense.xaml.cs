using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.IO.IsolatedStorage;
using System.Diagnostics;
using Windows.Phone.Speech.Synthesis;

namespace Expense_Manager
{
    public partial class AddExpense : PhoneApplicationPage
    {

        IsolatedStorageSettings settings;
        public AddExpense()
        {
            InitializeComponent();
            settings = IsolatedStorageSettings.ApplicationSettings;

        }
      
      

        private async void add_expense(object sender, RoutedEventArgs e)
        {
            if (settings.Contains(tag_box.Text))
            {
                int value = (int)settings[tag_box.Text];
                value += int.Parse(expense_box.Text);
                settings[tag_box.Text] = value;
                settings["total_expense"] = int.Parse(settings["total_expense"].ToString()) + value;
            }
            else
            {
                settings.Add(tag_box.Text, int.Parse(expense_box.Text));
                settings["total_expense"] = int.Parse(settings["total_expense"].ToString()) + int.Parse(expense_box.Text);
            }
            SpeechSynthesizer synth = new SpeechSynthesizer();

            await synth.SpeakTextAsync("Expense added!");
        }
    }
}