using ContactXam.Model;
using ContactXam.View;

using SQLite;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;

namespace ContactXam.ViewModel {
        public class ContactsVM : ViewModelBase {

            public ICommand AddContact { get; set; }

            private ObservableCollection<Contact> _Contacts;
            public ObservableCollection<Contact> Contacts {
                get { return _Contacts; }
                set {
                    if (_Contacts != value) {
                        _Contacts = value;
                        RaisePropertyChanged();
                    }
                }
            }
            public ContactsVM() {

                Contacts = new ObservableCollection<Contact>();

                using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DbLocation)) {

                    sQLiteConnection.CreateTable<Contact>();
                    List<Contact> contacts = sQLiteConnection.Table<Contact>().ToList();
                    if (contacts.Count > 0) {
                        foreach (var item in contacts) {

                            Contacts.Add(item);
                        }
                    }
                }
                AddContact = new Command(async () => {
                    await Application.Current.MainPage.Navigation.PushAsync(new AddContact());
                });
            }
        }
    }
   