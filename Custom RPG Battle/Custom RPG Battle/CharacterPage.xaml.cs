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
    public sealed partial class CharacterPage : Custom_RPG_Battle.Common.LayoutAwarePage
    {
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        Object CharNm;
        Object CharHP;
        Object CharMP;
        Object CharMinDmg;
        Object CharMaxDmg;

        public CharacterPage()
        {
            CharNm = localSettings.Values["CharNm"];
            CharHP = localSettings.Values["CharHP"];
            CharMP = localSettings.Values["CharMP"];
            CharMinDmg = localSettings.Values["CharMinDmg"];
            CharMaxDmg = localSettings.Values["CharMaxDmg"];

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
            if (CharNm != null)
            {
                MonsterName.Text = CharNm.ToString();
            }
            if (CharHP != null)
            {
                MonsterHP.Text = CharHP.ToString();
            }
            if (CharMP != null)
            {
                MonsterMP.Text = CharMP.ToString();
            }
            if (CharMinDmg != null)
            {
                Attack2MinDmg.Text = CharMinDmg.ToString();
            }
            if (CharMaxDmg != null)
            {
                Attack2MaxDmg.Text = CharMaxDmg.ToString();
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
            localSettings.Values["CharNm"] = MonsterName.Text;
            localSettings.Values["CharHP"] = MonsterHP.Text;
            localSettings.Values["CharMP"] = MonsterMP.Text;
            localSettings.Values["CharMinDmg"] = Attack2MinDmg.Text;
            localSettings.Values["CharMaxDmg"] = Attack2MaxDmg.Text;
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            localSettings.Values["CharNm"] = MonsterName.Text;
            localSettings.Values["CharHP"] = MonsterHP.Text;
            localSettings.Values["CharMP"] = MonsterMP.Text;
            localSettings.Values["CharMinDmg"] = Attack2MinDmg.Text;
            localSettings.Values["CharMaxDmg"] = Attack2MaxDmg.Text;

            bool error = false;
            var messageDialog = new MessageDialog("");
            string[] values = { MonsterHP.Text, MonsterMP.Text, Attack2MinDmg.Text, Attack2MaxDmg.Text, Int32.MaxValue.ToString() };
            int result;

            if (Convert.ToInt32(Attack2MinDmg.Text) >= Convert.ToInt32(Attack2MaxDmg.Text))
            {
                messageDialog = new MessageDialog("The damage value in the left input box should be greater than the damage value in the right.");
                messageDialog.Title = "Invalid Input";
                error = true;
            }

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
                Frame.Navigate(typeof(CharacterSpellPage));
            }
            else
            {
                // Show the message dialog and wait
                await messageDialog.ShowAsync();
            }
        }
    }
}
