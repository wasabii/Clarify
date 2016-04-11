using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Clarify
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AudioChannel
    {

        [EnumMember(Value = "")]
        Unknown,

        [EnumMember(Value = "left")]
        Left,

        [EnumMember(Value = "right")]
        Right,

    }

}
