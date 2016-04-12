using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [DataContract]
    public class Metadata :
        HalObject
    {

        [DataMember]
        [JsonProperty("bundle_id")]
        public Guid BundleId { get; set; }

        [DataMember]
        [JsonProperty("version")]
        public int Version { get; set; }

        [DataMember]
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [DataMember]
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [DataMember]
        [JsonProperty("data")]
        public Dictionary<string, object> Data { get; set; }

    }

}
