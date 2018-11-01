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
    public class CotaMaisPropostaLogService : ICotaMaisPropostaLogService
    {
        public IPrevisulUnitOfWork PrevisulUnitOfWork { get; }

        public ILogHelper LogHelper { get; }

        public CotaMaisPropostaLogService(
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
                PrevisulUnitOfWork.ExeceutarProcedure("exec LOG.USP_ALOCAR_FILA_EXECUCAO_PROPOSTA_LOGS @param1",
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

        public RetornoServico<IEnumerable<CarregarPropostasCotamais>> Buscar()
        {
            try
            {
                var colecao = PrevisulUnitOfWork.Repositorio<CarregarPropostasCotamais>().Buscar().ToList();

                return RetornoServico<IEnumerable<CarregarPropostasCotamais>>.SucessoRetorno(colecao);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(new LogEventos
                {
                    Excecao = ex,
                    Mensagem = "Erro ao buscar propostas arquivo"
                });

                return RetornoServico<IEnumerable<CarregarPropostasCotamais>>.RetornoErro(ErroEnum.Excecao, ex.Message);
            }
        }

        public RetornoServico<IQueryable<CarregarPropostasCotamais>> Buscar(Expression<Func<CarregarPropostasCotamais, bool>> filtroPesquisa)
        {
            var propostas = PrevisulUnitOfWork.Repositorio<CarregarPropostasCotamais>().Buscar(filtroPesquisa);

            return RetornoServico<IQueryable<CarregarPropostasCotamais>>.SucessoRetorno(propostas);
        }


        public RetornoServico<CarregarPropostasCotamais> Atualizar(CarregarPropostasCotamais propostaLog)
        {
            PrevisulUnitOfWork.Repositorio<CarregarPropostasCotamais>().Alterar(propostaLog);

            var alteracaoRetorno = PrevisulUnitOfWork.Salvar();

            return alteracaoRetorno.Sucesso ? RetornoServico<CarregarPropostasCotamais>.SucessoRetorno(propostaLog) : RetornoServico<CarregarPropostasCotamais>.RetornoErro(ErroEnum.ErroAtualizacao, alteracaoRetorno.MensagemErro);

        }
    }
}