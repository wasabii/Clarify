using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Clarify.Util;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Clarify
{

    public class ClarifyApiClient
    {

        readonly HttpClient http;
        Uri apiUri;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="http"></param>
        public ClarifyApiClient(HttpClient http)
        {
            Contract.Requires<ArgumentNullException>(http != null);

            this.http = http;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="apiUri"></param>
        /// <param name="apiKey"></param>
        public ClarifyApiClient(Uri apiUri, string apiKey)
            : this(new HttpClient())
        {
            Contract.Requires<ArgumentNullException>(apiUri != null);
            Contract.Requires<ArgumentNullException>(apiKey != null);

            ApiUri = apiUri;
            ApiKey = apiKey;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="apiKey"></param>
        public ClarifyApiClient(string apiKey)
            : this(new Uri("https://api.clarify.io/v1"), apiKey)
        {
            Contract.Requires<ArgumentNullException>(apiKey != null);
        }

        /// <summary>
        /// Gets the URI prefix of the Clarify API.
        /// </summary>
        public Uri ApiUri
        {
            get { return apiUri; }
            set { apiUri = value; }
        }

        /// <summary>
        /// Gets the configured API key.
        /// </summary>
        public string ApiKey
        {
            get { return http.DefaultRequestHeaders.Authorization.Parameter; }
            private set { http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value); }
        }

        /// <summary>
        /// GET /bundles
        /// </summary>
        /// <returns></returns>
        public async Task<PagedResponse<Bundle>> GetBundlesAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// POST /bundles
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BundlePostResponse> PostBundleAsync(BundlePostRequest request)
        {
            Contract.Requires<ArgumentNullException>(request != null);

            using (var req = new HttpRequestMessage(HttpMethod.Post, ApiUri
                .Combine("bundles")))
            {
                // format request arguments
                var map = new Dictionary<string, string>();
                if (request.Name != null)
                    map["name"] = request.Name;
                if (request.MediaUrl != null)
                    map["media_url"] = request.MediaUrl.ToString();
                map["audio_language"] = EnumUtil.ToEnumString(request.AudioLanguage);
                if (request.Metadata != null)
                    map["metadata"] = new JObject(request.Metadata.Select(i => new JProperty(i.Key, JToken.FromObject(i.Value)))).ToString();
                map["audio_channel"] = EnumUtil.ToEnumString(request.AudioChannel);
                if (request.ExternalId != null)
                    map["external_id"] = request.ExternalId;
                req.Content = new FormUrlEncodedContent(map);

                using (var res = await http.SendAsync(req))
                {
                    res.EnsureSuccessStatusCode();
                    var str = await res.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<BundlePostResponse>(str);
                    return obj;
                }
            }
        }

        /// <summary>
        /// GET /bundles/{bundleId}
        /// </summary>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task<Bundle> GetBundleAsync(Guid bundleId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);

            using (var req = new HttpRequestMessage(HttpMethod.Get, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))))
            {
                using (var res = await http.SendAsync(req))
                {
                    res.EnsureSuccessStatusCode();
                    var str = await res.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<Bundle>(str);
                    return obj;
                }
            }
        }

        /// <summary>
        /// PUT /bundles/{bundleId}
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BundlePutResponse> PutBundleAsync(Guid bundleId, BundlePutRequest request)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);
            Contract.Requires<ArgumentNullException>(request != null);

            using (var req = new HttpRequestMessage(HttpMethod.Put, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))))
            {
                // format request arguments
                var map = new Dictionary<string, string>();
                if (request.Name != null)
                    map["name"] = request.Name;
                if (request.ExternalId != null)
                    map["external_id"] = request.ExternalId;
                if (request.Version != null)
                    map["version"] = request.Version.ToString();
                req.Content = new FormUrlEncodedContent(map);

                using (var res = await http.SendAsync(req))
                {
                    res.EnsureSuccessStatusCode();
                    var str = await res.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<BundlePutResponse>(str);
                    return obj;
                }
            }
        }

        /// <summary>
        /// DELETE /bundles/{bundleId}
        /// </summary>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task DeleteBundleAsync(Guid bundleId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);

            await http.DeleteAsync(ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N")));
        }

        /// <summary>
        /// GET /bundles/{bundleId}/insights
        /// </summary>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task<BundleInsightLinkList> GetBundleInsightsAsync(Guid bundleId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);

            using (var req = new HttpRequestMessage(HttpMethod.Get, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("insights")))
            {
                using (var res = await http.SendAsync(req))
                {
                    res.EnsureSuccessStatusCode();
                    var str = await res.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<BundleInsightLinkList>(str);
                    return obj;
                }
            }
        }

        /// <summary>
        /// POST /bundles/{bundleId}/insights
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="insight"></param>
        /// <returns></returns>
        public async Task<Insight> PostBundleInsights(Guid bundleId, string insight)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);
            Contract.Requires<ArgumentNullException>(insight != null);

            using (var req = new HttpRequestMessage(HttpMethod.Post, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("insights")))
            {
                req.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "insight", insight }
                });

                using (var res = await http.SendAsync(req))
                {
                    res.EnsureSuccessStatusCode();
                    var str = await res.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<Insight>(str);
                    return obj;
                }
            }
        }

        /// <summary>
        /// GET /bundles/{bundleId}/insights/{insightId}
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="insightId"></param>
        /// <returns></returns>
        public async Task<Insight> GetBundleInsightAsync(Guid bundleId, Guid insightId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);
            Contract.Requires<ArgumentOutOfRangeException>(insightId != Guid.Empty);

            using (var req = new HttpRequestMessage(HttpMethod.Get, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("insights")
                .Combine(insightId.ToString("N"))))
            {
                using (var res = await http.SendAsync(req))
                {
                    res.EnsureSuccessStatusCode();
                    var str = await res.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<Insight>(str);
                    return obj;
                }
            }
        }

        /// <summary>
        /// GET /bundles/{bundleId}/metadata
        /// </summary>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task<BundleMetadata> GetBundleMetadataAsync(Guid bundleId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);

            using (var req = new HttpRequestMessage(HttpMethod.Get, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("insights")))
            {
                using (var res = await http.SendAsync(req))
                {
                    res.EnsureSuccessStatusCode();
                    var str = await res.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<BundleMetadata>(str);
                    return obj;
                }
            }
        }

        /// <summary>
        /// DELETE /bundles/{bundleId}/metadata
        /// </summary>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task DeleteBundleMetadataAsync(Guid bundleId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);

            await http.DeleteAsync(ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("metadata"));
        }

        /// <summary>
        /// PUT /bundles/{bundleId}/metadata
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="insight"></param>
        /// <returns></returns>
        public async Task PutBundleMetadataAsync(Guid bundleId, Dictionary<string, object> data, int? version = null)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);
            Contract.Requires<ArgumentNullException>(data != null);

            using (var req = new HttpRequestMessage(HttpMethod.Put, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("metadata")))
            {
                var map = new Dictionary<string, string>();
                if (data != null)
                    map["data"] = JsonConvert.SerializeObject(data);
                if (version != null)
                    map["version"] = version.ToString();

                using (var res = await http.SendAsync(req))
                {
                    res.EnsureSuccessStatusCode();
                }
            }
        }

        /// <summary>
        /// GET /bundles/{bundleId}/tracks
        /// </summary>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task<BundleTrackList> GetBundleTracksAsync(Guid bundleId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);

            using (var req = new HttpRequestMessage(HttpMethod.Get, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("tracks")))
            {
                using (var res = await http.SendAsync(req))
                {
                    res.EnsureSuccessStatusCode();
                    var str = await res.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<BundleTrackList>(str);
                    return obj;
                }
            }
        }

        /// <summary>
        /// POST /bundles/{bundleId}/tracks
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task PostBundleTrackAsync(Guid bundleId, BundleTrackPostRequest request)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);
            Contract.Requires<ArgumentNullException>(request != null);

            using (var req = new HttpRequestMessage(HttpMethod.Post, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("tracks")))
            {
                // format request arguments
                var map = new Dictionary<string, string>();
                if (request.Label != null)
                    map["label"] = request.Label;
                if (request.MediaUrl != null)
                    map["media_url"] = request.MediaUrl.ToString();
                map["audio_channel"] = EnumUtil.ToEnumString(request.AudioChannel);
                map["audio_language"] = EnumUtil.ToEnumString(request.AudioLanguage);
                if (request.Index != null)
                    map["track"] = request.Index.ToString();
                if (request.Version != null)
                    map["version"] = request.Version.ToString();
                req.Content = new FormUrlEncodedContent(map);

                using (var res = await http.SendAsync(req))
                {
                    res.EnsureSuccessStatusCode();
                }
            }
        }

        /// <summary>
        /// DELETE /bundles/{bundleId}/tracks
        /// </summary>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task DeleteBundleTracksAsync(Guid bundleId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);

            await http.DeleteAsync(ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("tracks"));
        }

        /// <summary>
        /// GET /bundles/{bundleId}/tracks/{trackId}
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="trackId"></param>
        /// <returns></returns>
        public async Task<Track> GetBundleTrackAsync(Guid bundleId, Guid trackId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);
            Contract.Requires<ArgumentOutOfRangeException>(trackId != Guid.Empty);

            using (var req = new HttpRequestMessage(HttpMethod.Get, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("tracks")
                .Combine(trackId.ToString("N"))))
            {
                using (var res = await http.SendAsync(req))
                {
                    res.EnsureSuccessStatusCode();
                    var str = await res.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<Track>(str);
                    return obj;
                }
            }
        }

        /// <summary>
        /// DELETE /bundles/{bundleId}/tracks/{trackId}
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="trackId"></param>
        /// <returns></returns>
        public async Task DeleteBundleTrackAsync(Guid bundleId, Guid trackId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);
            Contract.Requires<ArgumentOutOfRangeException>(trackId != Guid.Empty);

            await http.DeleteAsync(ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("tracks")
                .Combine(trackId.ToString("N")));
        }

    }

}