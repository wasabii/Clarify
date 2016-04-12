using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [HalClass("Insights")]
    [DataContract]
    public class Insights :
        HalObject
    {

        [DataMember]
        [JsonProperty("bundle_id")]
        public Guid BundleId { get; set; }

        [DataMember]
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [DataMember]
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

    }

}
