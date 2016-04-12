using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [DataContract]
    public class TranscriptR9Transcript
    {

        [DataMember]
        [JsonProperty("speakers")]
        public TranscriptR9Speaker[] Speakers { get; set; }

        [DataMember]
        [JsonProperty("segments")]
        public TranscriptR9Segment[] Segments { get; set; }

        [DataMember]
        [JsonProperty("meta")]
        public TranscriptR9Meta Meta { get; set; }

    }

}
