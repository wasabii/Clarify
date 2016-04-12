using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
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
