

using ContactXam.Model;
using ContactXam.Service;
using ContactXam.View;

using Plugin.Messaging;

using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;

using Application = Xamarin.Forms.Application;

namespace ContactXam.ViewModel {
    public class ContactsVM : ViewModelBase {

        public ICommand AddContact { get; set; }

        public ObservableCollection<Person> Contacts { get; set; } = new ObservableCollection<Person>();
        private Person _SelectedItem;
        public Person SelectedItem {
            get { return _SelectedItem; }
            set {
                if (_SelectedItem != value) {
                    _SelectedItem = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ICommand SelectionItemCommand { get; set; }


        public ContactsVM() {
            Populatedatabase();

            AddContact = new Command(async () => {
                var mainPage = Application.Current.MainPage;
                await mainPage.Navigation.PushAsync(new AddContact());
            });

            MessagingCenter.Subscribe<AddContactVM, Person>(this, "AddItem", (obj, item) => {
                Person newItem = item;

                Contacts.Add(newItem);
            });

            SelectionItemCommand = new Command(async () => {

                if (SelectedItem != null) {
                    var mainPage = Application.Current.MainPage;
                    string action = await mainPage.DisplayActionSheet(
                        "What do you want to do?:", "Cancel", "Delete", "Call", "Update", string.Empty);

                    switch (action) {
                        case "Call":

                            var status = await Xamarin.Essentials.
                            Permissions.RequestAsync<Xamarin.Essentials.Permissions.Phone>();

                            if (status != Xamarin.Essentials.PermissionStatus.Granted) {
                                status = await Xamarin.Essentials.
                                Permissions.RequestAsync<Xamarin.Essentials.Permissions.Phone>();
                            }

                            var phoneDialer = CrossMessaging.Current.PhoneDialer;
                            if (phoneDialer.CanMakePhoneCall)
                                phoneDialer.MakePhoneCall(SelectedItem.PhoneNumber);
                            break;
                        case "Update":
                            await mainPage.Navigation.PushAsync(new UpdatePage(SelectedItem));
                            break;
                        case "Delete":
                            Contacts.Remove(SelectedItem);
                            await AzureHelper.Helper.removeContact(SelectedItem);
                            break;
                        default:
                            break;
                    }
                    SelectedItem = null;
                }
            });

        }




        public async void Populatedatabase() {
            var peopleList = await AzureHelper.Helper.getContacts();
            Contacts.Clear();
            foreach (var item in peopleList) {
                Contacts.Add(item);
            }

        }
    }
}
