using System;

using Newtonsoft.Json;

namespace Clarify
{

    [Serializable]
    public class BundleTrackPostRequest
    {

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("media_url")]
        public Uri MediaUrl { get; set; }

        [JsonProperty("audio_channel")]
        public AudioChannel AudioChannel { get; set; }

        [JsonProperty("audio_language")]
        public AudioLanguage AudioLanguage { get; set; }

        [JsonProperty("track")]
        public int? Index { get; set; }

        [JsonProperty("version")]
        public int? Version { get; set; }

    }

}
