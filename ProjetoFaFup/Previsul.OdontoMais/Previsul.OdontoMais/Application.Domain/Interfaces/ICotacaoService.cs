using System;
using System.Threading.Tasks;
using Application.Domain.Contratos;
using Application.Domain.Entidades;

namespace Application.Domain.Interfaces
{
    public interface ICotacaoService
    {
        Task<RetornoServico<Cotacao>> Buscar(Guid idCotacao);

        Task<RetornoServico<Cotacao>> Adicionar(Cotacao cotacao);

        Task<RetornoServico<Cotacao>> Editar(Cotacao cotacao);

        Task<RetornoServico<Empresa>> EditarDadosEmpresa(Empresa empresa);

        Task<RetornoServico<Proposta>> AdicionarProposta(Proposta proposta);        
    }
}