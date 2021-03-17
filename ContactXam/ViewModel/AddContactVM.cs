using ContactXam.Model;

using SQLite;

using System.Windows.Input;

using Xamarin.Forms;

namespace ContactXam.ViewModel {
    public class AddContactVM : ViewModelBase {
        public ICommand SaveCommand { get; set; }
        public Contact Contact { get; set; }
        public AddContactVM() {

            SaveCommand = new Command(async () => {

                Contact = new Contact();

                using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DbLocation)) {

                    sQLiteConnection.CreateTable<Contact>();
                    int row = sQLiteConnection.Insert(Contact);

                    if (row > 0) {
                        await Application.Current.MainPage.Navigation.PopAsync();
                    } else {
                        await Application.Current.MainPage.DisplayAlert("Something is wrong", "OK", "Cancel");
                    }
                }
            });
        }
    }
}
