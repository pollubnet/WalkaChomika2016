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

using System.Collections.Generic;
using WalkaChomika.Engine;

namespace WalkaChomika.Assets
{
    /// <summary>
    /// Klasa reprezentująca pierwszy ze światów gry
    /// </summary>
    internal class HamsterVillage
    {
        private Area village;

        /// <summary>
        /// Tworzy lokacje w wiosce chomików oraz dodaje tam przeciwników
        /// </summary>
        public HamsterVillage()
        {
            village = new Area { Id = 1, Name = "Wioska Chomików", StartingPoint = new Point3 { X = 0, Y = 0, Z = 0 } };
            village.Locations = new List<Location>();

            village.Locations.Add(new Location(0, 0, 0, "Brama Wioski Chomików", "Brama wioski chomików jest bardzo zakurzona, bo dawno tutaj nikt nie sprzątał.", Neswdu.South));

            var a1 = new Location(0, 1, 0, "Ulica Bramowa", "Ulica Bramowa prowadzi od północnej bramy na końcu świata do centrum wioski. Wydaje ci się, że na ziemi widzisz ślady krwi.", Neswdu.South | Neswdu.North);
            a1.Enemies = new List<Models.Animal>();
            //a1.Enemies.Add(new Models.Animal() { Name = "Żaba Strażnik", Damage = 2, HP = 10, Mana = 0 });

            a1.Enemies.Add(new Models.FrogSentry());
            a1.Enemies.Add(new Models.FrogSentry());

            village.Locations.Add(a1);

            village.Locations.Add(new Location(0, 2, 0, "Plac Główny", "Główny plac wioski leży na skrzyżowaniu Ulicy Bramowej oraz Ulicy Pałacowej, prowadzących do bramy oraz do pałacu, odpowiednio. Pamiętasz, kiedy był pełen chomików sprzedających różne towary, dzisiaj jednak jest całkowicie pusty i wymarły. Na ziemi są duże ilości krwi i ślady walki.", Neswdu.East | Neswdu.North));
            village.Locations.Add(new Location(1, 2, 0, "Ulica Pałacowa", "Ulica Pałacowa prowadzi w kierunku pałacu Króla Chomików. Na ziemi są resztki broni oraz futra pozostałe z pewnością po potężnej walce.", Neswdu.East | Neswdu.West));
            village.Locations.Add(new Location(2, 2, 0, "Brama Pałacowa", "Brama Pałacowa broni dostępu do pałacu Króla Chomików. Odkąd pamiętasz, zawsze była zamknięta, dzisiaj jednak jest w drzazgach na ziemi, zniszczona potężnym uderzeniem.", Neswdu.East | Neswdu.West));

            var a2 = new Location(3, 2, 0, "Dziedziniec Pałacu", "Okazały dziedziniec pałacu jest w opłakanym stanie. Mury są pokruszone, wszędzie widać ślady niedawnej walki.", Neswdu.West);
            a2.Enemies = new List<Models.Animal>();
            //a2.Enemies.Add(new Models.Animal() { Name = "Żaba Wojownik", Damage = 5, HP = 20, Mana = 0 });
            a2.Enemies.Add(new Models.Pegasus("Dżesika"));
            village.Locations.Add(a2);
        }

        /// <summary>
        /// Zwraca stworzoną krainę
        /// </summary>
        /// <returns>Zbudowana wioska chomików</returns>
        public Area GetArea()
        {
            return village;
        }
    }
}