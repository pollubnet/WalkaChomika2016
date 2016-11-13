using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace WalkaChomika.Engine
{
    public static class Extensions
    {
        public static void AddToBeginning(this TextBlock textBlock, string text)
        {
            textBlock.Text = text + "\n\n" + textBlock.Text;
        }
    }
}
