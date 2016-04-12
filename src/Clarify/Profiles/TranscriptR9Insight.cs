using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [HalClass("TranscriptR9Insight")]
    [DataContract]
    public class TranscriptR9Insight :
        Insight
    {
        
        [DataMember]
        [JsonProperty("track_data")]
        public TranscriptR9TrackData[] TrackData { get; set; }

    }

}
