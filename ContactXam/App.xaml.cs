
using ContactXam.View;

using Xamarin.Forms;

namespace ContactXam {
    public partial class App : Application {

        public static string DbLocation = string.Empty;
        string Key = "NDEzMDYzQDMxMzgyZTM0MmUzMGM2c3VUTFpEbVg1RkZMakh1RGxFdWw5dkYxL3oxdS9iY3JCVUZucG4xVGs9";
        public App() {

            InitializeComponent();

            MainPage = new MainPage();
        }

        public App(string databaseLocation) {

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Key);
            InitializeComponent();

            MainPage = new NavigationPage(new ContactsPage());

            databaseLocation = DbLocation;
        }


        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
