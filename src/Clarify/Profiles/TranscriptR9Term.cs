using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [Serializable]
    public class TranscriptR9Term
    {
        
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public TranscriptR9TermType? Type { get; set; }
        
        [JsonProperty("term")]
        public string Term { get; set; }

    }

}
