using System;

using Newtonsoft.Json;

namespace Clarify
{

    [Serializable]
    public class HalLink
    {
        
        [JsonProperty("href")]
        public string Href { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("templated")]
        public bool Templated { get; set; }

    }

}
