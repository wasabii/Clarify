using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [DataContract]
    public class Track
    {

        [DataMember]
        [JsonProperty("id")]
        public string Id { get; set; }

        [DataMember]
        [JsonProperty("track")]
        public int Index { get; set; }

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
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [DataMember]
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [DataMember]
        [JsonProperty("status")]
        public TrackStatus Status { get; set; }

        [DataMember]
        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [DataMember]
        [JsonProperty("media_size")]
        public int MediaSize { get; set; }

        [DataMember]
        [JsonProperty("duration")]
        public double Duration { get; set; }

        [DataMember]
        [JsonProperty("fetch_response_code")]
        public int FetchResponseCode { get; set; }

        [DataMember]
        [JsonProperty("fetch_response_message")]
        public string FetchResponseMessage { get; set; }

        [DataMember]
        [JsonProperty("media_code")]
        public int MediaCode { get; set; }

        [DataMember]
        [JsonProperty("media_message")]
        public string MediaMessage { get; set; }

    }

}
