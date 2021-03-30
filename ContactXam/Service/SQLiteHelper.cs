namespace ContactXam.Service {
    //    public class SQLiteHelper {

    //        static SQLiteAsyncConnection db;
    //        static async Task init() {

    //            if (db != null) {
    //                return;
    //            }

    //            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyContacts.db");

    //            db = new SQLiteAsyncConnection(databasePath);

    //            await db.CreateTableAsync<Person>();
    //        }

    //        public static async Task AddContact(Person person) {

    //            await init();


    //            var id = await db.InsertAsync(person);
    //        }
    //        public static async Task removeContact(Person person) {

    //            await init();

    //            await db.DeleteAsync<Person>(person);
    //        }

    //        public static async Task updateContact(Person person) {

    //            await init();

    //            await db.UpdateAsync(person);
    //        }
    //        public static async Task<List<Person>> getContacts() {

    //            await init();

    //            var personList = await db.Table<Person>().ToListAsync();
    //            return personList;
    //        }
    //    }
    //}
}
