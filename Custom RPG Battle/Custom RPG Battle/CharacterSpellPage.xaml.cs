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
    public sealed partial class CharacterSpellPage : Custom_RPG_Battle.Common.LayoutAwarePage
    {
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        Object S1Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S1Nm"];
        Object S1MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S1MinDmg"];
        Object S1MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S1MaxDmg"];
        Object S1HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S1HP"];
        Object S1MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S1MP"];

        Object S2Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S2Nm"];
        Object S2MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S2MinDmg"];
        Object S2MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S2MaxDmg"];
        Object S2HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S2HP"];
        Object S2MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S2MP"];

        Object S3Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S3Nm"];
        Object S3MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S3MinDmg"];
        Object S3MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S3MaxDmg"];
        Object S3HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S3HP"];
        Object S3MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S3MP"];

        Object S4Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S4Nm"];
        Object S4MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S4MinDmg"];
        Object S4MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S4MaxDmg"];
        Object S4HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S4HP"];
        Object S4MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["S4MP"];

        public CharacterSpellPage()
        {
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
            if (S1Nm != null)
            {
                Attack1Name.Text = S1Nm.ToString();
            }
            if (S1MinDmg != null)
            {
                Attack1MinDmg.Text = S1MinDmg.ToString();
            }
            if (S1MaxDmg != null)
            {
                Attack1MaxDmg.Text = S1MaxDmg.ToString();
            }
            if (S1HP != null)
            {
                Attack1HPCost.Text = S1HP.ToString();
            }
            if (S1MP != null)
            {
                Attack1MPCost.Text = S1MP.ToString();
            }

            if (S2Nm != null)
            {
                Attack2Name.Text = S2Nm.ToString();
            }
            if (S2MinDmg != null)
            {
                Attack2MinDmg.Text = S2MinDmg.ToString();
            }
            if (S2MaxDmg != null)
            {
                Attack2MaxDmg.Text = S2MaxDmg.ToString();
            }
            if (S2HP != null)
            {
                Attack2HPCost.Text = S2HP.ToString();
            }
            if (S2MP != null)
            {
                Attack2MPCost.Text = S2MP.ToString();
            }

            if (S3Nm != null)
            {
                Attack3Name.Text = S3Nm.ToString();
            }
            if (S3MinDmg != null)
            {
                Attack3MinDmg.Text = S3MinDmg.ToString();
            }
            if (S3MaxDmg != null)
            {
                Attack3MaxDmg.Text = S3MaxDmg.ToString();
            }
            if (S3HP != null)
            {
                Attack3HPCost.Text = S3HP.ToString();
            }
            if (S3MP != null)
            {
                Attack3MPCost.Text = S3MP.ToString();
            }

            if (S4Nm != null)
            {
                Attack4Name.Text = S4Nm.ToString();
            }
            if (S4MinDmg != null)
            {
                Attack4MinDmg.Text = S4MinDmg.ToString();
            }
            if (S4MaxDmg != null)
            {
                Attack4MaxDmg.Text = S4MaxDmg.ToString();
            }
            if (S4HP != null)
            {
                Attack4HPCost.Text = S4HP.ToString();
            }
            if (S4MP != null)
            {
                Attack4MPCost.Text = S4MP.ToString();
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
            localSettings.Values["S1Nm"] = Attack1Name.Text;
            localSettings.Values["S1MinDmg"] = Attack1MinDmg.Text;
            localSettings.Values["S1MaxDmg"] = Attack1MaxDmg.Text;
            localSettings.Values["S1HP"] = Attack1HPCost.Text;
            localSettings.Values["S1MP"] = Attack1MPCost.Text;

            localSettings.Values["S2Nm"] = Attack2Name.Text;
            localSettings.Values["S2MinDmg"] = Attack2MinDmg.Text;
            localSettings.Values["S2MaxDmg"] = Attack2MaxDmg.Text;
            localSettings.Values["S2HP"] = Attack2HPCost.Text;
            localSettings.Values["S2MP"] = Attack2MPCost.Text;

            localSettings.Values["S3Nm"] = Attack3Name.Text;
            localSettings.Values["S3MinDmg"] = Attack3MinDmg.Text;
            localSettings.Values["S3MaxDmg"] = Attack3MaxDmg.Text;
            localSettings.Values["S3HP"] = Attack3HPCost.Text;
            localSettings.Values["S3MP"] = Attack3MPCost.Text;

            localSettings.Values["S4Nm"] = Attack4Name.Text;
            localSettings.Values["S4MinDmg"] = Attack4MinDmg.Text;
            localSettings.Values["S4MaxDmg"] = Attack4MaxDmg.Text;
            localSettings.Values["S4HP"] = Attack4HPCost.Text;
            localSettings.Values["S4MP"] = Attack4MPCost.Text;
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            localSettings.Values["S1Nm"] = Attack1Name.Text;
            localSettings.Values["S1MinDmg"] = Attack1MinDmg.Text;
            localSettings.Values["S1MaxDmg"] = Attack1MaxDmg.Text;
            localSettings.Values["S1HP"] = Attack1HPCost.Text;
            localSettings.Values["S1MP"] = Attack1MPCost.Text;

            localSettings.Values["S2Nm"] = Attack2Name.Text;
            localSettings.Values["S2MinDmg"] = Attack2MinDmg.Text;
            localSettings.Values["S2MaxDmg"] = Attack2MaxDmg.Text;
            localSettings.Values["S2HP"] = Attack2HPCost.Text;
            localSettings.Values["S2MP"] = Attack2MPCost.Text;

            localSettings.Values["S3Nm"] = Attack3Name.Text;
            localSettings.Values["S3MinDmg"] = Attack3MinDmg.Text;
            localSettings.Values["S3MaxDmg"] = Attack3MaxDmg.Text;
            localSettings.Values["S3HP"] = Attack3HPCost.Text;
            localSettings.Values["S3MP"] = Attack3MPCost.Text;

            localSettings.Values["S4Nm"] = Attack4Name.Text;
            localSettings.Values["S4MinDmg"] = Attack4MinDmg.Text;
            localSettings.Values["S4MaxDmg"] = Attack4MaxDmg.Text;
            localSettings.Values["S4HP"] = Attack4HPCost.Text;
            localSettings.Values["S4MP"] = Attack4MPCost.Text;

            bool error = false;
            var messageDialog = new MessageDialog("");
            string[] values = { Attack1MinDmg.Text, Attack1MaxDmg.Text, Attack1HPCost.Text, Attack1MPCost.Text,
                                Attack2MinDmg.Text, Attack2MaxDmg.Text, Attack2HPCost.Text, Attack2MPCost.Text,
                                Attack3MinDmg.Text, Attack3MaxDmg.Text, Attack3HPCost.Text, Attack3MPCost.Text,
                                Attack4MinDmg.Text, Attack4MaxDmg.Text, Attack4HPCost.Text, Attack4MPCost.Text,
                                Int32.MaxValue.ToString() };
            int result;

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
                Frame.Navigate(typeof(CharItemPage));
            }
            else
            {
                // Show the message dialog and wait
                await messageDialog.ShowAsync();
            }
        }
    }
}
