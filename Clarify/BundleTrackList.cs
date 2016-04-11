using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Clarify
{

    [DataContract]
    public class BundleTrackList :
        IEnumerable<Track>
    {

        [DataMember]
        [JsonProperty("bundle_id")]
        public Guid BundleId { get; set; }

        [DataMember]
        [JsonProperty("version")]
        public int Version { get; set; }

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
        public Track[] Tracks { get; set; }

        IEnumerator<Track> IEnumerable<Track>.GetEnumerator()
        {
            return ((IEnumerable<Track>)Tracks).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Tracks.GetEnumerator();
        }

    }

}
