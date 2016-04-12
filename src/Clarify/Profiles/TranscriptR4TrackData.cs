using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [DataContract]
    public class TranscriptR4TrackData
    {

        [DataMember]
        [JsonProperty("transcript")]
        public TranscriptR4Transcript Transcript { get; set; }

    }

}
