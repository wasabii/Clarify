using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Clarify.Insights
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TranscriptTermType
    {

        [EnumMember(Value = "mark")]
        Mark,

    }

}
