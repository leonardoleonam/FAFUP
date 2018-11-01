using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro
{
    public interface IEmissorApoliceService
    {
        RetornoServico<I4ProEmissaoApoliceRetorno> EmitirApolice(string apoliceJson);
    }
}