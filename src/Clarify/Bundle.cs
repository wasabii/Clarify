using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [HalClass("Bundle")]
    [Serializable]
    public class Bundle :
        HalObject
    {

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("notify_url")]
        public Uri NotifyUrl { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

    }

}
