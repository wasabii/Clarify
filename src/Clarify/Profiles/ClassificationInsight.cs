using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [HalClass("ClassificationInsight")]
    [DataContract]
    public class ClassificationInsight :
        Insight
    {
        
        [DataMember]
        [JsonProperty("track_data")]
        public ClassificationTrackData[] TrackData { get; set; }

    }

}
