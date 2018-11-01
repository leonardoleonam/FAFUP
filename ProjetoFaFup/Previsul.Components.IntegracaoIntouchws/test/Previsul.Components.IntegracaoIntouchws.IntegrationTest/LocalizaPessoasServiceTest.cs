using Xunit;
using Previsul.Components.IntegracaoIntouchws.Service;
using Previsul.Components.IntegracaoIntouchws.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace Previsul.Components.IntegracaoIntouchws
{
    public class LocalizaPessoasServiceTest
    {
        IIntegracaoIntouchWsService IntegracaoIntouchWsService { get; }
        public LocalizaPessoasServiceTest()
        {
            IntegracaoIntouchWsService = new IntegracaoIntouchWsService(new MemoryCache(new MemoryCacheOptions()));
        }

        [Fact]
        public void Deve_Listar_Dados_De_PF()
        {
            var result = IntegracaoIntouchWsService.LocalizarPessoas("32518799877", "PF");
            Assert.True(result.CadastroUnit != null);
        }

        [Fact]
        public void Deve_Listar_Dados_De_PJ()
        {
            var result = IntegracaoIntouchWsService.LocalizarPessoas("12335346000120", "PJ");
            Assert.True(result.CadastroUnit != null);
        }
    }
}
