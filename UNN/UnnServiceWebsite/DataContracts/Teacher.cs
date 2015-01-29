using System;
using System.Runtime.Serialization;

namespace DataContracts
{
    [Serializable]
    [DataContract]
    public class Teacher
    {
        [DataMember]
        public int TeacherId { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FirstName { get; set; }
    }
}
