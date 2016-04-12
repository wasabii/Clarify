using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clarify
{

    [HalClass("Tracks")]
    public class Tracks :
        HalObject,
        IEnumerable<Track>
    {

        public Guid BundleId
        {
            get { return GetPropertyValue<Guid>("bundle_id"); }
        }

        public int Version
        {
            get { return GetPropertyValue<int>("version"); }
        }

        public TrackStatus Status
        {
            get { return GetPropertyValue<TrackStatus>("status"); }
        }

        public DateTime Created
        {
            get { return GetPropertyValue<DateTime>("created"); }
        }

        public DateTime Updated
        {
            get { return GetPropertyValue<DateTime>("updated"); }
        }

        public Track[] TrackList
        {
            get { return GetPropertyValue<Track[]>("tracks"); }
        }

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
