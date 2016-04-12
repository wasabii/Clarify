using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [DataContract]
    public class TranscriptR9Term
    {

        [DataMember]
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public TranscriptR9TermType? Type { get; set; }

        [DataMember]
        [JsonProperty("term")]
        public string Term { get; set; }

    }

}
