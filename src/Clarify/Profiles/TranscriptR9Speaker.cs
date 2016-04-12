using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [DataContract]
    public class TranscriptR9Speaker
    {

        [DataMember]
        [JsonProperty("id")]
        public string Id { get; set; }

        [DataMember]
        [JsonProperty("label")]
        public string Label { get; set; }

    }

}
