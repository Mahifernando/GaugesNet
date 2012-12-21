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

namespace GaugesNet.Entity
{
    public class ApiGauges
    {
        public Gauges gauges { get; set; }
        public Gauge gauge { get; set; }
    }

    public class Gauges: List<Gauge>
    {

    }

    public class Gauge
    {
        public string id { get; set; }
        public string title { get; set; }
        public string tz { get; set; }
        public string now_in_zone { get; set; }
        public bool enabled { get; set; }
        public string creator_id { get; set; }
        public Urls urls { get; set; }
        public AllTime all_time { get; set; }
        public Today today { get; set; }
        public Yesterday yesterday { get; set; }
        public RecentHours recent_hours { get; set; }
        public RecentMonths recent_months { get; set; }
        public RecentDays recent_days { get; set; }
    }

    public class AllTime: GaugeStat 
    {
 
    }

    public class Today : GaugeStat
    {
        public DateTime date { get; set; }
    }

    public class Yesterday: Today
    {
        
    }

    public class RecentHours : List<ByHours>
    {
        
    }

    public class ByHours : GaugeStat
    {
        public string hour { get; set; }
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
        public string views { get; set; }
        public string people { get; set; }
    }
}
