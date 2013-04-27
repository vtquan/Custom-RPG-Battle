using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

using Attack = Custom_RPG_Battle.Common.RPG.Attack;
using Monster = Custom_RPG_Battle.Common.RPG.Monster;
using Player = Custom_RPG_Battle.Common.RPG.Player;
using Spell = Custom_RPG_Battle.Common.RPG.Spell;
using Item = Custom_RPG_Battle.Common.RPG.Item;


// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Custom_RPG_Battle
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class FightPage : Custom_RPG_Battle.Common.LayoutAwarePage
    {
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        Monster Enemy;
        Player You;

        Button[] itemButton;
        Button[] spellButton;

        Random random = new Random();
        bool fled = false;  //check if the flee button has been pressed

        //store HP and MP bar starting width
        double monsterHPBarWidth;
        double playerHPBarWidth;
        double monsterMPBarWidth;
        double playerMPBarWidth;

        public FightPage()
        {
            this.InitializeComponent();

            setUpPage();    //initialyze the page with proper information
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
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void setUpPage()
        {
            //Idle Animation Begin
            IdleAnimation.Begin();

            //Creating Player Attack
            Attack PA = new Attack(0, Convert.ToDouble(localSettings.Values["CharMinDmg"].ToString()), Convert.ToDouble(localSettings.Values["CharMaxDmg"].ToString()));
            //Create Monster and Player value
            Enemy = new Monster(localSettings.Values["MonNm"].ToString(), localSettings.Values["MonSub"].ToString(), Convert.ToInt32(localSettings.Values["MonHP"].ToString()), Convert.ToInt32(localSettings.Values["MonMP"].ToString()));
            You = new Player(localSettings.Values["CharNm"].ToString(), Convert.ToInt32(localSettings.Values["CharHP"].ToString()), Convert.ToInt32(localSettings.Values["CharMP"].ToString()), PA);

            //Creating and adding attacks to monster
            Attack A1 = new Attack(localSettings.Values["A1Nm"].ToString(), 0, Convert.ToDouble(localSettings.Values["A1MinDmg"].ToString()), Convert.ToDouble(localSettings.Values["A1MaxDmg"].ToString()));
            Attack A2 = new Attack(localSettings.Values["A2Nm"].ToString(), 0, Convert.ToDouble(localSettings.Values["A2MinDmg"].ToString()), Convert.ToDouble(localSettings.Values["A2MaxDmg"].ToString()));
            Attack A3 = new Attack(localSettings.Values["A3Nm"].ToString(), 0, Convert.ToDouble(localSettings.Values["A3MinDmg"].ToString()), Convert.ToDouble(localSettings.Values["A3MaxDmg"].ToString()));
            Attack A4 = new Attack(localSettings.Values["A4Nm"].ToString(), 0, Convert.ToDouble(localSettings.Values["A4MinDmg"].ToString()), Convert.ToDouble(localSettings.Values["A4MaxDmg"].ToString()));

            Enemy.addAttack(A1);
            Enemy.addAttack(A2);
            Enemy.addAttack(A3);
            Enemy.addAttack(A4);

            //Creating and adding items  to player
            Item I1 = new Item(localSettings.Values["I1Nm"].ToString(), Convert.ToInt32(localSettings.Values["I1HP"].ToString()));
            Item I2 = new Item(localSettings.Values["I2Nm"].ToString(), Convert.ToInt32(localSettings.Values["I2HP"].ToString()));
            Item I3 = new Item(localSettings.Values["I3Nm"].ToString(), Convert.ToInt32(localSettings.Values["I3HP"].ToString()));
            Item I4 = new Item(localSettings.Values["I4Nm"].ToString(), Convert.ToInt32(localSettings.Values["I4HP"].ToString()));

            int i = 0;
            while (i < Convert.ToInt32(localSettings.Values["I1Qnt"].ToString()))
            {
                You.addItem(I1);
                i++;
            }

            i = 0;
            while (i < Convert.ToInt32(localSettings.Values["I2Qnt"].ToString()))
            {
                You.addItem(I2);
                i++;
            }

            i = 0;
            while (i < Convert.ToInt32(localSettings.Values["I3Qnt"].ToString()))
            {
                You.addItem(I3);
                i++;
            }

            i = 0;
            while (i < Convert.ToInt32(localSettings.Values["I4Qnt"].ToString()))
            {
                You.addItem(I4);
                i++;
            }

            //Creating and adding spells  to player
            Spell S1 = new Spell(localSettings.Values["S1Nm"].ToString(), 0, Convert.ToDouble(localSettings.Values["S1MinDmg"].ToString()), Convert.ToDouble(localSettings.Values["S1MaxDmg"].ToString()), Convert.ToInt32(localSettings.Values["S1MP"].ToString()));
            Spell S2 = new Spell(localSettings.Values["S2Nm"].ToString(), 0, Convert.ToDouble(localSettings.Values["S2MinDmg"].ToString()), Convert.ToDouble(localSettings.Values["S2MaxDmg"].ToString()), Convert.ToInt32(localSettings.Values["S2MP"].ToString()));
            Spell S3 = new Spell(localSettings.Values["S3Nm"].ToString(), 0, Convert.ToDouble(localSettings.Values["S3MinDmg"].ToString()), Convert.ToDouble(localSettings.Values["S3MaxDmg"].ToString()), Convert.ToInt32(localSettings.Values["S3MP"].ToString()));
            Spell S4 = new Spell(localSettings.Values["S4Nm"].ToString(), 0, Convert.ToDouble(localSettings.Values["S4MinDmg"].ToString()), Convert.ToDouble(localSettings.Values["S4MaxDmg"].ToString()), Convert.ToInt32(localSettings.Values["S4MP"].ToString()));

            You.addSpell(S1);
            You.addSpell(S2);
            You.addSpell(S3);
            You.addSpell(S4);

            //Display Monster and Player value
            pageTitle.Text = Enemy.getSubtitle() + ": " + Enemy.getName();
            monsterName.Text = Enemy.getName();
            monsterHPText.Text = Enemy.getHPStart().ToString();
            monsterMPText.Text = Enemy.getMPStart().ToString();
            yourName.Text = You.getName();
            yourHPText.Text = You.getHPStart().ToString();
            yourMPText.Text = You.getMPStart().ToString();
        }

        private async void spellClick(object sender, RoutedEventArgs e)
        {
            //Display Action Log list
            ActionLogLabel.Visibility = Visibility.Visible;
            ActionLogScroll.Visibility = Visibility.Visible;
            SpellListLabel.Visibility = Visibility.Collapsed;
            SpellListScroll.Visibility = Visibility.Collapsed;

            //Find item and store item values for easy display
            int spellIndex = You.findSpell(((Button)sender).Content.ToString().Substring(0, ((Button)sender).Content.ToString().Length - 7));    //get "Spell" instead of "Spell - 10mp"
            string spellName = You.getSpellList()[spellIndex].getName();
            int spellDamage;

            //Use selected item
            KeyValuePair<bool, int[]> result = You.useSpell(spellName, ref Enemy);
            spellDamage = result.Value[0];
            if (!result.Key)
            {
                ActionLogList.Children.Add(new TextBlock() { Text = "You do not have enough mp" });
                enableButton();
            }
            else
            {
                //Flinch Animation for Monster 
                FlinchAnimation.Begin();
                await Task.Delay(300);
                IdleAnimation.Begin();

                ActionLogList.Children.Add(new TextBlock() { Text = "You use " + spellName + " and did " + spellDamage + " damage" });

                if (You.getHP() <= 0)
                {
                    youLose();
                    return;
                }

                if (Enemy.getHP() <= 0)
                {
                    youWin();
                    return;
                }


                monsterHPBar.Width = monsterHPBarWidth * Enemy.getHP() / Enemy.getHPStart();
                monsterHPText.Text = Enemy.getHP().ToString();
                monsterMPBar.Width = monsterMPBarWidth * Enemy.getMP() / Enemy.getMPStart();
                monsterMPText.Text = Enemy.getMP().ToString();

                monsterAttack();
            }
        }

        void itemClick(object sender, RoutedEventArgs e)
        {
            //Display Action Log list
            ActionLogLabel.Visibility = Visibility.Visible;
            ActionLogScroll.Visibility = Visibility.Visible;
            ItemListLabel.Visibility = Visibility.Collapsed;
            ItemListScroll.Visibility = Visibility.Collapsed;

            //Find item and store item values for easy display
            int itemIndex = You.findItem(((Button)sender).Content.ToString().Substring(0, ((Button)sender).Content.ToString().Length - 3));
            string itemName = You.getItemList()[itemIndex].getName();   //get "Item" instead of "Item xNumItem"
            int itemHeal = You.getItemList()[itemIndex].getHeal();

            //Use selected item
            bool used = You.useItem(itemName);
            if (!used)
            {
                ActionLogList.Children.Add(new TextBlock() { Text = "You don't have that item!" });
                enableButton();
            }
            else
            {
                ActionLogList.Children.Add(new TextBlock() { Text = "You use " + itemName + " and recover " + itemHeal.ToString() + "hp" });

                if (You.getHP() <= 0)
                {
                    youLose();
                    return;
                }

                if (Enemy.getHP() <= 0)
                {
                    youWin();
                    return;
                }

                monsterAttack();
            }
        }

        private async void AttackB_Click(object sender, RoutedEventArgs e)
        {
            disableButton();

            if (Enemy.getHP() <= 0 || You.getHP() <= 0 || fled)
            {
                battleEndMessage();  //bring up notification if you win, lose, or fled
                return;
            }
            double damage = You.attackObject(ref Enemy);
            ActionLogList.Children.Add(new TextBlock() { Text = "You did " + (int)damage + " damage to " + Enemy.getName() });

            //Flinch Animation for Monster 
            FlinchAnimation.Begin();
            await Task.Delay(300);
            IdleAnimation.Begin();

            if (Enemy.getHP() <= 0)
            {
                youWin();
                return;
            }
            else
            {
                monsterHPBar.Width = monsterHPBarWidth * Enemy.getHP() / Enemy.getHPStart();
                monsterHPText.Text = Enemy.getHP().ToString();
                monsterMPBar.Width = monsterMPBarWidth * Enemy.getMP() / Enemy.getMPStart();
                monsterMPText.Text = Enemy.getMP().ToString();
            }
            ActionLogScroll.UpdateLayout();   //make sure historyScroll is update to include the added element
            ActionLogScroll.ScrollToVerticalOffset(ActionLogList.ActualHeight);     //scroll to bottom
            monsterAttack();

        }

        private void SpellB_Click(object sender, RoutedEventArgs e)
        {
            disableButton();

            if (Enemy.getHP() <= 0 || You.getHP() <= 0 || fled)
            {
                battleEndMessage();  //bring up notification if you win, lose, or fled
                return;
            }

            //Set up spell list
            SpellList.Children.Clear();
            spellButton = new Button[You.getSpellList().Length];
            for (int i = 0; i < You.getNumSpells(); i++)
            {
                if (You.getSpellList()[i] == null)
                {
                    break;
                }
                spellButton[i] = new Button() { Content = You.getSpellList()[i].getName() + " - " + You.getSpellList()[i].getMPCost() + "mp" };     //new button with content = "Spell - MPCostmp";
                spellButton[i].Click += spellClick;
                SpellList.Children.Add(spellButton[i]);
            }

            //Display item list
            ActionLogLabel.Visibility = Visibility.Collapsed;
            ActionLogScroll.Visibility = Visibility.Collapsed;

            SpellListLabel.Visibility = Visibility.Visible;
            SpellListScroll.Visibility = Visibility.Visible;

            if (You.getHP() <= 0)
            {
                youLose();
                return;
            }

            if (Enemy.getHP() <= 0)
            {
                youWin();
                return;
            }

        }

        private void DefendB_Click(object sender, RoutedEventArgs e)
        {
            disableButton();

            if (Enemy.getHP() <= 0 || You.getHP() <= 0 || fled)
            {
                battleEndMessage();  //bring up notification if you win, lose, or fled
                return;
            }
            KeyValuePair<double, int> result = Enemy.attackDefended(ref You);

            ActionLogList.Children.Add(new TextBlock() { Text = Enemy.getName() + " uses " + Enemy.getMoveList()[result.Value].getName() + " and did " + (int)result.Key + " damage to you" });

            if (You.getHP() <= 0)
            {
                youLose();
                return;
            }
            else
            {
                yourHPBar.Width = playerHPBarWidth * You.getHP() / You.getHPStart();
                yourHPText.Text = You.getHP().ToString();
                yourMPBar.Width = playerHPBarWidth * You.getMP() / You.getMPStart();
                yourMPText.Text = You.getMP().ToString();
            }

            ActionLogScroll.UpdateLayout();   //make sure historyScroll is update to include the added element
            ActionLogScroll.ScrollToVerticalOffset(ActionLogList.ActualHeight);     //scroll to bottom

            enableButton();
        }

        private void ItemB_Click(object sender, RoutedEventArgs e)
        {
            if (Enemy.getHP() <= 0 || You.getHP() <= 0 || fled)
            {
                battleEndMessage();  //bring up notification if you win, lose, or fled
                return;
            }

            //Set up item list
            ItemList.Children.Clear();
            itemButton = new Button[You.getItemList().Length];
            for (int i = 0; i < You.getItemList().Length; i++)
            {
                if (You.getItemList()[i] == null)
                {
                    break;
                }
                itemButton[i] = new Button() { Content = You.getItemList()[i].getName() + " x" + You.getNumItemList()[i] };     //new button with content = "Item xNumItem";
                itemButton[i].Click += itemClick;
                ItemList.Children.Add(itemButton[i]);
            }

            //Display item list
            ActionLogLabel.Visibility = Visibility.Collapsed;
            ActionLogScroll.Visibility = Visibility.Collapsed;

            ItemListLabel.Visibility = Visibility.Visible;
            ItemListScroll.Visibility = Visibility.Visible;
        }

        private void FleeB_Click(object sender, RoutedEventArgs e)
        {
            disableButton();

            if (Enemy.getHP() <= 0 || You.getHP() <= 0 || fled)
            {
                battleEndMessage();  //bring up notification if you win, lose, or fled
                return;
            }

            if (!fled)
            {
                youFlee();
            }
            else
            {
                fled = true;
                battleEndMessage();
            }
        }

        private void monsterAttack()
        {
            if (Enemy.getHP() <= 0 || You.getHP() <= 0 || fled)
            {
                battleEndMessage();  //bring up notification if you win, lose, or fled
                return;
            }
            KeyValuePair<double, int> result = Enemy.attack(ref You);

            ActionLogList.Children.Add(new TextBlock() { Text = Enemy.getName() + " uses " + Enemy.getMoveList()[result.Value].getName() + " and did " + (int)result.Key + " damage to you" });

            if (You.getHP() <= 0)
            {
                youLose();
                yourHPBar.Width = 0;
                yourHPText.Text = "0";
                return;
            }
            else
            {
                yourHPBar.Width = playerHPBarWidth * You.getHP() / You.getHPStart();
                yourHPText.Text = You.getHP().ToString();
                yourMPBar.Width = playerHPBarWidth * You.getMP() / You.getMPStart();
                yourMPText.Text = You.getMP().ToString();
            }

            ActionLogScroll.UpdateLayout();   //make sure historyScroll is update to include the added element
            ActionLogScroll.ScrollToVerticalOffset(ActionLogList.ActualHeight);     //scroll to bottom

            enableButton();
        }

        private void youWin()
        {
            ActionLogList.Children.Add(new TextBlock() { Text = "You Win!" });
            ActionLogScroll.UpdateLayout();   //make sure historyScroll is update to include the added element
            ActionLogScroll.ScrollToVerticalOffset(ActionLogList.ActualHeight);     //scroll to bottom
            BackgroundMusic.Source = new Uri(this.BaseUri, "ms-appx:///Assets/Musics/Chrono Trigger Music - Lucca's Theme.mp3");

            monsterHPBar.Width = 0;
            monsterHPText.Text = "0";

            //Dying animation for Enemy
            DeadAnimation.Begin();

            battleEndMessage();
        }

        private void youLose()
        {
            ActionLogList.Children.Add(new TextBlock() { Text = "You Lose!" });
            ActionLogScroll.UpdateLayout();   //make sure historyScroll is update to include the added element
            ActionLogScroll.ScrollToVerticalOffset(ActionLogList.ActualHeight);     //scroll to bottom
            BackgroundMusic.Source = new Uri(this.BaseUri, "ms-appx:///Assets/Musics/Chrono Trigger Music - Game Over.mp3");

            battleEndMessage();
        }

        private void youFlee()
        {
            ActionLogList.Children.Add(new TextBlock() { Text = "You run away!" });
            ActionLogScroll.UpdateLayout();   //make sure historyScroll is update to include the added element
            ActionLogScroll.ScrollToVerticalOffset(ActionLogList.ActualHeight);     //scroll to bottom
            BackgroundMusic.Source = new Uri(this.BaseUri, "ms-appx:///Assets/Musics/Chrono Trigger Music - Game Over.mp3");
            fled = true;

            battleEndMessage();
        }

        private async void battleEndMessage()   //display message of battle outcome
        {
            var messageDialog = new MessageDialog("");

            if (fled)
            {
                messageDialog = new MessageDialog("You fled!");
                messageDialog.Title = "Run Away";
            }
            else if (Enemy.getHP() <= 0)
            {
                messageDialog = new MessageDialog("You won!");
                messageDialog.Title = "Victory";
            }

            if (You.getHP() <= 0)
            {
                messageDialog = new MessageDialog("You lost!");
                messageDialog.Title = "Game Over";
            }

            messageDialog.Commands.Add(new UICommand(
            "Retry",
            new UICommandInvokedHandler(this.CommandInvokedHandler)));

            messageDialog.Commands.Add(new UICommand(
            "Close"));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 1;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog and wait
            await messageDialog.ShowAsync();

            enableButton();
        }

        private void CommandInvokedHandler(IUICommand command)  //clear action log and reset hp, mp and music
        {
            restartGame();
        }

        private void RestartB_Click(object sender, RoutedEventArgs e)   //clear action log and reset hp, mp and music
        {
            restartGame();
        }

        private void PauseB_Click(object sender, RoutedEventArgs e) //pause background music
        {
            if (BackgroundMusic.Volume == 0)
            {
                BackgroundMusic.Volume = 1;
            }
            else
            {
                BackgroundMusic.Volume = 0;
            }
        }

        private void disableButton()    //disable button functionality to prevent rapid clicking
        {
            AttackB.IsEnabled = false;
            SpellB.IsEnabled = false;
            DefendB.IsEnabled = false;
            ItemB.IsEnabled = false;
            FleeB.IsEnabled = false;
        }

        private void enableButton() //enable button functionality
        {
            AttackB.IsEnabled = true;
            SpellB.IsEnabled = true;
            DefendB.IsEnabled = true;
            ItemB.IsEnabled = true;
            FleeB.IsEnabled = true;
        }

        private void restartGame()  //clear action log and reset hp, mp and music
        {
            viewbox.Opacity = 100;
            Enemy.setHP(Enemy.getHPStart());
            monsterHPBar.Width = monsterFullHPBar.ActualWidth;
            monsterMPBar.Width = monsterFullMPBar.ActualWidth;
            monsterHPText.Text = Enemy.getHPStart().ToString();
            You.setHP(You.getHPStart());
            yourHPBar.Width = yourFullHPBar.ActualWidth;
            yourMPBar.Width = yourFullMPBar.ActualWidth;
            yourHPText.Text = You.getHPStart().ToString();
            ActionLogList.Children.Clear();
            BackgroundMusic.Source = new Uri(this.BaseUri, "ms-appx:///Assets/Musics/Chrono Trigger Music - Battle Theme.mp3");
            fled = false;

            enableButton();
        }

        private void MonsterInfoGrid_SizeChanged(object sender, SizeChangedEventArgs e) //update monster info bar size, will be call when page is loaded 
        {
            monsterHPBarWidth = monsterFullHPBar.ActualWidth;
            monsterMPBarWidth = monsterFullMPBar.ActualWidth;

            if (Enemy.getHP() <= 0)
            {
                monsterHPBar.Width = 0;
                monsterHPText.Text = "0";
            }
            else
            {
                monsterHPBar.Width = monsterHPBarWidth * Enemy.getHP() / Enemy.getHPStart();
                monsterHPText.Text = Enemy.getHP().ToString();
                monsterMPBar.Width = monsterMPBarWidth * Enemy.getMP() / Enemy.getMPStart();
                monsterMPText.Text = Enemy.getMP().ToString();
            }

        }

        private void PlayerInfoGrid_SizeChanged(object sender, SizeChangedEventArgs e)  //update player info bar size, will be call when page is loaded 
        {
            playerHPBarWidth = yourFullMPBar.ActualWidth;
            playerMPBarWidth = yourFullMPBar.ActualWidth;

            if (You.getHP() <= 0)
            {
                yourHPBar.Width = 0;
                yourHPText.Text = "0";
            }
            else
            {
                yourHPBar.Width = playerHPBarWidth * You.getHP() / You.getHPStart();
                yourHPText.Text = You.getHP().ToString();
                yourMPBar.Width = playerMPBarWidth * You.getMP() / You.getMPStart();
                yourMPText.Text = You.getMP().ToString();
            }
        }
    }
}