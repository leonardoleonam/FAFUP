using Application.Domain.Contratos;
using Application.Domain.Entidades;
using Application.Domain.Interfaces;
using Application.Domain.Repositories.Interface;
using System;
using System.Threading.Tasks;

namespace Application.Domain.Services
{
    public class CotacaoService : ICotacaoService
    {
        public IPbsOdontoUnitOfWork PbsOdontoUnitOfWork { get; }

        public CotacaoService(IPbsOdontoUnitOfWork pbsOdontoUnitOfWork)
        {
            PbsOdontoUnitOfWork = pbsOdontoUnitOfWork ?? throw new ArgumentNullException(nameof(pbsOdontoUnitOfWork));
        }

        public async Task<RetornoServico<Cotacao>> Buscar(Guid guidCotacao)
        {
            var cotacao = await PbsOdontoUnitOfWork.Repositorio<Cotacao>().BuscarUnicoPor(x => x.Guid == guidCotacao);

            return cotacao == null ? RetornoServico<Cotacao>.RetornoErro(ErroEnum.RecursoNaoEncontrado, "Cotação não encontrado") : RetornoServico<Cotacao>.SucessoRetorno(cotacao);
        }

        public async Task<RetornoServico<Cotacao>> Adicionar(Cotacao cotacao)
        {
            PbsOdontoUnitOfWork.Repositorio<Cotacao>().Adicionar(cotacao);

            var resultado = await PbsOdontoUnitOfWork.SalvarAsync();

            return resultado.Sucesso
                ? RetornoServico<Cotacao>.SucessoRetorno(cotacao)
                : RetornoServico<Cotacao>.RetornoErro(ErroEnum.ErroCriacao, "Ocorreu um erro ao criar a cotação.");
        }

        public async Task<RetornoServico<Cotacao>> Editar(Cotacao cotacao)
        {
            PbsOdontoUnitOfWork.Repositorio<Cotacao>().Alterar(cotacao);

            var resultado = PbsOdontoUnitOfWork.Salvar();

            return resultado.Sucesso
                ? RetornoServico<Cotacao>.SucessoRetorno(cotacao)
                : RetornoServico<Cotacao>.RetornoErro(ErroEnum.ErroAtualizacao, "Ocorreu um erro ao editar a cotação.");
        }

        public async Task<RetornoServico<Empresa>> EditarDadosEmpresa(Empresa empresa)
        {
            PbsOdontoUnitOfWork.Repositorio<Empresa>().Alterar(empresa);

            var resultado =  PbsOdontoUnitOfWork.Salvar();

            return resultado.Sucesso
                ? RetornoServico<Empresa>.SucessoRetorno(empresa)
                : RetornoServico<Empresa>.RetornoErro(ErroEnum.ErroAtualizacao, "Ocorreu um erro ao editar dados da empresa.");
        }

        public async Task<RetornoServico<Proposta>> AdicionarProposta(Proposta proposta)
        {
            PbsOdontoUnitOfWork.Repositorio<Proposta>().Adicionar(proposta);

            var resultado = await PbsOdontoUnitOfWork.SalvarAsync();

            return resultado.Sucesso
                ? RetornoServico<Proposta>.SucessoRetorno(proposta)
                : RetornoServico<Proposta>.RetornoErro(ErroEnum.ErroCriacao, "Ocorreu um erro ao criar a proposta.");
        }        
    }
}
