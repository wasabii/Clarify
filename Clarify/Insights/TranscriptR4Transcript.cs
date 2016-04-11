using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify.Insights
{

    [DataContract]
    public class TranscriptR4Transcript
    {

        [DataMember]
        [JsonProperty("speakers")]
        public TranscriptSpeaker[] Speakers { get; set; }

        [DataMember]
        [JsonProperty("segments")]
        public TranscriptSegment[] Segments { get; set; }

        [DataMember]
        [JsonProperty("meta")]
        public TranscriptMeta Meta { get; set; }

    }

}
