using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [DataContract]
    public class TranscriptR4Term
    {

        [DataMember]
        [JsonProperty("start")]
        public double Start { get; set; }

        [DataMember]
        [JsonProperty("dur")]
        public double Duration { get; set; }

        [DataMember]
        [JsonProperty("term")]
        public string Term { get; set; }

    }

}
