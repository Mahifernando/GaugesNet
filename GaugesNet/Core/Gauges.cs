// ------------------------------------------------------------------------------
//                                                                              |
//   Copyright 2012 Mahi Fernando.                                              |
//                                                                              |
//   Licensed under the Apache License, Version 2.0 (the "License");            |
//   you may not use this file except in compliance with the License.           |
//   You may obtain a copy of the License at                                    |
//                                                                              |
//       http://www.apache.org/licenses/LICENSE-2.0                             |
//                                                                              |
//   Unless required by applicable law or agreed to in writing, software        |
//   distributed under the License is distributed on an "AS IS" BASIS,          |
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.   |
//   See the License for the specific language governing permissions and        |
//   limitations under the License.                                             |
//                                                                              |
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GaugesNet.Entity;

namespace GaugesNet.Core
{
    public class Gauges
    {
        private string _token = null;
        public string Token { get { return _token; } }

        public Gauges(string token)
        {
            this._token = token;
        }

        public User Me()
        {
            string response = new Curl().Get("https://secure.gaug.es/me", _token);
            return JsonConvert.DeserializeObject<Entity.Me>(response).user;
        }

        public User UpdateMe(string first_name, string last_name)
        {
            if (string.IsNullOrEmpty(first_name) && string.IsNullOrEmpty(last_name))
            {
                throw new NullReferenceException("first_name or last_name required");
            }

            Dictionary<string, string> data = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(first_name)) { data.Add("first_name", first_name); }
            if (!string.IsNullOrEmpty(last_name)) { data.Add("last_name", last_name); }

            string response = new Curl().Put("https://secure.gaug.es/me", _token, data);
            return JsonConvert.DeserializeObject<Entity.Me>(response).user;
        }

        public Clients Clients()
        {
            string response = new Curl().Get("https://secure.gaug.es/clients", _token);
            return JsonConvert.DeserializeObject<Entity.ApiClients>(response).Clients;
        }

        public Client CreateClient(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new NullReferenceException("description required");
            }

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("description", description);

            string response = new Curl().Post("https://secure.gaug.es/clients", _token, data);
            return JsonConvert.DeserializeObject<Entity.ApiClients>(response).Client;
        }

        public Client DeleteClient(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new NullReferenceException("id required");
            }

            string response = new Curl().Delete("https://secure.gaug.es/clients/" + id, _token);
            return JsonConvert.DeserializeObject<Entity.ApiClients>(response).Client;
        }
    }
}
