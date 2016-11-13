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

using System.Linq;
using WalkaChomika.Engine;
using WalkaChomika.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WalkaChomika
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to
    /// within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Area currentArea;
        private Location currentLocation;
        private Animal player;

        public MainPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;

            currentArea = new Assets.HamsterVillage().GetArea();
            currentLocation = currentArea.GetLocation(currentArea.StartingPoint);
            txtLog.AddToBeginning($"Przybyłeś do {currentArea.Name}");

            player = new Animal { Name = "Staszek", HP = 10, Damage = 1, Mana = 0 };
            UpdatePlayer();

            UpdateLocation();
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
        private void UpdateLocation()
        {
            txtLocationTitle.Text = currentLocation.Name;
            txtLocationNeswdu.Text = $"Kierunki: {NeswduHelper.ToNaturalLanguage(currentLocation.Neswdu)}";
            txtLocationDescription.Text = currentLocation.Description;
            lbLocationEnemies.ItemsSource = currentLocation.Enemies;
        }

        private void GoNorth(object sender, RoutedEventArgs e)
        {
            Go(Neswdu.North);
        }

        private void GoEast(object sender, RoutedEventArgs e)
        {
            Go(Neswdu.East);
        }

        private void GoWest(object sender, RoutedEventArgs e)
        {
            Go(Neswdu.West);
        }

        /// <summary>
        /// Obsługuje możliwość "pójścia" w daną stronę lub pokazuje
        /// komunikat, że jest to niemożliwe
        /// </summary>
        /// <param name="course">
        /// Kierunek, w którym gracz chce się udać
        /// </param>
        private void Go(Neswdu course)
        {
            if (NeswduHelper.CanIGo(currentLocation.HiddenNeswdu, course))
            {
                currentLocation = currentArea.GetLocation(NeswduHelper.ToRelativePoint3(currentLocation.Coordinates, course));
                UpdateLocation();
                txtLog.AddToBeginning($"Poszedłeś na {NeswduHelper.ToNaturalLanguage(course)}");
            }
            else
            {
                txtLog.AddToBeginning("Nie możesz tam pójść!");
            }
        }

        private void GoSouth(object sender, RoutedEventArgs e)
        {
            Go(Neswdu.South);
        }

        private void lbLocationEnemies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbLocationEnemies.SelectedItem != null)
            {
                Frame.Navigate(typeof(FightPage), new Animal[] { player, currentLocation.Enemies.First() });
            }
        }
    }
}