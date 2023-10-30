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
using System.Linq;
using WalkaChomika.Engine;
using WalkaChomika.Models;
using Windows.UI.Popups;
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

        public MainPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;

            try
            {
                //currentArea = new Assets.FrogVillage().GetArea();
                currentArea = new Assets.HamsterVillage().GetArea();
                currentLocation = currentArea.GetLocation(currentArea.StartingPoint);
                txtLog.AddToBeginning($"Przybyłeś do {currentArea.Name}");

                App.Player = new HamsterShaman("Staszek");
                UpdatePlayer();

                UpdateLocation();
            }
            catch (NullReferenceException ex)
            {
                var m = new MessageDialog(
                    "Nie da się załadować tej krainy bo nie i już!" + ex.Message
                );
                m.ShowAsync();
            }
            catch (Exception ex)
            {
                var m = new MessageDialog("Nie da się załadować tej krainy, bo: " + ex.Message);
                m.ShowAsync();
            }

            btnChangeName.Click += BtnChangeName_Click;
            btnChangeName.Click += (s, e) =>
            {
                App.Player.Name = App.Player.Name + "!";
            };
        }

        private void BtnChangeName_Click(object sender, RoutedEventArgs e)
        {
            App.Player.Name = GenerateName();
        }

        private string GenerateName()
        {
            Random r = new Random();

            var vovels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            var consonants = "bcdfghjklmnpqrstvxz";

            string result = string.Empty;
            var length = r.Next(7) + 2;
            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0)
                    result += consonants[r.Next(consonants.Length)];
                else
                    result += vovels[r.Next(vovels.Length)];
            }

            result += consonants[r.Next(consonants.Length)];

            return char.ToUpper(result[0]) + result.Substring(1);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            UpdatePlayer();
        }

        /// <summary>
        /// Wyświetla zaktualizowane dane gracza
        /// </summary>
        private void UpdatePlayer()
        {
            var player = App.Player;
            me.DataContext = player;

            //meName.Text = player.Name;
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
        private void UpdateLocation()
        {
            txtLocationTitle.Text = currentLocation.Name;
            txtLocationNeswdu.Text =
                $"Kierunki: {NeswduHelper.ToNaturalLanguage(currentLocation.Neswdu)}";
            txtLocationDescription.Text = currentLocation.Description;

            lbLocationEnemies.ItemsSource = currentLocation.Enemies;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content.ToString())
            {
                case "East":
                    Go(Neswdu.East);
                    break;
                case "West":
                    Go(Neswdu.West);
                    break;
                case "North":
                    Go(Neswdu.North);
                    break;
                case "South":
                    Go(Neswdu.South);
                    break;
            }
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
                try
                {
                    currentLocation = currentArea.GetLocation(
                        NeswduHelper.ToRelativePoint3(currentLocation.Coordinates, course)
                    );
                    UpdateLocation();
                    txtLog.AddToBeginning($"Poszedłeś na {NeswduHelper.ToNaturalLanguage(course)}");
                }
                catch
                {
                    var m = new MessageDialog("Nie da się załadować tej lokacji");
                    m.ShowAsync();
                }
            }
            else
            {
                txtLog.AddToBeginning("Nie możesz tam pójść!");
            }
        }

        private void lbLocationEnemies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbLocationEnemies.SelectedItem != null)
            {
                Frame.Navigate(typeof(FightPage), lbLocationEnemies.SelectedItem);
            }
        }
    }
}
