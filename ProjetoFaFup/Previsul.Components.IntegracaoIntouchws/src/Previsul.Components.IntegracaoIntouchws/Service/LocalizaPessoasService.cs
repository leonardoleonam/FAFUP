using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Previsul.Components.IntegracaoIntouchws.Interface;
using Previsul.Components.IntegracaoIntouchws.Model;
using Previsul.Utils.WebServices;
using System;
using System.IO;
using System.Net;
using System.Xml;

namespace Previsul.Components.IntegracaoIntouchws.Service
{
    public class LocalizaPessoasService : ILocalizaPessoas
    {
        #region Variables

        const string methodName = "LocalizaPessoas";
        private readonly IMemoryCache _memoryCache;

        #endregion Variables

        #region Constructor

        public LocalizaPessoasService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        #endregion Constructor

        #region Methods

        public LocalizaPessoas LocalizarPessoas(string CPFouCNPJ, string TipoPessoa)
        {
            var listPessoas = new LocalizaPessoas();
            string parameter = $"<tem:documento>{CPFouCNPJ}</tem:documento><tem:tipoPessoa>{TipoPessoa}</tem:tipoPessoa>";
            string token = new TokenService(_memoryCache).GetToken();

            WebServiceBase wsIntouch = new WebServiceBase(ConfigurationWS.GetModelServices(methodName, token, parameter));

            try
            {
                var response = wsIntouch.Call();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();

                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responseStr);

                    XmlNodeList xnList = xmldoc.GetElementsByTagName("LocalizaPessoasResult");

                    responseStr = ((XmlNodeList)xnList)[0].InnerText.ToString();
                    responseStr = responseStr.Replace("<?xml version=\"1.0\" encoding=\"ISO-8859-1\" ?>", "");
                    responseStr = responseStr.Replace($"<CONSULTA_{TipoPessoa}>", "");
                    responseStr = responseStr.Replace($"</CONSULTA_{TipoPessoa}>", "");

                    responseStr = $"<LocalizaPessoas xmlns:json='http://james.newtonking.com/projects/json'>{responseStr}</LocalizaPessoas>";
                    responseStr = responseStr.Replace("<TELEFONES>", "<TELEFONES json:Array='true'>");
                    responseStr = responseStr.Replace("<ENDERECOS>", "<ENDERECOS json:Array='true'>");
                    responseStr = responseStr.Replace("<EMAILS>", "<EMAILS json:Array='true'>");
                    responseStr = responseStr.Replace("<SOCIOS>", "<SOCIOS json:Array='true'>");

                    xmldoc.LoadXml(responseStr);
                    var jsonConverted = JsonConvert.SerializeXmlNode(xmldoc, Newtonsoft.Json.Formatting.None, true);
                    listPessoas = JsonConvert.DeserializeObject<LocalizaPessoas>(jsonConverted);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro ao Localizar Pessoa: [{ex.Message}]");
            }

            return listPessoas;
        }

        #endregion Methods
    }
}
