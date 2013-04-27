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
    public sealed partial class CharItemPage : Custom_RPG_Battle.Common.LayoutAwarePage
    {
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        Object I1Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I1Nm"];
        Object I1MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I1MinDmg"];
        Object A1MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A1MaxDmg"];
        Object I1HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I1HP"];
        Object I1MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I1MP"];
        Object I1Qnt = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I1Qnt"];

        Object I2Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I2Nm"];
        Object I2MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I2MinDmg"];
        Object I2MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I2MaxDmg"];
        Object I2HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I2HP"];
        Object I2MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I2MP"];
        Object I2Qnt = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I2Qnt"];

        Object I3Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I3Nm"];
        Object I3MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I3MinDmg"];
        Object I3MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I3MaxDmg"];
        Object I3HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I3HP"];
        Object I3MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I3MP"];
        Object I3Qnt = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I3Qnt"];

        Object I4Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I4Nm"];
        Object I4MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I4MinDmg"];
        Object I4MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I4MaxDmg"];
        Object I4HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I4HP"];
        Object I4MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I4MP"];
        Object I4Qnt = Windows.Storage.ApplicationData.Current.LocalSettings.Values["I4Qnt"];

        public CharItemPage()
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
            if (I1Nm != null)
            {
                Attack1Name.Text = I1Nm.ToString();
            }
            if (I1MinDmg != null)
            {
                Attack1MinDmg.Text = I1MinDmg.ToString();
            }
            if (A1MaxDmg != null)
            {
                Attack1MaxDmg.Text = A1MaxDmg.ToString();
            }
            if (I1HP != null)
            {
                Attack1HPCost.Text = I1HP.ToString();
            }
            if (I1MP != null)
            {
                Attack1MPCost.Text = I1MP.ToString();
            }
            if (I1Qnt != null)
            {
                I1Quantity.Text = I1Qnt.ToString();
            }

            if (I2Nm != null)
            {
                Attack2Name.Text = I2Nm.ToString();
            }
            if (I2MinDmg != null)
            {
                Attack2MinDmg.Text = I2MinDmg.ToString();
            }
            if (I2MaxDmg != null)
            {
                Attack2MaxDmg.Text = I2MaxDmg.ToString();
            }
            if (I2HP != null)
            {
                Attack2HPCost.Text = I2HP.ToString();
            }
            if (I2MP != null)
            {
                Attack2MPCost.Text = I2MP.ToString();
            }
            if (I2Qnt != null)
            {
                I2Quantity.Text = I2Qnt.ToString();
            }

            if (I3Nm != null)
            {
                Attack3Name.Text = I3Nm.ToString();
            }
            if (I3MinDmg != null)
            {
                Attack3MinDmg.Text = I3MinDmg.ToString();
            }
            if (I3MaxDmg != null)
            {
                Attack3MaxDmg.Text = I3MaxDmg.ToString();
            }
            if (I3HP != null)
            {
                Attack3HPCost.Text = I3HP.ToString();
            }
            if (I3MP != null)
            {
                Attack3MPCost.Text = I3MP.ToString();
            }
            if (I3Qnt != null)
            {
                I3Quantity.Text = I3Qnt.ToString();
            }

            if (I4Nm != null)
            {
                Attack4Name.Text = I4Nm.ToString();
            }
            if (I4MinDmg != null)
            {
                Attack4MinDmg.Text = I4MinDmg.ToString();
            }
            if (I4MaxDmg != null)
            {
                Attack4MaxDmg.Text = I4MaxDmg.ToString();
            }
            if (I4HP != null)
            {
                Attack4HPCost.Text = I4HP.ToString();
            }
            if (I4MP != null)
            {
                Attack4MPCost.Text = I4MP.ToString();
            }
            if (I4Qnt != null)
            {
                I4Quantity.Text = I4Qnt.ToString();
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
            localSettings.Values["I1Nm"] = Attack1Name.Text;
            localSettings.Values["I1MinDmg"] = Attack1MinDmg.Text;
            localSettings.Values["A1MaxDmg"] = Attack1MaxDmg.Text;
            localSettings.Values["I1HP"] = Attack1HPCost.Text;
            localSettings.Values["I1MP"] = Attack1MPCost.Text;
            localSettings.Values["I1Qnt"] = I1Quantity.Text;

            localSettings.Values["I2Nm"] = Attack2Name.Text;
            localSettings.Values["I2MinDmg"] = Attack2MinDmg.Text;
            localSettings.Values["I2MaxDmg"] = Attack2MaxDmg.Text;
            localSettings.Values["I2HP"] = Attack2HPCost.Text;
            localSettings.Values["I2MP"] = Attack2MPCost.Text;
            localSettings.Values["I2Qnt"] = I2Quantity.Text;

            localSettings.Values["I3Nm"] = Attack3Name.Text;
            localSettings.Values["I3MinDmg"] = Attack3MinDmg.Text;
            localSettings.Values["I3MaxDmg"] = Attack3MaxDmg.Text;
            localSettings.Values["I3HP"] = Attack3HPCost.Text;
            localSettings.Values["I3MP"] = Attack3MPCost.Text;
            localSettings.Values["I3Qnt"] = I3Quantity.Text;

            localSettings.Values["I4Nm"] = Attack4Name.Text;
            localSettings.Values["I4MinDmg"] = Attack4MinDmg.Text;
            localSettings.Values["I4MaxDmg"] = Attack4MaxDmg.Text;
            localSettings.Values["I4HP"] = Attack4HPCost.Text;
            localSettings.Values["I4MP"] = Attack4MPCost.Text;
            localSettings.Values["I4Qnt"] = I4Quantity.Text;
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            localSettings.Values["I1Nm"] = Attack1Name.Text;
            localSettings.Values["I1MinDmg"] = Attack1MinDmg.Text;
            localSettings.Values["A1MaxDmg"] = Attack1MaxDmg.Text;
            localSettings.Values["I1HP"] = Attack1HPCost.Text;
            localSettings.Values["I1MP"] = Attack1MPCost.Text;
            localSettings.Values["I1Qnt"] = I1Quantity.Text;

            localSettings.Values["I2Nm"] = Attack2Name.Text;
            localSettings.Values["I2MinDmg"] = Attack2MinDmg.Text;
            localSettings.Values["I2MaxDmg"] = Attack2MaxDmg.Text;
            localSettings.Values["I2HP"] = Attack2HPCost.Text;
            localSettings.Values["I2MP"] = Attack2MPCost.Text;
            localSettings.Values["I2Qnt"] = I2Quantity.Text;

            localSettings.Values["I3Nm"] = Attack3Name.Text;
            localSettings.Values["I3MinDmg"] = Attack3MinDmg.Text;
            localSettings.Values["I3MaxDmg"] = Attack3MaxDmg.Text;
            localSettings.Values["I3HP"] = Attack3HPCost.Text;
            localSettings.Values["I3MP"] = Attack3MPCost.Text;
            localSettings.Values["I3Qnt"] = I3Quantity.Text;

            localSettings.Values["I4Nm"] = Attack4Name.Text;
            localSettings.Values["I4MinDmg"] = Attack4MinDmg.Text;
            localSettings.Values["I4MaxDmg"] = Attack4MaxDmg.Text;
            localSettings.Values["I4HP"] = Attack4HPCost.Text;
            localSettings.Values["I4MP"] = Attack4MPCost.Text;
            localSettings.Values["I4Qnt"] = I4Quantity.Text;

            bool error = false;
            var messageDialog = new MessageDialog("");
            string[] values = { Attack1MinDmg.Text, Attack1MaxDmg.Text, Attack1HPCost.Text, I1Quantity.Text,
                                Attack2MinDmg.Text, Attack2MaxDmg.Text, Attack2HPCost.Text, I2Quantity.Text,
                                Attack3MinDmg.Text, Attack3MaxDmg.Text, Attack3HPCost.Text, I3Quantity.Text,
                                Attack4MinDmg.Text, Attack4MaxDmg.Text, Attack4HPCost.Text, I4Quantity.Text,
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
                Frame.Navigate(typeof(FightPage));
            }
            else
            {
                // Show the message dialog and wait
                await messageDialog.ShowAsync();
            }
        }
    }
}
