using System;
using Application.Domain.Entidades.CotaMais;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Domain.Interfaces
{
    public interface ICotaMaisPropostaService
    {
        RetornoServicoBase AlocarPropostaEmFila(string codProcessamento);

        RetornoServico<IEnumerable<Proposta>> Buscar();

        RetornoServico<IEnumerable<Proposta>> Buscar(Expression<Func<Proposta, bool>> expression);

        RetornoServico<string> GerarProposta(int idProposta);

        RetornoServico<Proposta> Atualizar(Proposta proposta);
    }
}
