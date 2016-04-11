using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Insights
{

    [DataContract]
    public class TranscriptTerm
    {

        [DataMember]
        [JsonProperty("type")]
        public TranscriptTermType? Type { get; set; }

        [DataMember]
        [JsonProperty("term")]
        public string Term { get; set; }

    }

}
