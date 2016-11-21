#region License

/*
 * Written in 2016/2017 by pollub.net members
 *
 * To the extent possible under law, the author(s) have dedicated
 * all copyright and related and neighboring rights to this
 * software to the public domain worldwide. This software is
 * distributed without any warranty.
 *
 * You should have received a copy of the CC0 Public Domain
 * Dedication along with this software. If not, see
 * <http://creativecommons.org/publicdomain/zero/1.0/>.
 */

#endregion License

using System;
using WalkaChomika.Engine;
using WalkaChomika.Models;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WalkaChomika
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to
    /// within a Frame.
    /// </summary>
    public sealed partial class FightPage : Page
    {
        private Animal enemy;        

        private bool isMyTurn;

        public FightPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Funkcja wywoływana w momencie, kiedy aplikacja przejdzie do
        /// tej strony. Odczytuje dane, które przyszły z nawigacji
        /// (przeciwnika) oraz go umieszcza w odpowiedniej zmiennej.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var player = App.Player;

            enemy = (Animal)e.Parameter;

            UpdatePlayer();
            UpdateEnemy();

            if (player.Agility > enemy.Agility)
                isMyTurn = true;
            else
                isMyTurn = false;

            if (!(player is IMagicAnimal))
                btnMagicAttack.IsEnabled = false;
        }

        /// <summary>
        /// Wyświetla zaktualizowane dane gracza
        /// </summary>
        private void UpdatePlayer()
        {
            var player = App.Player;

            meName.Text = player.Name;
            meDamage.Text = $"Dmg: 0-{player.Damage}";
            meHP.Text = string.Format("HP: {0}", player.HP);

            if (player is IMagicAnimal)
                meMana.Text = $"Mana: {player.Mana}";
            else
                meMana.Text = "Nie jesteś magiem.";
        }

        /// <summary>
        /// Wyświetla zaktualizowane dane przeciwnika
        /// </summary>
        private void UpdateEnemy()
        {
            enemyName.Text = enemy.Name;
            enemyHP.Text = $"HP: {enemy.HP}";
        }

        /// <summary>
        /// Metoda którą symuluje walkę miedzy dwoma zwierzętami
        /// </summary>
        public void Fight()
        {
            var player = App.Player;

            Random r = new Random();

            if (isMyTurn)
            {
                if (r.Next(10) > enemy.Agility)
                {
                    var dmg = player.Attack();
                    enemy.HP -= dmg;

                    if (!enemy.IsAlive())
                        Win();

                    UpdateEnemy();
                    txtStatus.AddToBeginning($"{player.Name} zadał {dmg} obrażeń.");
                }
                else
                {
                    txtStatus.AddToBeginning($"{player.Name} nie trafił.");
                }                               
            }
            else
            {
                if (r.Next(10) > player.Agility)
                {
                    var dmg = enemy.Attack();
                    player.HP -= dmg;

                    if (!player.IsAlive())
                        Lose();

                    UpdatePlayer();
                    txtStatus.AddToBeginning($"{enemy.Name} zadał {dmg} obrażeń.");
                }
                else
                {
                    txtStatus.AddToBeginning($"{enemy.Name} nie trafił.");
                }
            }

            

            isMyTurn = !isMyTurn;
        }

        private void Lose()
        {
            string message = "Przegrałeś.";
            MessageDialog dlg = new MessageDialog(message);

            dlg.ShowAsync();
            btnBite.IsEnabled = false;
            btnRun.IsEnabled = false;
            btnMagicAttack.IsEnabled = false;
        }

        private async void Win()
        {
            string message = "Wygrałeś.";
            MessageDialog dlg = new MessageDialog(message);

            await dlg.ShowAsync();

            Frame.GoBack();
        }

        /// <summary>
        /// Zdarzenie klinięcia przycisku "Walcz"
        /// </summary>
        private void btnFight_Click(object sender, RoutedEventArgs e)
        {
            if (isMyTurn)
                Fight();
            else
                Fight();           
        }

        /// <summary>
        /// Obsługa kliknięcia przycisku "Uciekaj"
        /// </summary>
        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            if (isMyTurn)
            {
                Random r = new Random();
                if (r.NextDouble() > 0.5)
                {
                    Frame.GoBack();
                }
            }

            isMyTurn = !isMyTurn;
        }

        private void btnMagicAttack_Click(object sender, RoutedEventArgs e)
        {
            var player = App.Player;

            if (isMyTurn)
            {
                int dmg = (player as IMagicAnimal).MagicAttack();
                enemy.HP -= dmg;

                if (enemy.HP < 0)
                    Win();

                UpdateEnemy();
                txtStatus.AddToBeginning($"{player.Name} zadał {dmg} obrażeń.");
            }
            else
                Fight();
        }
    }
}