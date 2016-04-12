using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Clarify.Profiles
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TranscriptR4Language
    {

        [EnumMember(Value = "en")]
        En,

    }

}
