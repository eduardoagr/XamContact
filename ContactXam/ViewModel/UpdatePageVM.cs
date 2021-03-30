using ContactXam.Model;
using ContactXam.Service;

using System.Windows.Input;

using Xamarin.Forms;

namespace ContactXam.ViewModel {
    public class UpdatePageVM : ViewModelBase {

        public Person person { get; set; }

        public ICommand UpdateCommand { get; set; }

        public UpdatePageVM() {

            UpdateCommand = new Command(async () => {

                await AzureHelper.Helper.updateContact(person);

                var main = Application.Current.MainPage;

                await main.Navigation.PopAsync();
            });
        }
    }
}
