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
        private Animal player;

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
            var f = (Animal[])e.Parameter;
            player = f[0];
            enemy = f[1];

            UpdatePlayer();
            UpdateEnemy();

            if (player.Agility > enemy.Agility)
                isMyTurn = true;
            else
                isMyTurn = false;

            if (!(player is MagicAnimal))
                btnMagicAttack.IsEnabled = false;
        }

        /// <summary>
        /// Wyświetla zaktualizowane dane gracza
        /// </summary>
        private void UpdatePlayer()
        {
            meName.Text = player.Name;
            meDamage.Text = $"Dmg: 0-{player.Damage}";
            meHP.Text = string.Format("HP: {0}", player.HP);

            if (player is MagicAnimal)
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
            Random r = new Random();

            if (r.Next(10) > enemy.Agility)
            {
                if (isMyTurn)
                {
                    int dmg = r.Next(player.Damage + 1);
                    enemy.HP -= dmg;

                    if (enemy.HP < 0)
                        Win();

                    UpdateEnemy();
                    txtStatus.AddToBeginning($"{player.Name} zadał {dmg} obrażeń.");
                }
                else
                {
                    int dmg = r.Next(enemy.Damage + 1);
                    player.HP -= dmg;

                    if (player.HP < 0)
                        Lose();

                    UpdatePlayer();
                    txtStatus.AddToBeginning($"{enemy.Name} zadał {dmg} obrażeń.");
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
        }

        private void Win()
        {
            throw new NotImplementedException();
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
            if (isMyTurn)
            {
                int dmg = (player as MagicAnimal).MagicAttack();
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