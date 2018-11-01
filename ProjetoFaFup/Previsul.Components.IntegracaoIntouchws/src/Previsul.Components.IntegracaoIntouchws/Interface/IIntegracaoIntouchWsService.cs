using Previsul.Components.IntegracaoIntouchws.Model;

namespace Previsul.Components.IntegracaoIntouchws.Interface
{
    public interface IIntegracaoIntouchWsService
    {
        LocalizaPessoas LocalizarPessoas(string CPFouCNPJ, string TipoPessoa);
    }
}
