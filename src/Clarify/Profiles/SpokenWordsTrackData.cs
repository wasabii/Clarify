using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [Serializable]
    public class SpokenWordsTrackData
    {

        [JsonProperty("spoken_duration")]
        public double SpokenDuration { get; set; }

        [JsonProperty("word_count")]
        public int WordCount { get; set; }

        [JsonProperty("spoken_duration_percent")]
        public double SpokenDurationPercent { get; set; }

    }

}
