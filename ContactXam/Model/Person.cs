using ContactXam.ViewModel;

using Microsoft.WindowsAzure.MobileServices;

using SQLite;

using System.Data;

namespace ContactXam.Model {
    [DataTable("People")]
    public class Person : ViewModelBase {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _Name;
        public string Name {
            get { return _Name; }
            set {
                if (_Name != value) {
                    _Name = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _PhoneNumber;
        public string PhoneNumber {
            get { return _PhoneNumber; }
            set {
                if (_PhoneNumber != value) {
                    _PhoneNumber = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _Address;
        public string Address {
            get { return _Address; }
            set {
                if (_Address != value) {
                    _Address = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
