using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Insights
{

    [DataContract]
    public class TranscriptSpeaker
    {

        [DataMember]
        [JsonProperty("id")]
        public string Id { get; set; }

        [DataMember]
        [JsonProperty("label")]
        public string Label { get; set; }

    }

}
