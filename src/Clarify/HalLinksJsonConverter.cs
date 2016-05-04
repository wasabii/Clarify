using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Clarify
{

    /// <summary>
    /// Handles seralization for a  <see cref="HalLinks"/> object.
    /// </summary>
    public class HalLinksJsonConverter :
        JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return typeof(HalLinks).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var o = (HalLinks)Activator.CreateInstance(objectType);
            var j = JObject.Load(reader);

            foreach (var property in j.Properties())
            {
                var value = property.Value;
                if (value.Type == JTokenType.Null)
                    o[property.Name] = null;
                if (value.Type == JTokenType.Object)
                    o[property.Name] = value.ToObject<HalLink>(serializer);
                if (value.Type == JTokenType.Array)
                    o[property.Name] = value.ToObject<HalLink[]>(serializer);
            }

            return o;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var links = value as HalLinks;
            if (links == null)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteStartObject();
            foreach (var link in links)
            {
                writer.WritePropertyName(link.Key);
                serializer.Serialize(writer, link.Value);
            }
            writer.WriteEndObject();
        }

    }

}
