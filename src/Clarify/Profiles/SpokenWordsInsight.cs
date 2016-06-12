using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [HalClass("SpokenWordsInsight")]
    [Serializable]
    public class SpokenWordsInsight :
        Insight
    {
        
        [JsonProperty("track_data")]
        public SpokenWordsTrackData[] TrackData { get; set; }

    }

}
