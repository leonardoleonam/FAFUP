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
    class ComissaoCorretorService : IComissaoCorretorService
    {

        public OdontoHandler OdontoHandler { get; }

        public ComissaoCorretorService(bool isProduction)
        {
            OdontoHandler = new OdontoHandler
            {
                IsProduction = isProduction
            };
        }

        public ComissaoCorretorService()
        {
            OdontoHandler = new OdontoHandler();
        }

        public OpcoesComissaoCorretorRetorno ListarOpcoesComissaoCorretor(bool isProduction)
        {
            var listComissoesCorretor = new OpcoesComissaoCorretorRetorno();

            try
            {                
                var response = OdontoHandler.CallWebService("listaOpcoesComissaoCorretor", null);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();

                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responseStr);

                    XmlNodeList xnList = xmldoc.GetElementsByTagName("return");

                    responseStr = ((XmlNodeList)xnList)[0].InnerXml.ToString();

                    responseStr = $"<OpcoesComissaoCorretorRetorno xmlns:json='http://james.newtonking.com/projects/json'>{responseStr}</OpcoesComissaoCorretorRetorno>";
                    responseStr = responseStr.Replace("<ComissaoCorretor>", "<ComissaoCorretor json:Array='true'>");

                    xmldoc.LoadXml(responseStr);
                    var jsonConverted = JsonConvert.SerializeXmlNode(xmldoc, Newtonsoft.Json.Formatting.None, true);
                    listComissoesCorretor = JsonConvert.DeserializeObject<OpcoesComissaoCorretorRetorno>(jsonConverted);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return listComissoesCorretor;
        }
    }
}
