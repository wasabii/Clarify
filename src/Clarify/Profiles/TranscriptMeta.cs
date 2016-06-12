using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [Serializable]
    public class TranscriptMeta
    {
        
        [JsonProperty("version")]
        public int Version { get; set; }
        
        [JsonProperty("format")]
        public string Format { get; set; }

    }

}
