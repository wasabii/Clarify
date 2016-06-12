using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [Serializable]
    public class TranscriptR9Transcript
    {
        
        [JsonProperty("speakers")]
        public TranscriptR9Speaker[] Speakers { get; set; }
        
        [JsonProperty("segments")]
        public TranscriptR9Segment[] Segments { get; set; }
        
        [JsonProperty("meta")]
        public TranscriptR9Meta Meta { get; set; }

    }

}
