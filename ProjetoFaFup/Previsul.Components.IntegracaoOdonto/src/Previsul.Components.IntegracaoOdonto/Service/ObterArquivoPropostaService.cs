using Newtonsoft.Json;
using Previsul.Components.IntegracaoOdonto.Interface;
using Previsul.Components.IntegracaoOdonto.Model;
using Previsul.Components.IntegracaoOdonto.Service.Handler;
using Previsul.Components.IntegracaoOdonto.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Previsul.Components.IntegracaoOdonto.Service
{
    class ObterArquivoPropostaService : IObterArquivoPropostaService
    {

        public OdontoHandler OdontoHandler { get; }

        public ObterArquivoPropostaService(bool isProduction)
        {
            OdontoHandler = new OdontoHandler
            {
                IsProduction = isProduction
            };
        }

        public ObterArquivoPropostaService()
        {
            OdontoHandler = new OdontoHandler();
        }

        public ArquivoPropostaRetorno Obter(Dictionary<string, string> numeroProposta, bool isProduction)
        {
            var arquivoProposta = new ArquivoPropostaRetorno();

            try
            {                                
                string numeroPropostaXml = numeroProposta.GerarXmlInterno();

                var response = OdontoHandler.CallWebService("obterArquivoProposta", numeroPropostaXml);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();

                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responseStr);

                    XmlNodeList xnList = xmldoc.GetElementsByTagName("return");

                    responseStr = ((XmlNodeList)xnList)[0].InnerXml.ToString();

                    responseStr = $"<ArquivoPropostaRetorno xmlns:json='http://james.newtonking.com/projects/json'>{responseStr}</ArquivoPropostaRetorno>";
                    responseStr = responseStr.Replace("<ArquivoProposta>", "<ArquivoProposta json:Array='true'>");

                    xmldoc.LoadXml(responseStr);
                    var jsonConverted = JsonConvert.SerializeXmlNode(xmldoc, Newtonsoft.Json.Formatting.None, true);
                    arquivoProposta = JsonConvert.DeserializeObject<ArquivoPropostaRetorno>(jsonConverted);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return arquivoProposta;
        }
    }
}
