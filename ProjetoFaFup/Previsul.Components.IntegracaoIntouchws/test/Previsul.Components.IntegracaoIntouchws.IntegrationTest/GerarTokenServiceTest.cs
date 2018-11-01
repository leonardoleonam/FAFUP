using Microsoft.Extensions.Caching.Memory;
using Previsul.Components.IntegracaoIntouchws.Service;
using Xunit;

namespace Previsul.Components.IntegracaoIntouchws
{
    public class GerarTokenServiceTest
    {
        [Fact]
        public void Deve_Retornar_Um_Token()
        {
            var token = new TokenService(new MemoryCache(new MemoryCacheOptions())).GetToken();
            Assert.True(!string.IsNullOrEmpty(token));
        }
    }
}
