using System;

namespace Clarify
{

    public class BundleRef :
        Ref<Bundle>
    {

        public Guid Id
        {
            get { return GetPropertyValue<Guid>("id"); }
        }

        public HalLink<Metadata> Metadata
        {
            get { return HalLinks.GetLink<Metadata>("clarify:metadata"); }
        }

        public HalLink<Tracks> Tracks
        {
            get { return HalLinks.GetLink<Tracks>("clarify:tracks"); }
        }

        public HalLink<Insights> Insights
        {
            get { return HalLinks.GetLink< Insights>("clarify:insights"); }
        }

    }

}
