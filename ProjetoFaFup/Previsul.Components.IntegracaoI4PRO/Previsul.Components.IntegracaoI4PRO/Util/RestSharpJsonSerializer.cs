using System.IO;
using Newtonsoft.Json;
using RestSharp.Serializers;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Application.Domain.Util
{
    public class RestSharpJsonSerializer : ISerializer
    {
        public readonly JsonSerializer Serializer;

        public RestSharpJsonSerializer()
        {
            ContentType = "application/json";
            Serializer = new JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include
            };
        }

        public RestSharpJsonSerializer(JsonSerializer serializer)
        {
            ContentType = "application/json";
            Serializer = serializer;
        }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';

                    Serializer.Serialize(jsonTextWriter, obj);

                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }

        public string DateFormat { get; set; }
       
        public string RootElement { get; set; }
       
        public string Namespace { get; set; }
       
        public string ContentType { get; set; }
    }
}