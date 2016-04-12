using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [DataContract]
    public class TranscriptR4Transcript
    {

        [DataMember]
        [JsonProperty("segments")]
        public TranscriptR4Segment[] Segments { get; set; }

        [DataMember]
        [JsonProperty("meta")]
        public TranscriptR4Meta Meta { get; set; }

    }

}
