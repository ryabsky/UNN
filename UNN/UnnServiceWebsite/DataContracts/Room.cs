using System;
using System.Runtime.Serialization;

namespace DataContracts
{
    [Serializable]
    [DataContract]
    public class Room
    {
        [DataMember]
        public int RoomId { get; set; }

        [DataMember]
        public int RoomNumber { get; set; }

        [DataMember]
        public int BuildingId { get; set; }
    }
}
