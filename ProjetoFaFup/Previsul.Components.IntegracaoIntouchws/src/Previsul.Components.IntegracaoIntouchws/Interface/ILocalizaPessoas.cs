using Previsul.Components.IntegracaoIntouchws.Model;

namespace Previsul.Components.IntegracaoIntouchws.Interface
{
    interface ILocalizaPessoas
    {
        LocalizaPessoas LocalizarPessoas(string CPFouCNPJ, string TipoPessoa);
    }
}
