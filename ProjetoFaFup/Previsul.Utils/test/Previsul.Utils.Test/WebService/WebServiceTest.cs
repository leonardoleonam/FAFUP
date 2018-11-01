using Previsul.Utils.WebServices;
using System;
using System.Collections.Specialized;
using System.Net;
using Xunit;

namespace Previsul.Components.IntegracaoOdonto.IntegrationTest
{
    public class WebServiceTest
    {
        IWebService webServiceBase { get; }
        NameValueCollection requestHeader = new NameValueCollection();

        const string username = "ou_ws_previsul";
        const string password = "Caixa123*";
        readonly string encoded = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

        readonly string soapTemplate = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:web=\"http://webservice.odontows.odonto.tempopar.com.br/\"> "
                            + "<soapenv:Header/>"
                            + "<soapenv:Body>"
                            + "<web:listarOpcoesPlanos>"
                            + "{1}"
                            + "</web:listarOpcoesPlanos>"
                            + "</soapenv:Body>"
                            + " </soapenv:Envelope>";

        public WebServiceTest()
        {
            requestHeader.Add("Authorization", $"Basic {encoded}");

            webServiceBase = new WebServiceBase(new WebServiceModel()
            {
                Url = "https://200.10.245.188/OdontoWS/ws/GestaoContratoPort?wsdl",
                RequestHeader = requestHeader,
                RequestData = soapTemplate,
                Proxy = new WebProxy("webproxy.previsul.intranet", 80),
                ContentType = "text/xml; encoding='utf-8'",
                MethodType = Utils.Enums.WebServiceEnum.Verbs.POST
            });
        }

        [Fact]
        public void Deve_Retornar_Um_HttpWebResponse()
        {
            HttpWebResponse response = webServiceBase.Call();
            Assert.IsType<HttpWebResponse>(response);
        }
    }
}
