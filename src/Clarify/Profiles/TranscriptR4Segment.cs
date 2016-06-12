using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [Serializable]
    public class TranscriptR4Segment
    {
        
        [JsonProperty("start")]
        public double Start { get; set; }
        
        [JsonProperty("dur")]
        public double Duration { get; set; }
        
        [JsonProperty("terms")]
        public TranscriptR4Term[] Terms { get; set; }
        
        [JsonProperty("language")]
        public TranscriptR4Language Language { get; set; }

    }

}
