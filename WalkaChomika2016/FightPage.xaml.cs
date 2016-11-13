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
using WalkaChomika.Models;
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
        }

        /// <summary>
        /// Wyświetla zaktualizowane dane gracza
        /// </summary>
        private void UpdatePlayer()
        {
            meName.Text = player.Name;
            meDamage.Text = $"Dmg: 0-{player.Damage}";
            meHP.Text = $"HP: {player.HP}";
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
            // Tworzymy instancję generatora liczb losowych
            Random generator = new Random();
            // Zmienna dla tekstu ze stausem HP.
            string hpStatus = "Zwierzę {0} ma {1} HP.";
            // Zmiennas ze stasusem przebiegu walki.
            string fightStatus = "Zwierzę {0} zaatakowało zwierzę {1}.";

            // generujemy losową liczbę od 0 do 10
            int whoAttack = generator.Next(10);

            string oldText = txtStatus.Text;

            if (whoAttack < 5)
            {
                // Gdy została wylosowana liczba mniejsza od 5 to nasz
                // obiekt Żaby będzie atakował Chomika
                enemy.Attack(player);
                // Do kontrolki textBlocka przypisujemy tekst zmiennej
                // dodając w {0} i {1} imiona zwierząt.

                txtStatus.Text = string.Format(fightStatus, enemy.Name, player.Name);
                // Sprawdzamy czy chomik nadal żyje po ataku.
                if (!player.IsAlive())
                {
                    // Dodajemy tekst że chomik nie żyje
                    txtStatus.Text += "\nChomik nie żyje!";
                    // Wyłączamy przyciskowi "Wlacz" możliwość klikania.
                    btnBite.IsEnabled = false;
                    // robimy return, czyli wychdozimy z metody
                    // ponieważ nie chcemy aby pokazały się statusy HP
                    // zwierząt, bo mogą tam być HP o minusowej wartości
                    return;
                }
            }
            else
            {
                //W przeciwnym wypadku gdy liczba jest większa od 5 to Chomik atakuje Żabę.
                player.Attack(enemy);
                // Dodajemy status walki do textBlocka
                txtStatus.Text = string.Format(fightStatus, player.Name, enemy.Name);
                // Sprawdzamy czy po ataku Żaba nadal żyje
                if (!enemy.IsAlive())
                {
                    // Dodajemy informację o śmierci żaby
                    txtStatus.Text += "\nŻaba nie żyje!";
                    // Dezaktywnujemy przycisk "Walka"
                    btnBite.IsEnabled = false;
                    // robimy return, czyli wychdozimy z metody
                    // ponieważ nie chcemy aby pokazały się statusy HP
                    // zwierząt, bo mogą tam być HP o minusowej wartości
                    return;
                }
            }
            //Znak nowej linii
            txtStatus.Text += "\n";
            //Wyświetlamy staus HP żaby
            txtStatus.Text += string.Format(hpStatus, enemy.Name, enemy.HP.ToString());
            //Znak nowej linii
            txtStatus.Text += "\n";
            //Wyświetlamy status HP chomika
            txtStatus.Text += string.Format(hpStatus, player.Name, player.HP.ToString());

            txtStatus.Text += "\n\n" + oldText;
        }

        /// <summary>
        /// Zdarzenie klinięcia przycisku "Walcz"
        /// </summary>
        private void btnFight_Click(object sender, RoutedEventArgs e)
        {
            // Wywołujemy metodę Walka
            Fight();
        }

        /// <summary>
        /// Obsługa kliknięcia przycisku "Uciekaj"
        /// </summary>
        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            if (r.NextDouble() > 0.5)
            {
                Frame.GoBack();
            }
        }
    }
}