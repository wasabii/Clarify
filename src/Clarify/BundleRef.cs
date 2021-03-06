﻿using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [Serializable]
    public class BundleRef :
        Ref<Bundle>
    {
        
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public HalLink Metadata
        {
            get { return HalLinks.GetLink("clarify:metadata"); }
        }

        public HalLink Tracks
        {
            get { return HalLinks.GetLink("clarify:tracks"); }
        }

        public HalLink Insights
        {
            get { return HalLinks.GetLink("clarify:insights"); }
        }

    }

}
