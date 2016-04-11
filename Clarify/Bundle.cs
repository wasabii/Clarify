using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [DataContract]
    public class Bundle
    {
        
        [DataMember]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [DataMember]
        [JsonProperty("version")]
        public int Version { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [DataMember]
        [JsonProperty("notify_url")]
        public Uri NotifyUrl { get; set; }

        [DataMember]
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [DataMember]
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

    }

}
