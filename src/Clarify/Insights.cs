using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [HalClass("Insights")]
    [Serializable]
    public class Insights :
        HalObject
    {
        
        [JsonProperty("bundle_id")]
        public Guid BundleId { get; set; }
        
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

    }

}
