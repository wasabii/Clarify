using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [DataContract]
    public class ClassificationTrackData
    {

        [DataMember]
        [JsonProperty("acoustics")]
        public ClassificationAcoustics[] Acoustics { get; set; }

        [DataMember]
        [JsonProperty("spoken_languages")]
        public AudioLanguage[] SpokenLanguages { get; set; }

    }

}
