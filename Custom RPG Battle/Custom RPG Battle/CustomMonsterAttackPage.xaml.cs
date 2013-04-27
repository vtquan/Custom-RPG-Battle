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
    public sealed partial class CustomMonsterAttackPage : Custom_RPG_Battle.Common.LayoutAwarePage
    {
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        Object A1Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A1Nm"];
        Object A1MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A1MinDmg"];
        Object A1MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A1MaxDmg"];
        Object A1HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A1HP"];
        Object A1MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A1MP"];

        Object A2Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A2Nm"];
        Object A2MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A2MinDmg"];
        Object A2MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A2MaxDmg"];
        Object A2HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A2HP"];
        Object A2MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A2MP"];

        Object A3Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A3Nm"];
        Object A3MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A3MinDmg"];
        Object A3MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A3MaxDmg"];
        Object A3HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A3HP"];
        Object A3MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A3MP"];

        Object A4Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A4Nm"];
        Object A4MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A4MinDmg"];
        Object A4MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A4MaxDmg"];
        Object A4HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A4HP"];
        Object A4MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A4MP"];

        public CustomMonsterAttackPage()
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
            if (A1Nm != null)
            {
                Attack4Name.Text = A1Nm.ToString();
            }
            if (A1MinDmg != null)
            {
                Attack4MinDmg.Text = A1MinDmg.ToString();
            }
            if (A1MaxDmg != null)
            {
                Attack4MaxDmg.Text = A1MaxDmg.ToString();
            }
            if (A1HP != null)
            {
                Attack4HPCost.Text = A1HP.ToString();
            }
            if (A1MP != null)
            {
                Attack4MPCost.Text = A1MP.ToString();
            }

            if (A2Nm != null)
            {
                Attack2Name.Text = A2Nm.ToString();
            }
            if (A2MinDmg != null)
            {
                Attack2MinDmg.Text = A2MinDmg.ToString();
            }
            if (A2MaxDmg != null)
            {
                Attack2MaxDmg.Text = A2MaxDmg.ToString();
            }
            if (A2HP != null)
            {
                Attack2HPCost.Text = A2HP.ToString();
            }
            if (A2MP != null)
            {
                Attack2MPCost.Text = A2MP.ToString();
            }

            if (A3Nm != null)
            {
                Attack3Name.Text = A3Nm.ToString();
            }
            if (A3MinDmg != null)
            {
                Attack3MinDmg.Text = A3MinDmg.ToString();
            }
            if (A3MaxDmg != null)
            {
                Attack3MaxDmg.Text = A3MaxDmg.ToString();
            }
            if (A3HP != null)
            {
                Attack3HPCost.Text = A3HP.ToString();
            }
            if (A3MP != null)
            {
                Attack3MPCost.Text = A3MP.ToString();
            }

            if (A4Nm != null)
            {
                Attack4Name.Text = A4Nm.ToString();
            }
            if (A4MinDmg != null)
            {
                Attack4MinDmg.Text = A4MinDmg.ToString();
            }
            if (A4MaxDmg != null)
            {
                Attack4MaxDmg.Text = A4MaxDmg.ToString();
            }
            if (A4HP != null)
            {
                Attack4HPCost.Text = A4HP.ToString();
            }
            if (A4MP != null)
            {
                Attack4MPCost.Text = A4MP.ToString();
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
            localSettings.Values["A1Nm"] = Attack1Name.Text;
            localSettings.Values["A1MinDmg"] = Attack1MinDmg.Text;
            localSettings.Values["A1MaxDmg"] = Attack1MaxDmg.Text;
            localSettings.Values["A1HP"] = Attack1HPCost.Text;
            localSettings.Values["A1MP"] = Attack1MPCost.Text;

            localSettings.Values["A2Nm"] = Attack2Name.Text;
            localSettings.Values["A2MinDmg"] = Attack2MinDmg.Text;
            localSettings.Values["A2MaxDmg"] = Attack2MaxDmg.Text;
            localSettings.Values["A2HP"] = Attack2HPCost.Text;
            localSettings.Values["A2MP"] = Attack2MPCost.Text;

            localSettings.Values["A3Nm"] = Attack3Name.Text;
            localSettings.Values["A3MinDmg"] = Attack3MinDmg.Text;
            localSettings.Values["A3MaxDmg"] = Attack3MaxDmg.Text;
            localSettings.Values["A3HP"] = Attack3HPCost.Text;
            localSettings.Values["A3MP"] = Attack3MPCost.Text;

            localSettings.Values["A4Nm"] = Attack4Name.Text;
            localSettings.Values["A4MinDmg"] = Attack4MinDmg.Text;
            localSettings.Values["A4MaxDmg"] = Attack4MaxDmg.Text;
            localSettings.Values["A4HP"] = Attack4HPCost.Text;
            localSettings.Values["A4MP"] = Attack4MPCost.Text;
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {

            localSettings.Values["A1Nm"] = Attack1Name.Text;
            localSettings.Values["A1MinDmg"] = Attack1MinDmg.Text;
            localSettings.Values["A1MaxDmg"] = Attack1MaxDmg.Text;
            localSettings.Values["A1HP"] = Attack1HPCost.Text;
            localSettings.Values["A1MP"] = Attack1MPCost.Text;

            localSettings.Values["A2Nm"] = Attack2Name.Text;
            localSettings.Values["A2MinDmg"] = Attack2MinDmg.Text;
            localSettings.Values["A2MaxDmg"] = Attack2MaxDmg.Text;
            localSettings.Values["A2HP"] = Attack2HPCost.Text;
            localSettings.Values["A2MP"] = Attack2MPCost.Text;

            localSettings.Values["A3Nm"] = Attack3Name.Text;
            localSettings.Values["A3MinDmg"] = Attack3MinDmg.Text;
            localSettings.Values["A3MaxDmg"] = Attack3MaxDmg.Text;
            localSettings.Values["A3HP"] = Attack3HPCost.Text;
            localSettings.Values["A3MP"] = Attack3MPCost.Text;

            localSettings.Values["A4Nm"] = Attack4Name.Text;
            localSettings.Values["A4MinDmg"] = Attack4MinDmg.Text;
            localSettings.Values["A4MaxDmg"] = Attack4MaxDmg.Text;
            localSettings.Values["A4HP"] = Attack4HPCost.Text;
            localSettings.Values["A4MP"] = Attack4MPCost.Text;

            bool error = false;
            var messageDialog = new MessageDialog("");
            string[] values = { Attack1MinDmg.Text, Attack1MaxDmg.Text,
                                Attack2MinDmg.Text, Attack2MaxDmg.Text,
                                Attack3MinDmg.Text, Attack3MaxDmg.Text,
                                Attack4MinDmg.Text, Attack4MaxDmg.Text,
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
                Frame.Navigate(typeof(CharacterPage));
            }
            else
            {
                // Show the message dialog and wait
                await messageDialog.ShowAsync();
            }
        }
    }
}
