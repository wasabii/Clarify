using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Clarify
{

    [Serializable]
    public class Metadata :
        HalObject
    {
        
        [JsonProperty("bundle_id")]
        public Guid BundleId { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, object> Data { get; set; }

    }

}
