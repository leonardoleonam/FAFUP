using Previsul.Utils.Enums.WebServiceEnum;
using Previsul.Utils.WebServices;
using System;
using System.Collections.Specialized;
using System.Net;

namespace Previsul.Components.IntegracaoIntouchws.Service
{
    public class ConfigurationWS
    {
        #region Variables 

        const string url = "http://wsi4.unitfour.com.br/intouchws.asmx?wsdl";
        const string username = "PREVISUL";
        const string password = "LUSIVRp@2018";
        const string cliente = "caixa";
        const string contentType = "text/xml; encoding='utf-8'";
        static WebProxy wbProxy = new WebProxy("webproxy.previsul.intranet", 80);

        #endregion Variables

        #region Methods

        public static WebServiceModel GetModelToken()
        {
            string requestData = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:tem=\"http://tempuri.org/\">"
                    + "<soapenv:Header/>"
                    + "<soapenv:Body>"
                    + $"<tem:GerarToken>"
                    + $"<tem:usuario>{username}</tem:usuario>"
                    + $"<tem:senha>{password}</tem:senha>"
                    + $"<tem:cliente>{cliente}</tem:cliente>"
                    + $"</tem:GerarToken>"
                    + "</soapenv:Body>"
                    + "</soapenv:Envelope>";

            return new WebServiceModel()
            {
                Url = url,
                RequestData = requestData,
                Proxy = wbProxy,
                ContentType = contentType,
                MethodType = Verbs.POST
            };
        }

        public static WebServiceModel GetModelServices(string methodName, string token, string parameters = "")
        {
            string encoded = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

            NameValueCollection requestHeader = new NameValueCollection();
            requestHeader.Add("Authorization", $"Basic {encoded}");

            string requestData = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:tem=\"http://tempuri.org/\">"
                    + "<soapenv:Header>"
                    + "<tem:Credencial>"
                    + $"<tem:Token>{token}</tem:Token>"
                    + "</tem:Credencial>"
                    + "</soapenv:Header>"
                    + "<soapenv:Body>"
                    + $"<tem:{methodName}>"
                    + $"{parameters}"
                    + $"</tem:{methodName}>"
                    + "</soapenv:Body>"
                    + "</soapenv:Envelope>";

            return new WebServiceModel()
            {
                Url = url,
                RequestHeader = requestHeader,
                RequestData = requestData,
                Proxy = wbProxy,
                ContentType = contentType,
                MethodType = Verbs.POST
            };
        }

        #endregion Methods
    }
}
