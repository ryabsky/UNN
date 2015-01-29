using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataContracts
{
    [Serializable]
    [DataContract]
    public class Class
    {
        [DataMember]
        public int ClassAssignmentId { get; set; }

        [DataMember]
        public Room Room { get; set; }

        [DataMember]
        public string StartTime { get; set; }

        [DataMember]
        public Weekday Weekday { get; set; }

        [DataMember]
        public Teacher Teacher { get; set; }

        [DataMember]
        public string ClassName { get; set; }

        [DataMember]
        public bool IsLecture { get; set; }

        [DataMember]
        public bool? IsLowerWeek { get; set; }

        [DataMember]
        public IEnumerable<Group> Groups { get; set; }
    }
}
