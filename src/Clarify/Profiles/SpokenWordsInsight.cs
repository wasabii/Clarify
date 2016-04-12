using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [HalClass("SpokenWordsInsight")]
    [DataContract]
    public class SpokenWordsInsight :
        Insight
    {
        
        [DataMember]
        [JsonProperty("track_data")]
        public SpokenWordsTrackData[] TrackData { get; set; }

    }

}
