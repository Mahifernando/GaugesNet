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

using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace GaugesNet.Core
{
    internal sealed class Curl
    {
        private HttpWebRequest _request = null;

        private void GetCredentials()
        {
            _request.Credentials = CredentialCache.DefaultCredentials;
            _request.Proxy.Credentials = CredentialCache.DefaultCredentials;
        }

        private string GetResponse(HttpWebRequest request)
        {
            StringBuilder output = new StringBuilder();
            using (StreamReader stream = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                char[] c = null;

                while (!stream.EndOfStream)
                {
                    c = new char[100];
                    stream.ReadBlock(c, 0, c.Length);
                    output.Append(c);
                }
            }
            return output.ToString();
        }

        public string Get(string url, string token)
        {
            _request = (HttpWebRequest)WebRequest.Create(url);
            _request.Headers["X-Gauges-Token"] = token;
            _request.Method = "GET";
            GetCredentials();

            return GetResponse(_request);
        }

        public string Post(string url, string token, Dictionary<string, string> data) 
        {
            StringBuilder putDataBulder = new StringBuilder();
            foreach (KeyValuePair<string, string> item in data)
            {
                putDataBulder.Append(item.Key + "=" + item.Value + "&");
            }

            byte[] putDataArray = Encoding.UTF8.GetBytes(putDataBulder.ToString().TrimEnd('&'));

            _request = (HttpWebRequest)WebRequest.Create(url);
            _request.Headers["X-Gauges-Token"] = token;
            _request.Method = "POST";
            _request.ContentType = "application/x-www-form-urlencoded";
            _request.ContentLength = putDataArray.Length;
            GetCredentials();

            using (Stream requestStream = _request.GetRequestStream())
            {
                requestStream.Write(putDataArray, 0, putDataArray.Length);
            }

            return GetResponse(_request);
        }

        public string Put(string url, string token, Dictionary<string,string> data) 
        {
            StringBuilder putDataBulder = new StringBuilder();
            foreach (KeyValuePair<string,string> item in data)
            {
                putDataBulder.Append(item.Key + "=" + item.Value + "&");
            }

            byte[] putDataArray = Encoding.UTF8.GetBytes(putDataBulder.ToString().TrimEnd('&'));

            _request = (HttpWebRequest)WebRequest.Create(url);
            _request.Headers["X-Gauges-Token"] = token;
            _request.Method = "PUT";
            _request.ContentType = "application/x-www-form-urlencoded";
            _request.ContentLength = putDataArray.Length;
            GetCredentials();

            using (Stream requestStream = _request.GetRequestStream())
            {
                requestStream.Write(putDataArray, 0, putDataArray.Length);
            }
            
            return GetResponse(_request);
        }

        public string Delete(string url, string token) 
        {
            _request = (HttpWebRequest)WebRequest.Create(url);
            _request.Headers["X-Gauges-Token"] = token;
            _request.Method = "DELETE";
            GetCredentials();
            
            return GetResponse(_request);
        }
    }
}
