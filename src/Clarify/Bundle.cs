using System;

namespace Clarify
{

    [HalClass("Bundle")]
    public class Bundle :
        HalObject
    {
        
        public Guid Id
        {
            get { return GetPropertyValue<Guid>("id"); }
        }

        public int Version
        {
            get { return GetPropertyValue<int>("version"); }
        }

        public string Name
        {
            get { return GetPropertyValue<string>("name"); }
        }

        public string ExternalId
        {
            get { return GetPropertyValue<string>("external_id"); }
        }

        public Uri NotifyUrl
        {
            get { return GetPropertyValue<Uri>("notify_url"); }
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
