using System;

using Newtonsoft.Json;

namespace Clarify
{

    public class BundlePostResponse
    {

        [JsonProperty("id")]
        public Guid Id { get; set; }

    }

}
