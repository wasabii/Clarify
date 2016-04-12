using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [DataContract]
    public class TranscriptR9Segment
    {

        [DataMember]
        [JsonProperty("speaker")]
        public string Speaker { get; set; }

        [DataMember]
        [JsonProperty("terms")]
        public TranscriptR9Term[] Terms { get; set; }

    }

}
