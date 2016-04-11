using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Insights
{

    [DataContract]
    public class TranscriptMeta
    {

        [DataMember]
        [JsonProperty("version")]
        public int Version { get; set; }

        [DataMember]
        [JsonProperty("format")]
        public string Format { get; set; }

    }

}
