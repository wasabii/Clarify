using System;
using System.Runtime.Serialization;

namespace Clarify
{

    [Serializable]
    public class BundlePutRequest
    {
        
        public string Name { get; set; }
        
        public string ExternalId { get; set; }
        
        public Uri NotifyUrl { get; set; }

        public int? Version { get; set; }

    }

}
