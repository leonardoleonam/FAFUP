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
    class PesquisaProspectoService : IPesquisaProspectoService
    {
        public OdontoHandler OdontoHandler { get; }

        public PesquisaProspectoService(bool isProduction)
        {
            OdontoHandler = new OdontoHandler
            {
                IsProduction = isProduction
            };
        }

        public PesquisaProspectoService()
        {
            OdontoHandler = new OdontoHandler();
        }                     

        public ProspectoPesquisaRetorno Pesquisar(ProspectoPesquisa prospectoPesquisa, bool isProduction)
        {
            var pesquisaProspecto = new ProspectoPesquisaRetorno();

            try
            {
                string prospectoPesquisaRequisicaoXml = prospectoPesquisa.Serialize();

                var response = OdontoHandler.CallWebService("pesquisarProspecto", prospectoPesquisaRequisicaoXml);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();

                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responseStr);

                    XmlNodeList xnList = xmldoc.GetElementsByTagName("return");

                    responseStr = ((XmlNodeList)xnList)[0].InnerXml.ToString();

                    responseStr = $"<ProspectoPesquisaRetorno xmlns:json='http://james.newtonking.com/projects/json'>{responseStr}</ProspectoPesquisaRetorno>";
                    responseStr = responseStr.Replace("<itens>", "<itens json:Array='true'>");                    

                    xmldoc.LoadXml(responseStr);
                    var jsonConverted = JsonConvert.SerializeXmlNode(xmldoc, Newtonsoft.Json.Formatting.None, true);
                    pesquisaProspecto = JsonConvert.DeserializeObject<ProspectoPesquisaRetorno>(jsonConverted);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return pesquisaProspecto;
        }
    }
}
