using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Ktos.Aisle.Engine.Areas;
using WalkaChomika.Models;
using WalkaChomika2016.Engine;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WalkaChomika
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Area currentArea;
        private Location currentLocation;
        private Animal player;

        public MainPage()
        {
            this.InitializeComponent();

            currentArea = new Assets.HamsterVillage().GetArea();
            currentLocation = currentArea.GetLocation(currentArea.StartingPoint);
            txtLog.AddToBeginning($"Przybyłeś do {currentArea.Name}");

            player = new Animal { Name = "Staszek", HP = 10, Damage = 1, Mana = 0 };
            UpdatePlayer();

            UpdateLocation();
        }

        private void UpdatePlayer()
        {
            meName.Text = player.Name;
            meDamage.Text = $"Dmg: 0-{player.Damage}";
            meHP.Text = $"HP: {player.HP}";
        }

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
