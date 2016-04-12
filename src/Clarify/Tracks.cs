using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [HalClass("Tracks")]
    [DataContract]
    public class Tracks :
        HalObject,
        IEnumerable<Track>
    {

        [DataMember]
        [JsonProperty("bundle_id")]
        public Guid BundleId { get; set; }

        [DataMember]
        [JsonProperty("version")]
        public int Version { get; set; }

        [DataMember]
        [JsonProperty("status")]
        public TrackStatus Status { get; set; }

        [DataMember]
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [DataMember]
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [DataMember]
        [JsonProperty("tracks")]
        public Track[] TrackList { get; set; }

        IEnumerator<Track> IEnumerable<Track>.GetEnumerator()
        {
            return TrackList != null ? ((IEnumerable<Track>)TrackList).GetEnumerator() : Enumerable.Empty<Track>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return TrackList != null ? ((IEnumerable<Track>)TrackList).GetEnumerator() : Enumerable.Empty<Track>().GetEnumerator();
        }

    }

}
