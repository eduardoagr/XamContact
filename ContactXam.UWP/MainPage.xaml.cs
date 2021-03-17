
using System.IO;

using Windows.Storage;

namespace ContactXam.UWP {
    public sealed partial class MainPage {
        public MainPage() {
            this.InitializeComponent();

            string dbName = "CntanctDB.sqlite";
            string folderPath = ApplicationData.Current.LocalFolder.Path;
            string fullpath = Path.Combine(folderPath, dbName);

            LoadApplication(new ContactXam.App(fullpath));
        }
    }
}
