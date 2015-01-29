using System;
using System.Runtime.Serialization;

namespace DataContracts
{
    [Serializable]
    [DataContract]
    public class Building
    {
        [DataMember]
        public int BuildingId { get; set; }

        [DataMember]
        public string BuildingName { get; set; }
    }
}
