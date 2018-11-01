using Newtonsoft.Json;
using Previsul.Components.Logging.Domain.Model;
using System;
using System.Collections.Specialized;
using System.Net;

namespace Previsul.Components.Logging.Domain.Services
{
    public static class SlackClient
    {
        private static readonly Uri Uri = new Uri("https://hooks.slack.com/services/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");

        public static void SendMessage(MessagePayload payload)
        {
            var payloadJson = JsonConvert.SerializeObject(payload);

            using (var client = new WebClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                client.Proxy = new WebProxy("webproxy.previsul.intranet") {Credentials = CredentialCache.DefaultCredentials};

                var data = new NameValueCollection { ["payload"] = payloadJson };

                client.UploadValues(Uri, "POST", data);
            }
        }
    }
}