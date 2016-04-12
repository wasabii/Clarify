using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [DataContract]
    public class HalLink
    {

        [DataMember]
        [JsonProperty("href")]
        public string Href { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("templated")]
        public bool Templated { get; set; }

    }

}
