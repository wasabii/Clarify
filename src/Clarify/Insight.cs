using System;

using Newtonsoft.Json;

namespace Clarify
{

    [Serializable]
    public class Insight :
        HalObject
    {

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("bundle_id")]
        public Guid BundleId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public InsightStatus Status { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        public HalLink BundleLink
        {
            get { return HalLinks.GetLink("clarify:bundle"); }
        }

    }

}
