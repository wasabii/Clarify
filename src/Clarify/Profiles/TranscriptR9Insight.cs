using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [HalClass("TranscriptR9Insight")]
    [Serializable]
    public class TranscriptR9Insight :
        Insight
    {
        
        [JsonProperty("track_data")]
        public TranscriptR9TrackData[] TrackData { get; set; }

    }

}
