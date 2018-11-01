using Application.Domain.Entidades.CotaMais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Domain.Interfaces
{
    public interface ICotaMaisPropostaArquivoService
    {
        RetornoServicoBase AlocarPropostaEmFila(string codProcessamento);

        RetornoServico<IEnumerable<PropostaArquivo>> Buscar();
        
        RetornoServico<IQueryable<PropostaArquivo>> Buscar(Expression<Func<PropostaArquivo, bool>> expression);

        RetornoServico<PropostaArquivo> Atualizar(PropostaArquivo propostaArquivo);
    }
}