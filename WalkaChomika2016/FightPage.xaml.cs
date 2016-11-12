using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WalkaChomika.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WalkaChomika
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FightPage : Page
    {
        private Animal Frog;
        private Animal Hamster;

        public FightPage()
        {
            this.InitializeComponent();

            //Tworzymy obiekt Zwierzęcia i przypisujemy referencję do zmiennej Frog, nadajemy mu imię, HP, Damage oraz Mane
            Frog = new Animal();
            Frog.Name = "Basia";
            Frog.HP = 50;
            Frog.Damage = 20;
            Frog.Mana = 0;

            //Tworzymy obiekt Zwierzęcia i przypisujemy referencję do zmiennej Hamster, nadajemy mu imię, HP, Damage oraz Mane
            Hamster = new Animal();
            Hamster.Name = "Janusz";
            Hamster.HP = 70;
            Hamster.Damage = 10;
            Hamster.Mana = 0;
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
                // Gdy została wylosowana liczba mniejsza od 5 to nasz obiekt Żaby będzie atakował Chomika
                Frog.Attack(Hamster);
                // Do kontrolki textBlocka przypisujemy tekst zmiennej dodając w {0} i {1} imiona zwierząt.

                

                txtStatus.Text = string.Format(fightStatus, Frog.Name, Hamster.Name);
                // Sprawdzamy czy chomik nadal żyje po ataku.
                if (!Hamster.IsAlive())
                {
                    // Dodajemy tekst że chomik nie żyje
                    txtStatus.Text += "\nChomik nie żyje!";
                    // Wyłączamy przyciskowi "Wlacz" możliwość klikania.
                    btnBite.IsEnabled = false;
                    // robimy return, czyli wychdozimy z metody ponieważ nie chcemy 
                    // aby pokazały się statusy HP zwierząt, bo mogą tam być HP o minusowej wartości
                    return;
                }
            }
            else
            {
                //W przeciwnym wypadku gdy liczba jest większa od 5 to Chomik atakuje Żabę.
                Hamster.Attack(Frog);
                // Dodajemy status walki do textBlocka
                txtStatus.Text = string.Format(fightStatus, Hamster.Name, Frog.Name);
                // Sprawdzamy czy po ataku Żaba nadal żyje
                if (!Frog.IsAlive())
                {
                    // Dodajemy informację o śmierci żaby
                    txtStatus.Text += "\nŻaba nie żyje!";
                    // Dezaktywnujemy przycisk "Walka" 
                    btnBite.IsEnabled = false;
                    // robimy return, czyli wychdozimy z metody ponieważ nie chcemy 
                    // aby pokazały się statusy HP zwierząt, bo mogą tam być HP o minusowej wartości
                    return;
                }
            }
            //Znak nowej linii
            txtStatus.Text += "\n";
            //Wyświetlamy staus HP żaby
            txtStatus.Text += string.Format(hpStatus, Frog.Name, Frog.HP.ToString());
            //Znak nowej linii
            txtStatus.Text += "\n";
            //Wyświetlamy status HP chomika
            txtStatus.Text += string.Format(hpStatus, Hamster.Name, Hamster.HP.ToString());

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
    }
}
