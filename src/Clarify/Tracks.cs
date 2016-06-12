using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace Clarify
{

    [HalClass("Tracks")]
    [Serializable]
    [JsonObject]
    public class Tracks :
        HalObject,
        IEnumerable<Track>
    {
        
        [JsonProperty("bundle_id")]
        public Guid BundleId { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("status")]
        public TrackStatus Status { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

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
