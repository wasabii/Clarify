using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Clarify
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum InsightStatus
    {

        [EnumMember(Value = "ready")]
        Ready,

        [EnumMember(Value = "queued")]
        Queued,

        [EnumMember(Value = "processing")]
        Processing,

        [EnumMember(Value = "error")]
        Error,

    }

}
