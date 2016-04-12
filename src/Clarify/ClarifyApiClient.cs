using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

using Clarify.Util;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Clarify
{

    public class ClarifyApiClient
    {

        readonly Type[] halClasses;
        readonly HttpClient http;
        Uri apiUri;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        ClarifyApiClient()
        {
            halClasses = typeof(HalObject).Assembly.GetTypes()
                .Where(i => i.IsSubclassOf(typeof(HalObject)))
                .ToArray();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="http"></param>
        public ClarifyApiClient(HttpClient http)
            : this()
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
        /// Finds the given <see cref="Type"/> of object to create in response to a given <paramref name="className"/>
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        Type GetObjectTypeByClassName(string className)
        {
            return halClasses
                .Where(i => i.GetCustomAttribute<HalClassAttribute>(false)?.ClassName == className)
                .FirstOrDefault();
        }

        /// <summary>
        /// Creates a <see cref="HalObject"/> for the given <see cref="JObject"/>.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        T CreateHalObjectForJObject<T>(JObject o)
            where T : HalObject
        {
            // find known class name
            var name = o["_class"]?.Value<string>();
            if (name == null)
                return o.ToObject<T>();

            // find type marked with class name
            var type = GetObjectTypeByClassName(name);
            if (type == null)
                return o.ToObject<T>();

            // marked type is a descendant of specified type, so use
            if (typeof(T).IsAssignableFrom(type))
                return (T)o.ToObject(type);

            throw new HalException();
        }

        /// <summary>
        /// Initiates a HTTP request and returns the result with the known <see cref="HalObject"/> type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        async Task<T> GetHalObjectAsync<T>(HttpRequestMessage request)
            where T : HalObject
        {
            using (var response = await http.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return CreateHalObjectForJObject<T>(JObject.Parse(await response.Content.ReadAsStringAsync()));
            }
        }

        /// <summary>
        /// Initializes a HTTP request and returns the result with the known <see cref="HalObject"/> type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        async Task<T> GetHalObjectAsync<T>(HttpMethod method, Uri requestUri)
            where T : HalObject
        {
            using (var message = new HttpRequestMessage(method, requestUri))
                return await GetHalObjectAsync<T>(message);
        }

        /// <summary>
        /// Transforms a <see cref="JObject"/> into a dictionary of key value pairs.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs(JObject o)
        {
            return o.Properties()
                .Where(i => i.Value != null)
                .Where(i => i.Value.Type != JTokenType.Null)
                .Select(i => new KeyValuePair<string, string>(i.Name, i.Value.ToString()));
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
        public async Task<BundleRef> PostBundleAsync(BundlePostRequest request)
        {
            Contract.Requires<ArgumentNullException>(request != null);

            using (var message = new HttpRequestMessage(HttpMethod.Post, ApiUri
                .Combine("bundles")))
            {
                message.Content = new FormUrlEncodedContent(ToKeyValuePairs(JObject.FromObject(request)));
                return await GetHalObjectAsync<BundleRef>(message);
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

            return await GetHalObjectAsync<Bundle>(HttpMethod.Get, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N")));
        }

        /// <summary>
        /// PUT /bundles/{bundleId}
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BundleRef> PutBundleAsync(Guid bundleId, BundlePutRequest request)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);
            Contract.Requires<ArgumentNullException>(request != null);

            using (var req = new HttpRequestMessage(HttpMethod.Put, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))))
            {
                req.Content = new FormUrlEncodedContent(ToKeyValuePairs(JObject.FromObject(request)));
                return await GetHalObjectAsync<BundleRef>(req);
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
        public async Task<Insights> GetBundleInsightsAsync(Guid bundleId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);

            return await GetHalObjectAsync<Insights>(HttpMethod.Get, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("insights"));
        }

        /// <summary>
        /// POST /bundles/{bundleId}/insights
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="insight"></param>
        /// <returns></returns>
        public async Task<Insight> PostBundleInsightsAsync(Guid bundleId, string insight)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);
            Contract.Requires<ArgumentNullException>(insight != null);

            using (var request = new HttpRequestMessage(HttpMethod.Post, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("insights")))
            {
                request.Content = new FormUrlEncodedContent(new Dictionary<string, string> { { "insight", insight } });
                return await GetHalObjectAsync<Insight>(request);
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

            return await GetHalObjectAsync<Insight>(HttpMethod.Get, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("insights")
                .Combine(insightId.ToString("N")));
        }

        /// <summary>
        /// GET /bundles/{bundleId}/metadata
        /// </summary>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task<Metadata> GetBundleMetadataAsync(Guid bundleId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);

            return await GetHalObjectAsync<Metadata>(HttpMethod.Get, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("insights"));
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
        public async Task<MetadataRef> PutBundleMetadataAsync(Guid bundleId, Dictionary<string, object> data, int? version = null)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);
            Contract.Requires<ArgumentNullException>(data != null);

            using (var req = new HttpRequestMessage(HttpMethod.Put, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("metadata")))
            {
                var map = new Dictionary<string, object>();
                map["data"] = data;
                map["version"] = version;
                req.Content = new FormUrlEncodedContent(ToKeyValuePairs(JObject.FromObject(map)));
                return await GetHalObjectAsync<MetadataRef>(req);
            }
        }

        /// <summary>
        /// GET /bundles/{bundleId}/tracks
        /// </summary>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task<Tracks> GetBundleTracksAsync(Guid bundleId)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);

            return await GetHalObjectAsync<Tracks>(HttpMethod.Get, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("tracks"));
        }

        /// <summary>
        /// POST /bundles/{bundleId}/tracks
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TrackRef> PostBundleTrackAsync(Guid bundleId, BundleTrackPostRequest request)
        {
            Contract.Requires<ArgumentOutOfRangeException>(bundleId != Guid.Empty);
            Contract.Requires<ArgumentNullException>(request != null);

            using (var req = new HttpRequestMessage(HttpMethod.Post, ApiUri
                .Combine("bundles")
                .Combine(bundleId.ToString("N"))
                .Combine("tracks")))
            {
                req.Content = new FormUrlEncodedContent(ToKeyValuePairs(JObject.FromObject(request)));
                return await GetHalObjectAsync<TrackRef>(req);
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