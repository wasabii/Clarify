using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [Serializable]
    public class TranscriptR4Transcript
    {
        
        [JsonProperty("segments")]
        public TranscriptR4Segment[] Segments { get; set; }
        
        [JsonProperty("meta")]
        public TranscriptR4Meta Meta { get; set; }

    }

}
