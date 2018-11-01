using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Domain.Contratos;

namespace Application.Domain.Interfaces
{
    public interface IOpcaoPlanoValorService
    {
        Task<RetornoServico<ValorPlanoVida>> ObterValorComboPlano(Guid idCotacao, List<ValorPlanoVidaRequisicao> planosVida);
    }
}