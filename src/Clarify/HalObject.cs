using System;

using Newtonsoft.Json;

namespace Clarify
{

    [Serializable]
    public abstract class HalObject
    {
        
        [JsonProperty("_class")]
        public string HalClass { get; set; }
        
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
