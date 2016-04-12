using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [DataContract]
    public class BundleTrackPostRequest
    {

        [DataMember]
        [JsonProperty("label")]
        public string Label { get; set; }

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
        [JsonProperty("track")]
        public int? Index { get; set; }

        [DataMember]
        [JsonProperty("version")]
        public int? Version { get; set; }
        
    }

}
