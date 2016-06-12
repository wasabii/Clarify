using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [Serializable]
    public class TranscriptR4TrackData
    {
        
        [JsonProperty("transcript")]
        public TranscriptR4Transcript Transcript { get; set; }

    }

}
