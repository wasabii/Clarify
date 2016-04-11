using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Insights
{

    [DataContract]
    public class TranscriptR4InsightData
    {

        [DataMember]
        [JsonProperty("transcript")]
        public TranscriptR4Transcript Transcript { get; set; }

    }

}
