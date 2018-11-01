using Previsul.Utils.Enums.WebServiceEnum;
using System.Collections.Specialized;
using System.Net;

namespace Previsul.Utils.WebServices
{
    public class WebServiceModel
    {
        public string Url { get; set; }
        public NameValueCollection RequestHeader { get; set; }
        public string RequestData { get; set; }
        public Verbs MethodType { get;set; }
        public string ContentType { get; set; }
        public WebProxy Proxy { get; set; }
    }
}
