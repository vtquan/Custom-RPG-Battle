using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Custom_RPG_Battle
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : Custom_RPG_Battle.Common.LayoutAwarePage
    {
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        Object MonNm;
        Object MonSub;
        Object MonHP;
        Object MonMP;
        Object MonPortrait;


        public MainPage()
        {
            MonNm = localSettings.Values["MonNm"];
            MonSub = localSettings.Values["MonSub"];
            MonHP = localSettings.Values["MonHP"];
            MonMP = localSettings.Values["MonMP"];
            MonPortrait = localSettings.Values["MonPortrait"];

            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            if (MonNm != null)
            {
                MonsterName.Text = MonNm.ToString();
            }
            if (MonSub != null)
            {
                MonsterSub.Text = MonSub.ToString();
            }
            if (MonHP != null)
            {
                MonsterHP.Text = MonHP.ToString();
            }
            if (MonMP != null)
            {
                MonsterMP.Text = MonMP.ToString();
            }

            if (MonPortrait != null)
            {
                if ((int)MonPortrait == 1)
                    radio1.IsChecked = true;
                else if ((int)MonPortrait == 2)
                    radio2.IsChecked = true;
                else if ((int)MonPortrait == 3)
                    radio3.IsChecked = true;
                else if ((int)MonPortrait == 4)
                    radio4.IsChecked = true;
                else
                    radio5.IsChecked = true;
            }
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            localSettings.Values["MonNm"] = MonsterName.Text;
            localSettings.Values["MonSub"] = MonsterSub.Text;
            localSettings.Values["MonHP"] = MonsterHP.Text;
            localSettings.Values["MonMP"] = MonsterMP.Text;


            if (radio1.IsChecked ?? true)
                localSettings.Values["MonPortrait"] = 1;
            else if (radio2.IsChecked ?? true)
                localSettings.Values["MonPortrait"] = 2;
            else if (radio3.IsChecked ?? true)
                localSettings.Values["MonPortrait"] = 3;
            else if (radio4.IsChecked ?? true)
                localSettings.Values["MonPortrait"] = 4;
            else
                localSettings.Values["MonPortrait"] = 5;            
        }

        private void AxalfB_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.Fights.AxalfFightPage));
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            bool error = false;
            var messageDialog = new MessageDialog("");
            string[] values = {MonsterHP.Text, MonsterMP.Text, Int32.MaxValue.ToString() };
            int result;

            localSettings.Values["MonNm"] = MonsterName.Text;
            localSettings.Values["MonSub"] = MonsterSub.Text;
            localSettings.Values["MonHP"] = MonsterHP.Text;
            localSettings.Values["MonMP"] = MonsterMP.Text;


            if (radio1.IsChecked ?? true)
                localSettings.Values["MonPortrait"] = 1;
            else if (radio2.IsChecked ?? true)
                localSettings.Values["MonPortrait"] = 2;
            else if (radio3.IsChecked ?? true)
                localSettings.Values["MonPortrait"] = 3;
            else if (radio4.IsChecked ?? true)
                localSettings.Values["MonPortrait"] = 4;
            else
                localSettings.Values["MonPortrait"] = 5;          

            //if (MonPortrait != null)
            //{
            //    error = true;
            //}

            foreach (string value in values)
            {
                try
                {
                    result = Convert.ToInt32(value);
                    
                }
                catch (OverflowException)
                {
                    messageDialog = new MessageDialog("At least one of the value is outside the range of the Int32 type.", value);
                    messageDialog.Title = "Invalid Input";
                    error = true;
                }
                catch (FormatException)
                {
                    messageDialog = new MessageDialog("At least one of the value is not in a recognizable format.");
                    messageDialog.Title = "Invalid Input";
                    error = true;
                }
            }
            if (!error)
            {
                Frame.Navigate(typeof(CustomMonsterAttackPage));
            }
            else
            {
                // Show the message dialog and wait
                await messageDialog.ShowAsync();
            }
        }
    }
}
