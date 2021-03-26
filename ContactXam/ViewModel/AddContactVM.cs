using ContactXam.Model;
using ContactXam.Service;

using System.Windows.Input;

using Xamarin.Forms;

namespace ContactXam.ViewModel {
    public class AddContactVM : ViewModelBase {
        public ICommand SaveCommand { get; set; }

        public Person person { get; set; }

        public AddContactVM() {

            person = new Person();

            SaveCommand = new Command(async () => {

                await DBHelper.AddContact(person.Name, person.PhoneNumber, person.Address);

                MessagingCenter.Send(this, "AddItem", person);

                var main = Application.Current.MainPage;

                await main.Navigation.PopAsync();

            });
        }
    }
}
