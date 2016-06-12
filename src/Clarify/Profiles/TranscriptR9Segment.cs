using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [Serializable]
    public class TranscriptR9Segment
    {
        
        [JsonProperty("speaker")]
        public string Speaker { get; set; }
        
        [JsonProperty("terms")]
        public TranscriptR9Term[] Terms { get; set; }

    }

}
