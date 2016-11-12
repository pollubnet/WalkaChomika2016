using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ktos.Aisle.Engine.Areas;

namespace WalkaChomika.Assets
{
    class HamsterVillage
    {
        private Area village;

        public HamsterVillage()
        {
            village = new Area { Id = 1, Name = "Wioska Chomików", StartingPoint = new Point3 { X = 0, Y = 0, Z = 0 } };
            village.Locations = new List<Location>();

            village.Locations.Add(new Location(0, 0, 0, "Brama Wioski Chomików", "Brama wioski chomików jest bardzo zakurzona, bo dawno tutaj nikt nie sprzątał.", Neswdu.South));
            village.Locations.Add(new Location(0, 1, 0, "Ulica Bramowa", "Ulica Bramowa prowadzi od północnej bramy na końcu świata do centrum wioski. Wydaje ci się, że na ziemi widzisz ślady krwi.", Neswdu.South | Neswdu.North));
            village.Locations.Add(new Location(0, 2, 0, "Plac Główny", "Główny plac wioski leży na skrzyżowaniu Ulicy Bramowej oraz Ulicy Pałacowej, prowadzących do bramy oraz do pałacu, odpowiednio. Pamiętasz, kiedy był pełen chomików sprzedających różne towary, dzisiaj jednak jest całkowicie pusty i wymarły. Na ziemi są duże ilości krwi i ślady walki.", Neswdu.East | Neswdu.North));
            village.Locations.Add(new Location(1, 2, 0, "Ulica Pałacowa", "Ulica Pałacowa prowadzi w kierunku pałacu Króla Chomików. Na ziemi są resztki broni oraz futra pozostałe z pewnością po potężnej walce.", Neswdu.East | Neswdu.West));
            village.Locations.Add(new Location(2, 2, 0, "Brama Pałacowa", "Brama Pałacowa broni dostępu do pałacu Króla Chomików. Odkąd pamiętasz, zawsze była zamknięta, dzisiaj jednak jest w drzazgach na ziemi, zniszczona potężnym uderzeniem.", Neswdu.East | Neswdu.West));


            var last = new Location(3, 2, 0, "Dziedziniec Pałacu", "Okazały dziedziniec pałacu jest w opłakanym stanie. Mury są pokruszone, wszędzie widać ślady niedawnej walki.", Neswdu.West);
            last.Enemies = new List<Models.Animal>();
            last.Enemies.Add(new Models.Animal() { Name = "Żaba Strażnik", Damage = 2, HP = 10, Mana = 0 });

            village.Locations.Add(last);
        }

        public Area GetArea()
        {
            return village;
        }
    }
}
