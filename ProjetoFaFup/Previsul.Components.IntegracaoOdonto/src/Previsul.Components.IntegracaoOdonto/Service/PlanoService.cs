using Newtonsoft.Json;
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
    class PlanoService : IPlanoService
    {
        public OdontoHandler OdontoHandler { get; }

        public PlanoService(bool isProduction)
        {
            OdontoHandler = new OdontoHandler
            {
                IsProduction = isProduction
            };
        }

        public PlanoService()
        {
            OdontoHandler = new OdontoHandler();
        }

        public PlanosRetorno ListarPlanos(bool isProduction)
        {
            var listPlanos = new PlanosRetorno();

            try
            {
                var response = OdontoHandler.CallWebService("listarOpcoesPlanos", null);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();

                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responseStr);

                    XmlNodeList xnList = xmldoc.GetElementsByTagName("return");

                    responseStr = ((XmlNodeList)xnList)[0].InnerXml.ToString();

                    responseStr = $"<Planos xmlns:json='http://james.newtonking.com/projects/json'>{responseStr}</Planos>";
                    responseStr = responseStr.Replace("<valores>", "<valores json:Array='true'>");
                    responseStr = responseStr.Replace("<mensagens>", "<mensagens json:Array='true'>");

                    xmldoc.LoadXml(responseStr);
                    var jsonConverted = JsonConvert.SerializeXmlNode(xmldoc, Newtonsoft.Json.Formatting.None, true);
                    listPlanos = JsonConvert.DeserializeObject<PlanosRetorno>(jsonConverted);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return listPlanos;
        }
    }
}
