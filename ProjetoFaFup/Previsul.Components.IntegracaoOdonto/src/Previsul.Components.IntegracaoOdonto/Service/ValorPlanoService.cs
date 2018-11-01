using Newtonsoft.Json;
using Previsul.Components.IntegracaoOdonto.Helper;
using Previsul.Components.IntegracaoOdonto.Interface;
using Previsul.Components.IntegracaoOdonto.Model;
using Previsul.Components.IntegracaoOdonto.Service.Handler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Previsul.Components.IntegracaoOdonto.Service
{
    class ValorPlanoService : IValorPlanoService
    {
        public OdontoHandler OdontoHandler { get; }

        public ValorPlanoService(bool isProduction)
        {
            OdontoHandler = new OdontoHandler
            {
                IsProduction = isProduction
            };
        }

        public ValorPlanoService()
        {
            OdontoHandler = new OdontoHandler();
        }

        public ValorPlanoRetorno ObterValorPlano(Dictionary<string, string> valorPlanoRequisicao, bool isProduction)
        {
            var listValorPlanos = new ValorPlanoRetorno();
            
            try
            {
                string valorPlanoRequisicaoXml = valorPlanoRequisicao.GerarXmlInterno();

                var response = OdontoHandler.CallWebService("obterValorPlanoVidas", valorPlanoRequisicaoXml);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();

                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responseStr);

                    XmlNodeList xnList = xmldoc.GetElementsByTagName("return");

                    responseStr = ((XmlNodeList)xnList)[0].InnerXml.ToString();

                    responseStr = $"<ValorPlanos xmlns:json='http://james.newtonking.com/projects/json'>{responseStr}</ValorPlanos>";                    

                    xmldoc.LoadXml(responseStr);
                    var jsonConverted = JsonConvert.SerializeXmlNode(xmldoc, Newtonsoft.Json.Formatting.None, true);
                    listValorPlanos = JsonConvert.DeserializeObject<ValorPlanoRetorno>(jsonConverted);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return listValorPlanos;
        }
    }
}
