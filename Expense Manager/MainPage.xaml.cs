using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Expense_Manager.Resources;
using System.IO.IsolatedStorage;
using Windows.Phone.System.UserProfile;

namespace Expense_Manager
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            MessageBox.Show("Hi");
            int expense;
            if(IsolatedStorageSettings.ApplicationSettings.TryGetValue<int>("total_expense",out expense))
            {
                Dispatcher.BeginInvoke(() => { expense_block.Text = expense.ToString(); });
            }
            if(!IsolatedStorageSettings.ApplicationSettings.Contains("total_expense"))
            IsolatedStorageSettings.ApplicationSettings.Add("total_expense",0);
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddExpense.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AllExpenses.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
            {
                int expense;
                if (IsolatedStorageSettings.ApplicationSettings.TryGetValue<int>("total_expense", out expense))
                {
                    Dispatcher.BeginInvoke(() => { expense_block.Text = expense.ToString(); });
                }
                change();
                
            }

        private void change()
        {
            int expense = 0;
            if (IsolatedStorageSettings.ApplicationSettings.Contains("total_expense"))
            {
                expense = int.Parse(IsolatedStorageSettings.ApplicationSettings["total_expense"].ToString());
            }
                ShellTile.ActiveTiles.First().Update(
                new FlipTileData()
                {
                    Count = expense,
                    WideBackContent = "Total expense : " + expense,
                    SmallBackgroundImage = new Uri(@"expense159.png", UriKind.Relative),
                    BackgroundImage = new Uri(@"expense336.png", UriKind.Relative),
                    BackBackgroundImage = new Uri(@"palm691.png", UriKind.Relative)
                });
       }
    }
}