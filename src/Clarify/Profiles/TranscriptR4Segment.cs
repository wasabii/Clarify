using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [DataContract]
    public class TranscriptR4Segment
    {

        [DataMember]
        [JsonProperty("start")]
        public double Start { get; set; }

        [DataMember]
        [JsonProperty("dur")]
        public double Duration { get; set; }

        [DataMember]
        [JsonProperty("terms")]
        public TranscriptR4Term[] Terms { get; set; }

        [DataMember]
        [JsonProperty("language")]
        public TranscriptR4Language Language { get; set; }

    }

}
