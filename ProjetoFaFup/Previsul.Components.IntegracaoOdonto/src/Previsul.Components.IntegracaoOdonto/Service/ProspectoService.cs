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
    class ProspectoService : IProspectoService
    {
        public OdontoHandler OdontoHandler { get; }

        public ProspectoService(bool isProduction)
        {
            OdontoHandler = new OdontoHandler
            {
                IsProduction = isProduction
            };
        }

        public ProspectoService()
        {
            OdontoHandler = new OdontoHandler();
        }

        public ProspectoRetorno IncluirProspecto(Prospecto Prospecto, bool isProduction)
        {

            var ProspectoRetorno = new ProspectoRetorno();


            try
            {

                string prospectXml = Prospecto.Serialize();
                var response = OdontoHandler.CallWebService("incluirProspecto", prospectXml);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();

                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responseStr);

                    XmlNodeList xnList = xmldoc.GetElementsByTagName("return");

                    responseStr = ((XmlNodeList)xnList)[0].InnerXml.ToString();

                    responseStr = $"<ProspectoRetorno xmlns:json='http://james.newtonking.com/projects/json'>{responseStr}</ProspectoRetorno>";
                    responseStr = responseStr.Replace("<mensagens>", "<mensagens json:Array='true'>");

                    xmldoc.LoadXml(responseStr);
                    var jsonConverted = JsonConvert.SerializeXmlNode(xmldoc, Newtonsoft.Json.Formatting.None, true);
                    ProspectoRetorno = JsonConvert.DeserializeObject<ProspectoRetorno>(jsonConverted);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

            return ProspectoRetorno;
        }
    }
}
