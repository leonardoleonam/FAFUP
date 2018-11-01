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
    class LiConcordoService : ILiConcordoService
    {
        public OdontoHandler OdontoHandler { get; }

        public LiConcordoService(bool isProduction)
        {
            OdontoHandler = new OdontoHandler
            {
                IsProduction = isProduction
            };
        }

        public LiConcordoService()
        {
            OdontoHandler = new OdontoHandler();
        }

        public LiConcordoRetorno ObterLiConcordo(bool isProduction)
        {
            var liConcordo = new LiConcordoRetorno();

            try
            {
                var response = OdontoHandler.CallWebService("obterLiConcordo", null);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();

                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responseStr);

                    XmlNodeList xnList = xmldoc.GetElementsByTagName("return");

                    responseStr = ((XmlNodeList)xnList)[0].InnerXml.ToString();

                    responseStr = $"<LiConcordoRetorno xmlns:json='http://james.newtonking.com/projects/json'>{responseStr}</LiConcordoRetorno>";

                    xmldoc.LoadXml(responseStr);
                    var jsonConverted = JsonConvert.SerializeXmlNode(xmldoc, Newtonsoft.Json.Formatting.None, true);
                    liConcordo = JsonConvert.DeserializeObject<LiConcordoRetorno>(jsonConverted);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return liConcordo;
        }
    }
}
