using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [DataContract]
    public abstract class HalObject
    {
        
        [DataMember]
        [JsonProperty("_class")]
        public string HalClass { get; set; }

        [DataMember]
        [JsonProperty("_links")]
        public HalLinks HalLinks { get; set; }

        public HalLink SelfLink
        {
            get { return HalLinks?.Self; }
        }

        public HalLink ParentLink
        {
            get { return HalLinks?.Parent; }
        }

    }

}
