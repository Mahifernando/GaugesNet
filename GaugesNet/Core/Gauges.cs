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

namespace GaugesNet.Core
{
    /// <summary>
    /// Implements Gaug.es API method calls. This class cannot be inherited.
    /// </summary>
    public sealed class Gauges
    {
        private string _token = null;

        /// <summary>
        /// Gets Gaug.es API token
        /// </summary>
        public string Token { get { return _token; } }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="token">Gaug.es API token</param>
        public Gauges(string token)
        {
            if (string.IsNullOrEmpty(token)) { throw new ArgumentNullException("token required."); }
            
            this._token = token;
        }

        /// <summary>
        /// Gets user information
        /// </summary>
        /// <returns>Instance of GaugesNet.Entity.User class.</returns>
        public Entity.User Me()
        {
            string response = new Curl().Get("https://secure.gaug.es/me", _token);
            return JsonConvert.DeserializeObject<Entity.Me>(response).user;
        }

        /// <summary>
        /// Update user's first name and/or last name.
        /// </summary>
        /// <param name="first_name">User's first name</param>
        /// <param name="last_name">User's last name</param>
        /// <returns>Instance of GaugesNet.Entity.User class.</returns>
        public Entity.User UpdateMe(string first_name, string last_name)
        {
            if (string.IsNullOrEmpty(first_name) && string.IsNullOrEmpty(last_name))
            {
                throw new ArgumentNullException("first_name or last_name required");
            }

            Dictionary<string, string> data = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(first_name)) { data.Add("first_name", first_name); }
            if (!string.IsNullOrEmpty(last_name)) { data.Add("last_name", last_name); }

            string response = new Curl().Put("https://secure.gaug.es/me", _token, data);
            return JsonConvert.DeserializeObject<Entity.Me>(response).user;
        }

        /// <summary>
        /// Gets API client list.
        /// </summary>
        /// <returns>Instance of GaugesNet.Entity.Clients class.</returns>
        public Entity.Clients GetClients()
        {
            string response = new Curl().Get("https://secure.gaug.es/clients", _token);
            return JsonConvert.DeserializeObject<Entity.ApiClients>(response).Clients;
        }

        /// <summary>
        /// Create an API client.
        /// </summary>
        /// <param name="description">Short description for the key (i.e.: HipChat, Campfire, etc.)</param>
        /// <returns>Instance of GaugesNet.Entity.Client class.</returns>
        public Entity.Client CreateClient(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("description required");
            }

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("description", description);

            string response = new Curl().Post("https://secure.gaug.es/clients", _token, data);
            return JsonConvert.DeserializeObject<Entity.ApiClients>(response).Client;
        }

        /// <summary>
        /// Permanently deletes an API client key.
        /// </summary>
        /// <param name="id">API client key.</param>
        /// <returns>Instance of GaugesNet.Entity.Client class.</returns>
        public Entity.Client DeleteClient(string id)
        {
            if (string.IsNullOrEmpty(id)) { throw new ArgumentNullException("id required"); }

            string response = new Curl().Delete("https://secure.gaug.es/clients/" + id, _token);
            return JsonConvert.DeserializeObject<Entity.ApiClients>(response).Client;
        }

        /// <summary>
        /// Gets a list of gauges with recent traffic included.
        /// </summary>
        /// <returns>Instance of GaugesNet.Entity.Gauges class.</returns>
        public Entity.Gauges GetGauges()
        {
            string response = new Curl().Get("https://secure.gaug.es/gauges", _token);
            return JsonConvert.DeserializeObject<Entity.ApiGauges>(response).gauges;
        }

        /// <summary>
        /// Create a new gauge.
        /// </summary>
        /// <param name="title">The title of the gauge.</param>
        /// <param name="tz">The time zone that should be used for all date/time operations.</param>
        /// <param name="allowed_hosts">Comma or space separated list of domains to accept tracking data from.</param>
        /// <returns>Instance of GaugesNet.Entity.Gauge class.</returns>
        public Entity.Gauge CreateGauge(string title, string tz, string allowed_hosts) 
        {
            if (string.IsNullOrEmpty(title)) { throw new ArgumentNullException("title required."); }
            if (string.IsNullOrEmpty(tz)) { throw new ArgumentNullException("tz required."); }

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("title", title);
            data.Add("tz", tz);
            if (string.IsNullOrEmpty(allowed_hosts)) { data.Add("allowed_hosts", allowed_hosts); }

            string response = new Curl().Post("https://secure.gaug.es/gauges", _token, data);
            return JsonConvert.DeserializeObject<Entity.ApiGauges>(response).gauge;
        }

        /// <summary>
        /// Gets details for a gauge.
        /// </summary>
        /// <param name="id">API client key.</param>
        /// <returns>Instance of GaugesNet.Entity.Gauge class.</returns>
        public Entity.Gauge GetGauge(string id)
        {
            if (string.IsNullOrEmpty(id)) { throw new ArgumentNullException("id required."); }
            
            string response = new Curl().Get("https://secure.gaug.es/gauges/" + id, _token);
            return JsonConvert.DeserializeObject<Entity.ApiGauges>(response).gauge;
        }

        /// <summary>
        /// Updates and returns a gauge with the updates applied.
        /// </summary>
        /// <param name="id">API client key.</param>
        /// <param name="title">The title of the gauge.</param>
        /// <param name="tz">The time zone that should be used for all date/time operations.</param>
        /// <param name="allowed_hosts">Comma or space separated list of domains to accept tracking data from.</param>
        /// <returns>Instance of GaugesNet.Entity.Gauge class.</returns>
        public Entity.Gauge UpdateGauge(string id, string title, string tz, string allowed_hosts)
        {
            if (string.IsNullOrEmpty(id)) { throw new ArgumentNullException("id required."); }
            if (string.IsNullOrEmpty(title)) { throw new ArgumentNullException("title required."); }
            if (string.IsNullOrEmpty(tz)) { throw new ArgumentNullException("tz required."); }

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("id", id);
            data.Add("title", title);
            data.Add("tz", tz);
            if (string.IsNullOrEmpty(allowed_hosts)) { data.Add("allowed_hosts", allowed_hosts); }

            string response = new Curl().Put("https://secure.gaug.es/gauges/" + id, _token, data);
            return JsonConvert.DeserializeObject<Entity.ApiGauges>(response).gauge;
        }

        /// <summary>
        /// Permanently deletes a gauge.
        /// </summary>
        /// <param name="id">API client key.</param>
        /// <returns>Instance of GaugesNet.Entity.Gauge class.</returns>
        public Entity.Gauge DeleteGauge(string id)
        {
            if (string.IsNullOrEmpty(id)) { throw new ArgumentNullException("id required."); }

            string response = new Curl().Delete("https://secure.gaug.es/gauges/" + id, _token);
            return JsonConvert.DeserializeObject<Entity.ApiGauges>(response).gauge;
        }
    }
}
