using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Clarify.Util;

using Newtonsoft.Json;

namespace Clarify
{

    [Serializable]
    [JsonConverter(typeof(HalLinksJsonConverter))]
    [KnownType(typeof(HalLink))]
    public class HalLinks :
        Dictionary<string, object>
    {

        public HalLink Self
        {
            get { return GetLink("self"); }
        }

        public HalLink Parent
        {
            get { return GetLink("parent"); }
        }

        public HalLink[] Curies
        {
            get { return GetLinkArray("curies"); }
        }

        public HalLink GetLink(string name)
        {
            return (HalLink)this.GetOrDefault(name);
        }

        public HalLink[] GetLinkArray(string name)
        {
            return (HalLink[])this.GetOrDefault(name);
        }

    }

}
