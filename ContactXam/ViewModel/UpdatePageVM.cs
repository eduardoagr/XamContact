using ContactXam.Model;
using ContactXam.Service;

using System.Windows.Input;

using Xamarin.Forms;

namespace ContactXam.ViewModel {
    public class UpdatePageVM : ViewModelBase {

        public Person person { get; set; }

        public ICommand UpdateCommand { get; set; }

        public ContactsVM contactsVM { get; set; }

        public UpdatePageVM() {

            person = new Person();

            UpdateCommand = new Command(async () => {

                await DBHelper.updateContact(person.Id);

                contactsVM = new ContactsVM();

                var main = Application.Current.MainPage;

                await main.Navigation.PopAsync();
            });
        }
    }
}
