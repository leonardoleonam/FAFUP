using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Domain.Contratos;

namespace Application.Domain.Repositories.Interface
{
    public interface IOpcaoPlanoValorRepository
    {
        Task<RetornoServico<ValorPlanoVida>> ObterPorComboPlanos(List<ValorPlanoVidaRequisicao> planosVida);
    }
}