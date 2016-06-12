using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [Serializable]
    public class TranscriptR4Term
    {
        
        [JsonProperty("start")]
        public double Start { get; set; }
        
        [JsonProperty("dur")]
        public double Duration { get; set; }
        
        [JsonProperty("term")]
        public string Term { get; set; }

    }

}
