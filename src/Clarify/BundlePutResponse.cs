using System;

using Newtonsoft.Json;

namespace Clarify
{

    public class BundlePutResponse
    {

        [JsonProperty("id")]
        public Guid Id { get; set; }

    }

}
