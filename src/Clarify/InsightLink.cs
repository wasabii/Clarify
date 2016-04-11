using System;

using Newtonsoft.Json;

namespace Clarify
{

    public class InsightLink
    {

        [JsonProperty("href")]
        public Uri Href { get; set; }

    }

}
