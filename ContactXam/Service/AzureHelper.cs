using ContactXam.Model;

using Microsoft.WindowsAzure.MobileServices;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ContactXam.Service {
    public class AzureHelper {

        static AzureHelper azureHelper = new AzureHelper();

        private IMobileServiceClient client;
        private IMobileServiceTable<Person> peopleTable;

        private AzureHelper() {

            client = new MobileServiceClient("https://xamxontacts.azurewebsites.net");
            peopleTable = client.GetTable<Person>();
        }

        public static AzureHelper Helper {
            get { return azureHelper; }
            private set { azureHelper = value; }
        }


        public async Task<ObservableCollection<Person>> getContacts() {

            try {
                IEnumerable<Person> items = await peopleTable.ToEnumerableAsync();
                return new ObservableCollection<Person>(items);
            } catch (MobileServiceInvalidOperationException mobileEx) {
                Debug.WriteLine($"Exception: {mobileEx.Message}");
            } catch (Exception ex) {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
            return null;
        }

        public async Task AddContact(Person person) {

            try {

                await peopleTable.InsertAsync(person);

            } catch (Exception ex) {

                Debug.WriteLine($"Exception: { ex.Message} ");

            }
        }

        public async Task removeContact(Person person) {

            try {

                await peopleTable.InsertAsync(person);

            } catch (Exception ex) {

                Debug.WriteLine($"Exception: { ex.Message} ");

            }
        }

        public async Task updateContact(Person person) {

            try {

                await peopleTable.UpdateAsync(person);

            } catch (Exception ex) {

                Debug.WriteLine($"Exception: { ex.Message} ");

            }
        }
    }
}
