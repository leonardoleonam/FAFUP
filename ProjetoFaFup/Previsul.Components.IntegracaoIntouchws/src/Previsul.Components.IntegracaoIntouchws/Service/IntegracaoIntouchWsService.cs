using Previsul.Components.IntegracaoIntouchws.Interface;
using Previsul.Components.IntegracaoIntouchws.Model;
using Microsoft.Extensions.Caching.Memory;

namespace Previsul.Components.IntegracaoIntouchws.Service
{
    public class IntegracaoIntouchWsService : IIntegracaoIntouchWsService
    {
        #region Variables

        ILocalizaPessoas LocalizaPessoasService;
        private readonly IMemoryCache _memoryCache;

        #endregion Variables

        #region Constructor

        public IntegracaoIntouchWsService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            LocalizaPessoasService = new LocalizaPessoasService(_memoryCache);
        }

        #endregion Constructor

        #region Methods

        public LocalizaPessoas LocalizarPessoas(string CPFouCNPJ, string TipoPessoa)
        {
            return LocalizaPessoasService.LocalizarPessoas(CPFouCNPJ, TipoPessoa);
        }

        #endregion Methods
    }
}