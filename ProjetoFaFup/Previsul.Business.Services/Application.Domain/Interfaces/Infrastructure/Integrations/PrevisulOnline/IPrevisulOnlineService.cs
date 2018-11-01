using Application.Domain.Interfaces.Infrastructure.Integrations.PrevisulOnline.Contratos;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.PrevisulOnline
{
    public interface IPrevisulOnlineService
    {
        RetornoServico<PrevisulOnlineGeradorDocumentoRetorno> Gerar(string tipoDocumento, int protocolo, int ano);
    }
}
