using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Clarify
{

    [Serializable]
    public class BundlePostRequest
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("media_url")]
        public Uri MediaUrl { get; set; }

        [JsonProperty("audio_channel")]
        public AudioChannel AudioChannel { get; set; }

        [JsonProperty("audio_language")]
        public AudioLanguage AudioLanguage { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("notify_url")]
        public Uri NotifyUrl { get; set; }

    }

}
