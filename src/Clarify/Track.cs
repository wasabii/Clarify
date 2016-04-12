using System;
using System.Runtime.Serialization;

namespace Clarify
{

    [DataContract]
    public class Track :
        HalObject
    {

        public Guid Id
        {
            get { return GetPropertyValue<Guid>("id"); }
        }

        public int Index
        {
            get { return GetPropertyValue<int>("track"); }
        }

        public string Label
        {
            get { return GetPropertyValue<string>("label"); }
        }

        public Uri MediaUrl
        {
            get { return GetPropertyValue<Uri>("media_url"); }
        }

        public AudioChannel AudioChannel
        {
            get { return GetPropertyValue<AudioChannel>("audio_channel"); }
        }

        public AudioLanguage AudioLanguage
        {
            get { return GetPropertyValue<AudioLanguage>("audio_language"); }
        }

        public DateTime Created
        {
            get { return GetPropertyValue<DateTime>("created"); }
        }

        public DateTime Updated
        {
            get { return GetPropertyValue<DateTime>("updated"); }
        }

        public TrackStatus Status
        {
            get { return GetPropertyValue<TrackStatus>("status"); }
        }

        public string MimeType
        {
            get { return GetPropertyValue<string>("mime_type"); }
        }

        public int MediaSize
        {
            get { return GetPropertyValue<int>("media_size"); }
        }

        public double Duration
        {
            get { return GetPropertyValue<double>("duration"); }
        }

        public int FetchResponseCode
        {
            get { return GetPropertyValue<int>("fetch_response_code"); }
        }

        public string FetchResponseMessage
        {
            get { return GetPropertyValue<string>("fetch_response_message"); }
        }

        public int MediaCode
        {
            get { return GetPropertyValue<int>("media_code"); }
        }

        public string MediaMessage
        {
            get { return GetPropertyValue<string>("media_message"); }
        }

    }

}
