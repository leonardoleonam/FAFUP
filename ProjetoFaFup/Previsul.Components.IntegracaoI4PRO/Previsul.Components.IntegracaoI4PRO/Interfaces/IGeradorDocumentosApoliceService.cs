using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro
{
    public interface IGeradorDocumentosApoliceService
    {
        RetornoServico<I4ProGeradorDocumentosApoliceRetorno> GerarDocumentosApolice(string codigoApolice, string base64, string nomeDocumento);
    }
}
