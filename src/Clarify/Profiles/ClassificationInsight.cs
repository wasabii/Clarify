using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [HalClass("ClassificationInsight")]
    [Serializable]
    public class ClassificationInsight :
        Insight
    {

        [JsonProperty("track_data")]
        public ClassificationTrackData[] TrackData { get; set; }

    }

}
