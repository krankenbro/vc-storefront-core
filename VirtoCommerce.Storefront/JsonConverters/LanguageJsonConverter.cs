using System;
using AutoRest.Core.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VirtoCommerce.Storefront.Model;

namespace VirtoCommerce.Storefront.JsonConverters
{
    /// <summary>
    /// Correctly deserialize language object because it has only one public constructor with culture name argument
    /// </summary>
    public class LanguageJsonConverter : JsonConverter
    {
        public LanguageJsonConverter()
        {
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Language).IsAssignableFrom(objectType);
        }

        public override bool CanRead => true;

        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = JToken.ReadFrom(reader);
            var cultureName = value.SelectToken(nameof(Language.CultureName).ToCamelCase()).ToObject(typeof(string), serializer) as string;
            return new Language(cultureName);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
