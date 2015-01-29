using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataContracts
{
    [Serializable]
    [DataContract]
    public class Timesheet
    {
        [DataMember]
        public IEnumerable<Class> Classes { get; set; }
        
        [DataMember]
        public Headers Headers { get; set; }
    }
}
