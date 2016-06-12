using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [HalClass("TranscriptR4Insight")]
    [Serializable]
    public class TranscriptR4Insight :
        Insight
    {
        
        [JsonProperty("track_data")]
        public TranscriptR4TrackData[] TrackData { get; set; }

    }

}
