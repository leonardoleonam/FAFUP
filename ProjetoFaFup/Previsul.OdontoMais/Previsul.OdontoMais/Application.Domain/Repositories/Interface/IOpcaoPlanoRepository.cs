using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Domain.Contratos;

namespace Application.Domain.Repositories.Interface
{
    public interface IOpcaoPlanoRepository
    {
        Task<RetornoServico<IEnumerable<PlanoOpcao>>> ListarOpcoesPlanos();
    }
}