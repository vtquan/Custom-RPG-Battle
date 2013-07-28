using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Custom_RPG_Battle.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
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
        #region Game Global Variables
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        Monster Enemy;
        Player You;

        Button[] itemButton;
        Button[] spellButton;

        string tempSpellName;  
        string tempItemName;

        Random random = new Random();
        bool fled = false;  //check if the flee button has been pressed

        //store HP and MP bar current width
        double monsterHPBarWidth;
        double playerHPBarWidth;
        double monsterMPBarWidth;
        double playerMPBarWidth;
        #endregion

        public FightPage()
        {
            this.InitializeComponent();

            SetUpPage();    //initialyze the page with proper information
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

        #region UI Methods
        private void MonsterInfoGrid_SizeChanged(object sender, SizeChangedEventArgs e)
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
                RefreshHpMpBar();
            }

        }

        private void PlayerInfoGrid_SizeChanged(object sender, SizeChangedEventArgs e)
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
                RefreshHpMpBar();
            }
        }

        private void DisplayActionLog()
        {
            ActionLogLabel.Visibility = Visibility.Visible;
            ActionLogScroll.Visibility = Visibility.Visible;
            SpellListLabel.Visibility = Visibility.Collapsed;
            SpellListScroll.Visibility = Visibility.Collapsed;
            ItemListLabel.Visibility = Visibility.Collapsed;
            ItemListScroll.Visibility = Visibility.Collapsed;
        }

        private void DisplayItemList()
        {
            ActionLogLabel.Visibility = Visibility.Collapsed;
            ActionLogScroll.Visibility = Visibility.Collapsed;
            SpellListLabel.Visibility = Visibility.Collapsed;
            SpellListScroll.Visibility = Visibility.Collapsed;
            ItemListLabel.Visibility = Visibility.Visible;
            ItemListScroll.Visibility = Visibility.Visible;
        }

        private void DisplaySpellList()
        {
            ActionLogLabel.Visibility = Visibility.Collapsed;
            ActionLogScroll.Visibility = Visibility.Collapsed;
            SpellListLabel.Visibility = Visibility.Visible;
            SpellListScroll.Visibility = Visibility.Visible;
            ItemListLabel.Visibility = Visibility.Collapsed;
            ItemListScroll.Visibility = Visibility.Collapsed;
        }

        private void RefreshHpMpBar()
        {
            yourHPBar.Width = playerHPBarWidth * You.getHP() / You.getHPStart();
            yourHPText.Text = You.getHP().ToString();
            yourMPBar.Width = playerHPBarWidth * You.getMP() / You.getMPStart();
            yourMPText.Text = You.getMP().ToString();

            monsterHPBar.Width = monsterHPBarWidth * Enemy.getHP() / Enemy.getHPStart();
            monsterHPText.Text = Enemy.getHP().ToString();
            monsterMPBar.Width = monsterMPBarWidth * Enemy.getMP() / Enemy.getMPStart();
            monsterMPText.Text = Enemy.getMP().ToString();
        }

        private void AddMessageToActionLog(string Message)
        {
            ActionLogList.Children.Add(new TextBlock() { Text = Message });

            RefreshActionLog();
        }

        private void RefreshActionLog()
        {
            ActionLogScroll.UpdateLayout();   //make sure historyScroll is update to include the added element
            ActionLogScroll.ScrollToVerticalOffset(ActionLogList.ActualHeight);     //scroll to bottom
        }

        private async void ShowMessage(string title, string message)
        {
            var messageDialog = new MessageDialog(message);
            messageDialog.Title = title;

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

            EnableButton();
        }
        #endregion

        #region Animation Methods
        private async void AnimateMonsterFlinch()
        {
            FlinchAnimation.Begin();
            await Task.Delay(300);
            IdleAnimation.Begin();
        }
        #endregion

        #region Game Methods
        private void SetUpPage()
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

            if (!(A1.getName().Equals("")))
                Enemy.addAttack(A1);
            if (!(A2.getName().Equals("")))
                Enemy.addAttack(A2);
            if (!(A3.getName().Equals("")))
                Enemy.addAttack(A3);
            if (!(A4.getName().Equals("")))
                Enemy.addAttack(A4);

            //Creating and adding items  to player
            Item I1 = new Item(localSettings.Values["I1Nm"].ToString(), Convert.ToInt32(localSettings.Values["I1HP"].ToString()));
            Item I2 = new Item(localSettings.Values["I2Nm"].ToString(), Convert.ToInt32(localSettings.Values["I2HP"].ToString()));
            Item I3 = new Item(localSettings.Values["I3Nm"].ToString(), Convert.ToInt32(localSettings.Values["I3HP"].ToString()));
            Item I4 = new Item(localSettings.Values["I4Nm"].ToString(), Convert.ToInt32(localSettings.Values["I4HP"].ToString()));

            if (!(I1.getName().Equals("")))
                You.addItem(I1, Convert.ToInt32(localSettings.Values["I1Qnt"].ToString()));

            if (!(I2.getName().Equals("")))
                You.addItem(I2, Convert.ToInt32(localSettings.Values["I2Qnt"].ToString()));

            if (!(I3.getName().Equals("")))
                You.addItem(I3, Convert.ToInt32(localSettings.Values["I3Qnt"].ToString()));

            if (!(I4.getName().Equals("")))
                You.addItem(I4, Convert.ToInt32(localSettings.Values["I4Qnt"].ToString()));

            //Creating and adding spells  to player
            Spell S1 = new Spell(localSettings.Values["S1Nm"].ToString(), 0, Convert.ToDouble(localSettings.Values["S1MinDmg"].ToString()), Convert.ToDouble(localSettings.Values["S1MaxDmg"].ToString()), Convert.ToInt32(localSettings.Values["S1MP"].ToString()));
            Spell S2 = new Spell(localSettings.Values["S2Nm"].ToString(), 0, Convert.ToDouble(localSettings.Values["S2MinDmg"].ToString()), Convert.ToDouble(localSettings.Values["S2MaxDmg"].ToString()), Convert.ToInt32(localSettings.Values["S2MP"].ToString()));
            Spell S3 = new Spell(localSettings.Values["S3Nm"].ToString(), 0, Convert.ToDouble(localSettings.Values["S3MinDmg"].ToString()), Convert.ToDouble(localSettings.Values["S3MaxDmg"].ToString()), Convert.ToInt32(localSettings.Values["S3MP"].ToString()));
            Spell S4 = new Spell(localSettings.Values["S4Nm"].ToString(), 0, Convert.ToDouble(localSettings.Values["S4MinDmg"].ToString()), Convert.ToDouble(localSettings.Values["S4MaxDmg"].ToString()), Convert.ToInt32(localSettings.Values["S4MP"].ToString()));

            if (!(S1.getName().Equals("")))
                You.addSpell(S1);
            if (!(S2.getName().Equals("")))
                You.addSpell(S2);
            if (!(S3.getName().Equals("")))
                You.addSpell(S3);
            if (!(S4.getName().Equals("")))
                You.addSpell(S4);

            //Set monster portrait
            Object MonPortrait = localSettings.Values["MonPortrait"];

            if ((int)MonPortrait == 1)
                Axalf.Source = new BitmapImage(new Uri("ms-appx:///Assets/Monster Pics/mon1.png"));
            else if ((int)MonPortrait == 2)
                Axalf.Source = new BitmapImage(new Uri("ms-appx:///Assets/Monster Pics/mon2.png"));
            else if ((int)MonPortrait == 3)
                Axalf.Source = new BitmapImage(new Uri("ms-appx:///Assets/Monster Pics/mon3.png"));
            else if ((int)MonPortrait == 4)
                Axalf.Source = new BitmapImage(new Uri("ms-appx:///Assets/Monster Pics/mon4.png"));
            else
                Axalf.Source = new BitmapImage(new Uri("ms-appx:///Assets/Monster Pics/mon5.png"));

            //Display Monster and Player value
            pageTitle.Text = Enemy.getSubtitle() + ": " + Enemy.getName();
            monsterName.Text = Enemy.getName();
            monsterHPText.Text = Enemy.getHPStart().ToString();
            monsterMPText.Text = Enemy.getMPStart().ToString();
            yourName.Text = You.getName();
            yourHPText.Text = You.getHPStart().ToString();
            yourMPText.Text = You.getMPStart().ToString();
        }

        private bool GetGameEnded()
        {
            if (Enemy.getHP() <= 0 || You.getHP() <= 0 || fled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private int GetGameState()
        {
            int state = 0;
            if (Enemy.getHP() <= 0)
            {
                state = 1;
            }
            else if (You.getHP() <= 0)
            {
                state = 2;
            }
            else if (fled)
            {
                state = 3;
            }

            return state;
        }

        private void SetUpSpellList()
        {
            SpellList.Children.Clear();
            spellButton = new Button[You.getSpellList().Length];
            for (int i = 0; i < You.getNumSpells(); i++)
            {
                if (You.getSpellList()[i] == null)
                {
                    break;
                }
                spellButton[i] = new Button() { Content = You.getSpellList()[i].getName() };
                spellButton[i].Click += SpellClick;
                spellButton[i].PointerEntered += SpellButton_Enter;
                spellButton[i].PointerExited += SpellButton_Exit;
                spellButton[i].Width = 150;
                SpellList.Children.Add(spellButton[i]);
            }

            Button returnButton = new Button() { Content = "Return" };
            returnButton.Click += returnButton_Click;
            returnButton.Width = 150;
            SpellList.Children.Add(returnButton);
        }

        private void SetUpItemList()
        {
            ItemList.Children.Clear();
            itemButton = new Button[You.getItemList().Length];
            for (int i = 0; i < You.getItemList().Length; i++)
            {
                if (You.getItemList()[i] == null)
                {
                    break;
                }
                itemButton[i] = new Button() { Content = You.getItemList()[i].getName() };
                itemButton[i].Click += ItemClick;
                itemButton[i].PointerEntered += ItemButton_Enter;
                itemButton[i].PointerExited += ItemButton_Exit;
                itemButton[i].Width = 150;
                ItemList.Children.Add(itemButton[i]);
            }

            Button returnButton = new Button() { Content = "Return" };
            returnButton.Click += returnButton_Click;
            returnButton.Width = 150;
            ItemList.Children.Add(returnButton);
        }
        #endregion
        
        private void AttackB_Click(object sender, RoutedEventArgs e)
        {
            DisableButton();

            DisplayActionLog();

            if (GetGameEnded())
            {
                return;
            }

            double damage = You.attackObject(ref Enemy);
            AddMessageToActionLog("You did " + (int)damage + " damage to " + Enemy.getName());

            AnimateMonsterFlinch();

            if (Enemy.getHP() <= 0)
            {
                YouWin();
                return;
            }
            else
            {
                RefreshHpMpBar();
            }

            RefreshActionLog();

            MonsterAttack();
        }

        private void SpellB_Click(object sender, RoutedEventArgs e)
        {
            DisableButton();

            if (GetGameEnded())
            {
                return;
            }

            SetUpSpellList();

            DisplaySpellList();
        }

        private void ItemB_Click(object sender, RoutedEventArgs e)
        {
            DisableButton();

            if (GetGameEnded())
            {
                return;
            }

            SetUpItemList();

            DisplayItemList();
        }

        private void DefendB_Click(object sender, RoutedEventArgs e)
        {
            DisableButton();

            if (GetGameEnded())
            {
                return;
            }

            KeyValuePair<double, int> result = Enemy.attackDefended(ref You);

           AddMessageToActionLog(Enemy.getName() + " uses " + Enemy.getMoveList()[result.Value].getName() + " and did " + (int)result.Key + " damage to you");

            if (You.getHP() <= 0)
            {
                YouLose();
                return;
            }
            else
            {
                RefreshHpMpBar();
            }

            RefreshActionLog();

            EnableButton();
        }

        private void FleeB_Click(object sender, RoutedEventArgs e)
        {
            DisableButton();

            if (GetGameEnded())
            {
                return;
            }

            if (!fled)
            {
                YouFlee();
            }
            else
            {
                fled = true;
                YouLose();
            }
        }

        private void MonsterAttack()
        {
            if (GetGameEnded())
            {
                return;
            }

            KeyValuePair<double, int> result = Enemy.attack(ref You);

            AddMessageToActionLog(Enemy.getName() + " uses " + Enemy.getMoveList()[result.Value].getName() + " and did " + (int)result.Key + " damage to you");

            if (You.getHP() <= 0)
            {
                YouLose();
                yourHPBar.Width = 0;
                yourHPText.Text = "0";
                return;
            }
            else
            {
                RefreshHpMpBar();
            }

            RefreshActionLog();

            EnableButton();
        }

        private void YouWin()
        {
            AddMessageToActionLog("You Win!");

            RefreshActionLog();

            BackgroundMusic.Source = new Uri(this.BaseUri, "ms-appx:///Assets/Musics/Chrono Trigger Music - Lucca's Theme.mp3");

            monsterHPBar.Width = 0;
            monsterHPText.Text = "0";

            //Dying animation for Enemy
            DeadAnimation.Begin();

            ShowMessage("Victory", "You won!");
        }

        private void YouLose()
        {
            AddMessageToActionLog("You Lose!");
            
            RefreshActionLog();

            BackgroundMusic.Source = new Uri(this.BaseUri, "ms-appx:///Assets/Musics/Chrono Trigger Music - Game Over.mp3");

            ShowMessage("Game Over", "You lost!");
        }

        private void YouFlee()
        {
            AddMessageToActionLog("You run away!");

            RefreshActionLog();

            BackgroundMusic.Source = new Uri(this.BaseUri, "ms-appx:///Assets/Musics/Chrono Trigger Music - Game Over.mp3");
            fled = true;

            ShowMessage("Run Away", "You fled!");
        }

        private void CommandInvokedHandler(IUICommand command)  //clear action log and reset hp, mp and music
        {
            RestartGame();
        }

        private void RestartB_Click(object sender, RoutedEventArgs e)   //clear action log and reset hp, mp and music
        {
            RestartGame();
        }

        private void PauseMusicB_Click(object sender, RoutedEventArgs e) //pause background music
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

        private void DisableButton()    //disable button functionality to prevent rapid clicking
        {
            AttackB.IsEnabled = false;
            SpellB.IsEnabled = false;
            DefendB.IsEnabled = false;
            ItemB.IsEnabled = false;
            FleeB.IsEnabled = false;
        }

        private void EnableButton() //enable button functionality
        {
            AttackB.IsEnabled = true;
            SpellB.IsEnabled = true;
            DefendB.IsEnabled = true;
            ItemB.IsEnabled = true;
            FleeB.IsEnabled = true;
        }

        private void RestartGame()  //clear action log and reset hp, mp and music
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

            EnableButton();
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            ActionLogLabel.Visibility = Visibility.Visible;
            ActionLogScroll.Visibility = Visibility.Visible;
            SpellListLabel.Visibility = Visibility.Collapsed;
            SpellListScroll.Visibility = Visibility.Collapsed;
            ItemListLabel.Visibility = Visibility.Collapsed;
            ItemListScroll.Visibility = Visibility.Collapsed;

            EnableButton();
        }

        private void SpellClick(object sender, RoutedEventArgs e)
        {
            DisplayActionLog();

            //Find item and store item values for easy display
            int spellIndex = You.findSpell(tempSpellName);
            string spellName = You.getSpellList()[spellIndex].getName();
            int spellDamage;

            //Use selected item
            KeyValuePair<bool, int[]> result = You.useSpell(spellName, ref Enemy);
            spellDamage = result.Value[0];
            if (!result.Key)
            {
                AddMessageToActionLog("You do not have enough mp");
                EnableButton();
            }
            else
            {
                AnimateMonsterFlinch();

                AddMessageToActionLog("You use " + spellName + " and did " + spellDamage + " damage");

                if (You.getHP() <= 0)
                {
                    YouLose();
                    return;
                }

                if (Enemy.getHP() <= 0)
                {
                    YouWin();
                    return;
                }

                RefreshHpMpBar();

                MonsterAttack();
            }
        }
        
        private void SpellButton_Enter(object sender, PointerRoutedEventArgs e)
        {
            tempSpellName = ((Button)sender).Content.ToString();
            int spellIndex = You.findSpell(tempSpellName);
            string spellMP = You.getSpellList()[spellIndex].getMPCost().ToString() + " MP";
            ((Button)sender).Content = spellMP;
        }

        private void SpellButton_Exit(object sender, PointerRoutedEventArgs e)
        {
            ((Button)sender).Content = tempSpellName;
        }

        private void ItemClick(object sender, RoutedEventArgs e)
        {
            DisplayActionLog();

            //Find item and store item values for easy display
            int itemIndex = You.findItem(tempItemName);
            string itemName = You.getItemList()[itemIndex].getName();
            int itemHeal = You.getItemList()[itemIndex].getHeal();

            //Use selected item
            bool used = You.useItem(itemName);
            if (!used)
            {
                AddMessageToActionLog("You don't have that item!");
                EnableButton();
            }
            else
            {
                AddMessageToActionLog("You use " + itemName + " and recover " + itemHeal.ToString() + "hp");

                if (You.getHP() <= 0)
                {
                    YouLose();
                    return;
                }

                if (Enemy.getHP() <= 0)
                {
                    YouWin();
                    return;
                }

                MonsterAttack();
            }
        }

        private void ItemButton_Enter(object sender, RoutedEventArgs e)
        {
            tempItemName = ((Button)sender).Content.ToString();
            int itemIndex = You.findItem(tempItemName);
            string itemNum = You.getNumItemList()[itemIndex].ToString() + " Qnt";
            ((Button)sender).Content = itemNum;
        }

        private void ItemButton_Exit(object sender, PointerRoutedEventArgs e)
        {
            ((Button)sender).Content = tempItemName;
        }
    }
}