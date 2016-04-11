using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Insights
{

    [DataContract]
    public class TranscriptSegment
    {

        [DataMember]
        [JsonProperty("speaker")]
        public string Speaker { get; set; }

        [DataMember]
        [JsonProperty("terms")]
        public TranscriptTerm[] Terms { get; set; }

    }

}
