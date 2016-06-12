using System;

using Newtonsoft.Json;

namespace Clarify.Profiles
{

    [Serializable]
    public class ClassificationTrackData
    {

        [JsonProperty("acoustics")]
        public ClassificationAcoustics[] Acoustics { get; set; }

        [JsonProperty("spoken_languages")]
        public AudioLanguage[] SpokenLanguages { get; set; }

    }

}
