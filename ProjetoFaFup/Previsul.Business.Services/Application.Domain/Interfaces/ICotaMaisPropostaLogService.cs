using Application.Domain.Entidades.CotaMais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Application.Domain.Interfaces
{
    public interface ICotaMaisPropostaLogService
    {
        RetornoServicoBase AlocarPropostaEmFila(string codProcessamento);

        RetornoServico<IEnumerable<CarregarPropostasCotamais>> Buscar();

        RetornoServico<IQueryable<CarregarPropostasCotamais>> Buscar(Expression<Func<CarregarPropostasCotamais, bool>> expression);

        RetornoServico<CarregarPropostasCotamais> Atualizar(CarregarPropostasCotamais propostaLog);
    }
}
