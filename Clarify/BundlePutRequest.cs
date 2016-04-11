using System;
using System.Runtime.Serialization;

namespace Clarify
{

    [DataContract]
    public class BundlePutRequest
    {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ExternalId { get; set; }

        [DataMember]
        public Uri NotifyUrl { get; set; }

        [DataMember]
        public int? Version { get; set; }

    }

}
