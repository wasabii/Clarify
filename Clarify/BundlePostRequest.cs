using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [DataContract]
    public class BundlePostRequest
    {

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("media_url")]
        public Uri MediaUrl { get; set; }

        [DataMember]
        [JsonProperty("audio_channel")]
        public AudioChannel AudioChannel { get; set; }

        [DataMember]
        [JsonProperty("audio_language")]
        public AudioLanguage AudioLanguage { get; set; }

        [DataMember]
        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        [DataMember]
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [DataMember]
        [JsonProperty("notify_url")]
        public Uri NotifyUrl { get; set; }

    }

}
