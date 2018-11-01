using Application.Domain.Entidades.CotaMais;
using Application.Domain.Interfaces;
using Application.Domain.Interfaces.Infrastructure;
using Application.Domain.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Domain.Service
{
    public class CotaMaisPropostaArquivoService : ICotaMaisPropostaArquivoService
    {
        public IPrevisulUnitOfWork PrevisulUnitOfWork { get; }

        public ILogHelper LogHelper { get; }

        public CotaMaisPropostaArquivoService(
            IPrevisulUnitOfWork previsulUnitOfWork,
            ILogHelper logHelper)
        {
            PrevisulUnitOfWork = previsulUnitOfWork ?? throw new ArgumentNullException(nameof(previsulUnitOfWork));
            LogHelper = logHelper ?? throw new ArgumentNullException(nameof(logHelper));
        }

        public RetornoServicoBase AlocarPropostaEmFila(string codProcessamento)
        {
            try
            {
                PrevisulUnitOfWork.ExeceutarProcedure("exec COTA_MAIS.USP_ALOCAR_FILA_EXECUCAO_PROPOSTA_ARQUIVOS @param1",
                    new SqlParameter("param1", codProcessamento));

                return RetornoServicoBase.SucessoRetorno();
            }
            catch (Exception ex)
            {
                LogHelper.LogError(new LogEventos
                {
                    Excecao = ex,
                    Mensagem = "Erro ao alocar propostas"
                });

                return RetornoServicoBase.RetornoErro(ex.Message, ErroEnum.Excecao);
            }
        }

        public RetornoServico<IEnumerable<PropostaArquivo>> Buscar()
        {
            try
            {
                var colecao = PrevisulUnitOfWork.Repositorio<PropostaArquivo>().Buscar(include => include.Proposta).ToList();

                return RetornoServico<IEnumerable<PropostaArquivo>>.SucessoRetorno(colecao);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(new LogEventos
                {
                    Excecao = ex,
                    Mensagem = "Erro ao buscar propostas arquivo"
                });

                return RetornoServico<IEnumerable<PropostaArquivo>>.RetornoErro(ErroEnum.Excecao, ex.Message);
            }
        }

        public RetornoServico<IQueryable<PropostaArquivo>> Buscar(Expression<Func<PropostaArquivo, bool>> filtroPesquisa)
        {
            var propostas = PrevisulUnitOfWork.Repositorio<PropostaArquivo>().Buscar(include => include.Proposta).Where(filtroPesquisa);

            return RetornoServico<IQueryable<PropostaArquivo>>.SucessoRetorno(propostas);
        }


        public RetornoServico<PropostaArquivo> Atualizar(PropostaArquivo propostaArquivo)
        {
            PrevisulUnitOfWork.Repositorio<PropostaArquivo>().Alterar(propostaArquivo);

            var alteracaoRetorno = PrevisulUnitOfWork.Salvar();

            return alteracaoRetorno.Sucesso ? RetornoServico<PropostaArquivo>.SucessoRetorno(propostaArquivo) : RetornoServico<PropostaArquivo>.RetornoErro(ErroEnum.ErroAtualizacao, alteracaoRetorno.MensagemErro);

        }
    }
}