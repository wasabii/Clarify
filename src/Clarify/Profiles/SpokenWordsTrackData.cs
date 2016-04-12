using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [DataContract]
    public class SpokenWordsTrackData
    {

        [DataMember]
        [JsonProperty("spoken_duration")]
        public double SpokenDuration { get; set; }

        [DataMember]
        [JsonProperty("word_count")]
        public int WordCount { get; set; }

        [DataMember]
        [JsonProperty("spoken_duration_percent")]
        public double SpokenDurationPercent { get; set; }

    }

}
