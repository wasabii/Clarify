using System.Collections.Generic;
using System.Runtime.Serialization;

using Clarify.Util;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Clarify
{

    [JsonDictionary]
    public abstract class HalObject :
        Dictionary<string, JToken>
    {

        readonly Dictionary<string, object> properties =
            new Dictionary<string, object>();

        /// <summary>
        /// Gets the property value of the given property name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        protected T GetPropertyValue<T>(string key)
        {
            return (T)properties.GetOrAdd(key, _ => this.ContainsKey(_) ? this[_].ToObject<T>() : default(T));
        }


        public string HalClass
        {
            get { return GetPropertyValue<string>("_class"); }
        }

        public HalLinks HalLinks
        {
            get { return GetPropertyValue<HalLinks>("_links"); }
        }

    }

}
