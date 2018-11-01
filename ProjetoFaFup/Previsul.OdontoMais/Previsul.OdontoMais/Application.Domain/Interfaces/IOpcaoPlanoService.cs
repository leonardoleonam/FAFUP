using Application.Domain.Contratos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Domain.Interfaces
{
    public interface IOpcaoPlanoService
    {
        Task<RetornoServico<IEnumerable<PlanoOpcao>>> ListarOpcoesPlanos();
    }
}