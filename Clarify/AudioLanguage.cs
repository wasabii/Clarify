using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Clarify
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AudioLanguage
    {

        [EnumMember(Value = "")]
        Unknown,

        [EnumMember(Value = "en-US")]
        en_US,

        [EnumMember(Value = "en-UK")]
        en_UK,

    }

}
