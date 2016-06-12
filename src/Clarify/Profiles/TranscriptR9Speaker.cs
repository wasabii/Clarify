using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [Serializable]
    public class TranscriptR9Speaker
    {
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("label")]
        public string Label { get; set; }

    }

}
