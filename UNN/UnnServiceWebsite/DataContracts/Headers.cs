using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataContracts
{
    [Serializable]
    [DataContract]
    public class Headers
    {
        [DataMember]
        public IEnumerable<int> GroupList { get; set; }

        [DataMember]
        public IEnumerable<Weekday> WeekdayList { get; set; }

        [DataMember]
        public IEnumerable<string> StartTimeList { get; set; }
    }
}
