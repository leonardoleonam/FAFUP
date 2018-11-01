using Newtonsoft.Json;

namespace Previsul.Components.Logging.Domain.Model
{
    public class MessagePayload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("text")]
        public string Application { get; set; }

        [JsonProperty("attachments")]
        public Attachment[] Attachments { get; set; }
    }
}
