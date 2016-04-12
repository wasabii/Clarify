using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [DataContract]
    public class TranscriptR9Data
    {

        [DataMember]
        [JsonProperty("transcript")]
        public TranscriptR9Transcript Transcript { get; set; }

    }

}
