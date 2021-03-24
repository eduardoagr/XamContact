
using Syncfusion.ListView.XForms.UWP;

namespace ContactXam.UWP {
    public sealed partial class MainPage {
        public MainPage() {
            InitializeComponent();

            SfListViewRenderer.Init();
            LoadApplication(new ContactXam.App());
        }
    }
}
