using System;

using Newtonsoft.Json;

namespace Clarify
{

    [Serializable]
    public class Track :
        HalObject
    {

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("track")]
        public int Index { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("media_url")]
        public Uri MediaUrl { get; set; }

        [JsonProperty("audio_channel")]
        public AudioChannel AudioChannel { get; set; }

        [JsonProperty("audio_language")]
        public AudioLanguage AudioLanguage { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("status")]
        public TrackStatus Status { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [JsonProperty("media_size")]
        public int MediaSize { get; set; }

        [JsonProperty("duration")]
        public double Duration { get; set; }

        [JsonProperty("fetch_response_code")]
        public int FetchResponseCode { get; set; }

        [JsonProperty("fetch_response_message")]
        public string FetchResponseMessage { get; set; }

        [JsonProperty("media_code")]
        public int MediaCode { get; set; }

        [JsonProperty("media_message")]
        public string MediaMessage { get; set; }

    }

}
