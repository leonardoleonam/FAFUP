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
    class AlteracaoProspectoService : IAlteracaoProspectoService
    {

        public OdontoHandler OdontoHandler { get; }

        public AlteracaoProspectoService(bool isProduction)
        {
            OdontoHandler = new OdontoHandler
            {
                IsProduction = isProduction
            };
        }

        public AlteracaoProspectoService()
        {
            OdontoHandler = new OdontoHandler();
        }

        public ProspectoAlteracaoRetorno Alterar(ProspectoAlteracao ProspectoAlteracao, bool isProduction)
        {
            var alteracaoProspecto = new ProspectoAlteracaoRetorno();

            try
            {
                string prospectoAlteracaoXml = ProspectoAlteracao.Serialize();
                var response = OdontoHandler.CallWebService("alterarProspecto", prospectoAlteracaoXml);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();

                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responseStr);

                    XmlNodeList xnList = xmldoc.GetElementsByTagName("return");

                    responseStr = ((XmlNodeList)xnList)[0].InnerXml.ToString();

                    responseStr = $"<ProspectoAlteracaoRetorno xmlns:json='http://james.newtonking.com/projects/json'>{responseStr}</ProspectoAlteracaoRetorno>";
                    responseStr = responseStr.Replace("<mensagens>", "<mensagens json:Array='true'>");                    

                    xmldoc.LoadXml(responseStr);
                    var jsonConverted = JsonConvert.SerializeXmlNode(xmldoc, Newtonsoft.Json.Formatting.None, true);
                    alteracaoProspecto = JsonConvert.DeserializeObject<ProspectoAlteracaoRetorno>(jsonConverted);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return alteracaoProspecto;
        }       
    }
}
