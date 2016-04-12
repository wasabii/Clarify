﻿using System;

namespace Clarify
{

    public class Insight :
        HalObject
    {

        public Guid Id
        {
            get { return GetPropertyValue<Guid>("id"); }
        }

        public Guid BundleId
        {
            get { return GetPropertyValue<Guid>("bundle_id"); }
        }

        public string Name
        {
            get { return GetPropertyValue<string>("name"); }
        }

        public InsightStatus Status
        {
            get { return GetPropertyValue<InsightStatus>("status"); }
        }

        public DateTime Created
        {
            get { return GetPropertyValue<DateTime>("created"); }
        }

        public DateTime Updated
        {
            get { return GetPropertyValue<DateTime>("updated"); }
        }

    }

}
