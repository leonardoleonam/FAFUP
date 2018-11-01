using Microsoft.Extensions.Caching.Memory;
using Previsul.Utils.WebServices;
using Previsul.Components.IntegracaoIntouchws.Interface;
using System;
using System.IO;
using System.Net;
using System.Xml;

namespace Previsul.Components.IntegracaoIntouchws.Service
{
    public class TokenService : IToken
    {
        #region Variables

        const string keyCache = "Token";
        private readonly IMemoryCache _memoryCache;

        #endregion Variables

        #region Constructor

        public TokenService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            if (_memoryCache == null) throw new ArgumentException("Por favor, ative o serviço de Memory Cache");
        }

        #endregion Constructor

        #region Methods

        public string GetToken()
        {
            string token = _memoryCache.Get<string>(keyCache);

            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    WebServiceBase wsIntouch = new WebServiceBase(ConfigurationWS.GetModelToken());
                    var response = wsIntouch.Call();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream responseStream = response.GetResponseStream();
                        string responseStr = new StreamReader(responseStream).ReadToEnd();

                        var xmldoc = new XmlDocument();
                        xmldoc.LoadXml(responseStr);

                        XmlNodeList xnList = xmldoc.GetElementsByTagName("GerarTokenResult");

                        token = ((XmlNodeList)xnList)[0].InnerXml.ToString();

                        AddTokenCache(token);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro ao conseguir Token: [{ex.Message}]");
            }

            return token;
        }

        private void AddTokenCache(string Token)
        {
            MemoryCacheEntryOptions cacheExpirationOptions = new MemoryCacheEntryOptions();
            cacheExpirationOptions.AbsoluteExpiration = DateTime.Now.AddHours(23);

            _memoryCache.CreateEntry(keyCache);
            _memoryCache.Set<string>(keyCache, Token, cacheExpirationOptions);
        }

        #endregion Methods
    }
}
