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

namespace GaugesNet.Entity
{
    public class ApiGauges
    {
        [JsonProperty("gauges")]
        public Gauges Gauges { get; set; }

        [JsonProperty("gauge")]
        public Gauge Gauge { get; set; }
    }

    public class Gauges: List<Gauge>
    {

    }

    public class Gauge
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("tz")]
        public string TimeZone { get; set; }

        [JsonProperty("now_in_zone")]
        public string NowInZone { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("creator_id")]
        public string CreatorId { get; set; }

        [JsonProperty("urls")]
        public Urls Urls { get; set; }

        [JsonProperty("all_time")]
        public AllTime AllTime { get; set; }

        [JsonProperty("today")]
        public Today Today { get; set; }

        [JsonProperty("yesterday")]
        public Yesterday Yesterday { get; set; }

        [JsonProperty("recent_hours")]
        public RecentHours RecentHours { get; set; }

        [JsonProperty("recent_months")]
        public RecentMonths RecentMonths { get; set; }

        [JsonProperty("recent_days")]
        public RecentDays RecentDays { get; set; }
    }

    public class AllTime: GaugeStat 
    {
 
    }

    public class Today : GaugeStat
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }

    public class Yesterday: Today
    {
        
    }

    public class RecentHours : List<ByHours>
    {
        
    }

    public class ByHours : GaugeStat
    {
        [JsonProperty("hour")]
        public string Hour { get; set; }
    }

    public class RecentMonths : List<ByMonth>
    {
    }

    public class ByMonth : Today
    {
    }

    public class RecentDays : List<ByDays>
    { }

    public class ByDays : Today
    {
    }

    public abstract class GaugeStat
    {
        [JsonProperty("views")]
        public string Views { get; set; }

        [JsonProperty("people")]
        public string People { get; set; }
    }
}
