using System.Collections.Generic;
using Newtonsoft.Json;

namespace GaugesNet.Entity
{
    public class ApiClients
    {
        [JsonProperty("client")]
        public Client Client { get; set; }

        [JsonProperty("clients")]
        public Clients Clients { get; set; }

    }

    public class Client
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("urls")]
        public Urls Urls { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }

    public class Clients : List<Client>
    {

    }
}
