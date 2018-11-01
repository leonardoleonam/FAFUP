using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro
{
    public interface IAutenticadorTokenService
    {
        RetornoServico<I4ProToken> BuscarTokenAcesso();

        void LimparToken();
    }
}
