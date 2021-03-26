using ContactXam.Model;
using ContactXam.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactXam.View {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage {

        public UpdatePageVM VM { get; set; }

        public UpdatePage() {
            InitializeComponent();
        }

        public UpdatePage(Person person) {
            InitializeComponent();

            VM = new UpdatePageVM {
                person = person
            };
            BindingContext = VM;
        }
    }
}