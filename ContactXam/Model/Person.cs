using ContactXam.ViewModel;

using Microsoft.WindowsAzure.MobileServices;

using Newtonsoft.Json;

using SQLite;

namespace ContactXam.Model {

    [DataTable("Contact")]
    public class Person : ViewModelBase {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
