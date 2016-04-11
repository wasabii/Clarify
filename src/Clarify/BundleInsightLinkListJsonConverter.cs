using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Clarify
{

    /// <summary>
    /// Serializes or deserializes a <see cref="BundleInsightLinkList"/>.
    /// </summary>
    public class BundleInsightLinkListJsonConverter :
        JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BundleInsightLinkList);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            if (obj == null)
                return null;

            var lst = new BundleInsightLinkList();
            lst.BundleId = obj.Property("bundle_id").Value<Guid>();
            lst.Created = obj.Property("created").Value<DateTime>();
            lst.Updated = obj.Property("updated").Value<DateTime>();
            lst.Insights = ReadLinksList((JObject)obj.Property("_links").Value, serializer).ToDictionary(i => i.Item1, i => i.Item2);
            return lst;
        }

        IEnumerable<Tuple<string, InsightLink>> ReadLinksList(JObject links, JsonSerializer serializer)
        {
            foreach (var link in links.Properties())
                if (link.Name.StartsWith("insight:"))
                    yield return Tuple.Create(
                        link.Name.Substring("insight:".Length),
                        ((JObject)link.Value).ToObject<InsightLink>(serializer));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }

}
