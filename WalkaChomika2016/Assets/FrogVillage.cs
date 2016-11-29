using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkaChomika.Engine;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace WalkaChomika.Assets
{
    class FrogVillage
    {
        private Area area;

        public FrogVillage()
        {
            area = new Area();
            area.Id = 1;
            area.Name = "Wioska Żab";
            area.StartingPoint = new Point3(0, 0, 0);

            area.Locations = new List<Location>();

            LoadLocationFromFile();
        }

        private async void LoadLocationFromFile()
        {
            StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(@"E:\Marcin\Temp");
            var file = await folder.GetFileAsync("frog.txt");

            //FileOpenPicker openPicker = new FileOpenPicker();
            //openPicker.ViewMode = PickerViewMode.Thumbnail;
            //openPicker.SuggestedStartLocation = PickerLocationId.Downloads;
            //openPicker.FileTypeFilter.Add(".txt");

            //var file = await openPicker.PickSingleFileAsync();
            string desc = await FileIO.ReadTextAsync(file);

            area.Locations.Add(new Location(0, 0, 0, "Wioska Żab", desc, Neswdu.None));

        }

        public Area GetArea()
        {
            return area;
        }
    }
}
