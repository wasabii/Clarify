using System;
using System.Collections.Generic;
using System.Linq;

namespace Clarify
{

    [HalClass("Insights")]
    public class Insights :
        HalObject
    {

        readonly Lazy<Dictionary<string, HalLink>> insights;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Insights()
        {
            insights = new Lazy<Dictionary<string, HalLink>>(() => HalLinks
                .Where(i => i.Key.StartsWith("insight:"))
                .ToDictionary(i => i.Key, i => HalLinks.GetLink(i.Key)));
        }

        public Guid BundleId
        {
            get { return GetPropertyValue<Guid>("bundle_id"); }
        }

        public DateTime Created
        {
            get { return GetPropertyValue<DateTime>("created"); }
        }

        public DateTime Updated
        {
            get { return GetPropertyValue<DateTime>("updated"); }
        }

        public IDictionary<string, HalLink> InsightLinks
        {
            get { return insights.Value; }
        }

    }

}
