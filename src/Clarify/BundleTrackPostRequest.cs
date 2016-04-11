using System;
using System.Runtime.Serialization;

namespace Clarify
{

    [DataContract]
    public class BundleTrackPostRequest
    {

        [DataMember]
        public string Label { get; set; }

        [DataMember]
        public Uri MediaUrl { get; set; }

        [DataMember]
        public AudioChannel AudioChannel { get; set; }

        [DataMember]
        public AudioLanguage AudioLanguage { get; set; }

        [DataMember]
        public int? Index { get; set; }

        [DataMember]
        public int? Version { get; set; }
        
    }

}
