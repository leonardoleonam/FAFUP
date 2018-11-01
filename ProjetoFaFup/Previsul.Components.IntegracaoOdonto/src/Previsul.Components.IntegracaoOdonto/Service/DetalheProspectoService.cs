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
    class DetalheProspectoService : IDetalheProspectoService
    {
        public OdontoHandler OdontoHandler { get; }

        public DetalheProspectoService(bool isProduction)
        {
            OdontoHandler = new OdontoHandler
            {
                IsProduction = isProduction
            };
        }

        public DetalheProspectoService()
        {
            OdontoHandler = new OdontoHandler();
        }

        public DetalheProspectoRetorno Detalhar(Dictionary<string, string> prospectoRequisicao, bool isProduction)
        {
            var detalheProspecto = new DetalheProspectoRetorno();

            try
            {
                string prospectoRequisicaoXml = prospectoRequisicao.GerarXmlInterno();

                var response = OdontoHandler.CallWebService("detalharProspecto", prospectoRequisicaoXml);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();

                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responseStr);

                    XmlNodeList xnList = xmldoc.GetElementsByTagName("return");

                    responseStr = ((XmlNodeList)xnList)[0].InnerXml.ToString();

                    responseStr = $"<DetalheProspectoRetorno xmlns:json='http://james.newtonking.com/projects/json'>{responseStr}</DetalheProspectoRetorno>";                    
                    responseStr = responseStr.Replace("<corretores>", "<corretores json:Array='true'>");
                    responseStr = responseStr.Replace("<planosEscolhas>", "<planosEscolhas json:Array='true'>");
                    

                    xmldoc.LoadXml(responseStr);
                    var jsonConverted = JsonConvert.SerializeXmlNode(xmldoc, Newtonsoft.Json.Formatting.None, true);
                    detalheProspecto = JsonConvert.DeserializeObject<DetalheProspectoRetorno>(jsonConverted);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return detalheProspecto;
        }
    }
}
