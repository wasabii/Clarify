using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [HalClass("TranscriptR4Insight")]
    [DataContract]
    public class TranscriptR4Insight :
        Insight
    {
        
        [DataMember]
        [JsonProperty("track_data")]
        public TranscriptR4TrackData[] TrackData { get; set; }

    }

}
