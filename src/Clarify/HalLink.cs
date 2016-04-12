using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Clarify
{

    [DataContract]
    public class HalLink
    {

        [DataMember]
        [JsonProperty("href")]
        public string Href { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("templated")]
        public bool Templated { get; set; }

        /// <summary>
        /// Returns a <see cref="HalLink"/> of the specified generic type from this <see cref="HalLink"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public HalLink<T> As<T>()
            where T : HalObject
        {
            return JObject.FromObject(this).ToObject<HalLink<T>>();
        }

    }

    public class HalLink<T> :
        HalLink
        where T : HalObject
    {



    }

}
