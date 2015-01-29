using System;
using System.Runtime.Serialization;

namespace DataContracts
{
    [Serializable]
    [DataContract]
    public class Group
    {
        [DataMember]
        public int GroupId { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public Direction Direction { get; set; }
    }
}
