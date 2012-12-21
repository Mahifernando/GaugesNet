﻿// ------------------------------------------------------------------------------
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

namespace GaugesNet.Entity
{
    public class Me
    {
        public User user { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public Urls urls { get; set; }
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
    }
}
