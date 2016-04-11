using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [DataContract]
    public class BundleTracks
    {

        [DataMember]
        [JsonProperty("bundle_id")]
        public string BundleId { get; set; }

        [DataMember]
        [JsonProperty("version")]
        public int Version { get; set; }

        [DataMember]
        [JsonProperty("status")]
        public TrackStatus Status { get; set; }

        [DataMember]
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [DataMember]
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [DataMember]
        [JsonProperty("tracks")]
        public Track[] Tracks { get; set; }

    }

}
