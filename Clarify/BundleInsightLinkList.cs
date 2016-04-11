using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [DataContract]
    [JsonConverter(typeof(BundleInsightLinkListJsonConverter))]
    public class BundleInsightLinkList
    {

        [DataMember]
        public Guid BundleId { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public DateTime Updated { get; set; }

        [DataMember]
        public Dictionary<string, InsightLink> Insights { get; set; }

    }

}
