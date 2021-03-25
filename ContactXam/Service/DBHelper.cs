using ContactXam.Model;

using SQLite;

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactXam.Service {
    public class DBHelper {

        static SQLiteAsyncConnection db;
        static async Task init() {

            if (db != null) {
                return;
            }

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyContacts.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Person>();
        }

        public static async Task AddContact(string name, string phoneNumber, string address) {

            await init();

            Person person = new Person() {
                Name = name,
                PhoneNumber = phoneNumber,
                Address = address
            };

            var id = await db.InsertAsync(person);
        }
        public static async Task removeContact(int id) {

            await init();

            await db.DeleteAsync<Person>(id);
        }

        public static async Task updateContact(int id) {

            await init();

            await db.DeleteAsync<Person>(id);
        }
        public static async Task<List<Person>> getContacts() {

            await init();

            var personList = await db.Table<Person>().ToListAsync();
            return personList;
        }
    }
}
