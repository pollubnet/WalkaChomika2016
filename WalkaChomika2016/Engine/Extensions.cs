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

using Windows.UI.Xaml.Controls;

namespace WalkaChomika.Engine
{
    /// <summary>
    /// Klasa zawierająca rozszerzenia do istniejących klas
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Rozszerzenie kontrolki TextBlock automatycznie dodające
        /// tekst na jej początek, obecny tekst poprzedzając dwoma
        /// znakami nowej linii
        /// </summary>
        /// <param name="textBlock">
        /// Kontrolka na której wykonywane jest działanie
        /// </param>
        /// <param name="text">
        /// Tekst, który zostanie dodany na początek tekstu kontrolki
        /// </param>
        public static void AddToBeginning(this TextBlock textBlock, string text)
        {
            textBlock.Text = text + "\n\n" + textBlock.Text;
        }
    }
}