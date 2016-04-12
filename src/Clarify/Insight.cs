using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [DataContract]
    public class Insight :
        HalObject
    {

        [DataMember]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [DataMember]
        [JsonProperty("bundle_id")]
        public Guid BundleId { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("status")]
        public InsightStatus Status { get; set; }

        [DataMember]
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [DataMember]
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        public HalLink BundleLink
        {
            get { return HalLinks.GetLink("clarify:bundle"); }
        }

    }

}
