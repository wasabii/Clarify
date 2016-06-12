using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [Serializable]
    public class TranscriptR9Data
    {
        
        [JsonProperty("transcript")]
        public TranscriptR9Transcript Transcript { get; set; }

    }

}
