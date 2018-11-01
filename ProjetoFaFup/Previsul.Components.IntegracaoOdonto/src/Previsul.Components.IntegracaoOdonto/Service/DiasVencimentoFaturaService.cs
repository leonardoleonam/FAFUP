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
    class DiasVencimentoFaturaService : IDiasVencimentoFaturaService
    {
        public OdontoHandler OdontoHandler { get; }

        public DiasVencimentoFaturaService(bool isProduction)
        {
            OdontoHandler = new OdontoHandler
            {
                IsProduction = isProduction
            };
        }

        public DiasVencimentoFaturaService()
        {
            OdontoHandler = new OdontoHandler();
        }

        public DiasVencimentoFaturaRetorno ListarDiasVencimentoFatura(bool isProduction)
        {
            var listDiasVencimentoFatura = new DiasVencimentoFaturaRetorno();

            try
            {
                var response = OdontoHandler.CallWebService("listaDiasVenciamentoFatura", null);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();

                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responseStr);

                    XmlNodeList xnList = xmldoc.GetElementsByTagName("return");

                    responseStr = ((XmlNodeList)xnList)[0].InnerXml.ToString();

                    responseStr = $"<DiasVencimentoFaturaRetorno xmlns:json='http://james.newtonking.com/projects/json'>{responseStr}</DiasVencimentoFaturaRetorno>";
                    responseStr = responseStr.Replace("<DiaVencimentoFatura>", "<DiaVencimentoFatura json:Array='true'>");

                    xmldoc.LoadXml(responseStr);
                    var jsonConverted = JsonConvert.SerializeXmlNode(xmldoc, Newtonsoft.Json.Formatting.None, true);
                    listDiasVencimentoFatura = JsonConvert.DeserializeObject<DiasVencimentoFaturaRetorno>(jsonConverted);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return listDiasVencimentoFatura;
        }
    }
}
