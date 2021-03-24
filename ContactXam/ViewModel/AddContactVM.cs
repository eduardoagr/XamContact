using ContactXam.Model;
using ContactXam.Service;

using System.Windows.Input;

using Xamarin.Forms;

namespace ContactXam.ViewModel {
    public class AddContactVM : ViewModelBase {
        public ICommand SaveCommand { get; set; }
        public Person Contact { get; set; }
        public AddContactVM() {

            Contact = new Person();

            SaveCommand = new Command(async () => {

                await DBHelper.AddContact(Contact.Name, Contact.PhoneNumber, Contact.Address);

                var main = Application.Current.MainPage;
                await main.Navigation.PopAsync();

            });
        }
    }
}
