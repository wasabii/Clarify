using System;
using System.Collections.Generic;

namespace Clarify
{

    public class Metadata :
        HalObject
    {

        public Guid BundleId
        {
            get { return GetPropertyValue<Guid>("bundle_id"); }
        }

        public int Version
        {
            get { return GetPropertyValue<int>("version"); }
        }

        public DateTime Created
        {
            get { return GetPropertyValue<DateTime>("created"); }
        }

        public DateTime Updated
        {
            get { return GetPropertyValue<DateTime>("updated"); }
        }

        public Dictionary<string, object> Data
        {
            get { return GetPropertyValue<Dictionary<string, object>>("data"); }
        }

    }

}
