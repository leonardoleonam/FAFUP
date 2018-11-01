using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro
{
    public interface IEmissaoApoliceService
    {
        RetornoServico<I4ProEmissaoApoliceRetorno> EmitirApolice(string apoliceJson);
    }
}