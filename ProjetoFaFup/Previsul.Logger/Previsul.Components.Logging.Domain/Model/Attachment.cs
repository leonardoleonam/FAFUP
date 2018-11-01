using Newtonsoft.Json;

namespace Previsul.Components.Logging.Domain.Model
{
    public class Attachment
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("fallback")]
        public string Fallback { get; set; }
    }
}