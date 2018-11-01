using Application.Domain.Entidades.CotaMais;
using Application.Domain.Interfaces;
using Application.Domain.Interfaces.Infrastructure;
using Application.Domain.Repositories.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Domain.Service
{
    public class CotaMaisPropostaService : ICotaMaisPropostaService
    {
        public IPrevisulUnitOfWork PrevisulUnitOfWork { get; }

        public ILogHelper LogHelper { get; }

        public CotaMaisPropostaService(
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
                PrevisulUnitOfWork.ExeceutarProcedure("exec COTA_MAIS.USP_ALOCAR_FILA_EXECUCAO_PROPOSTAS @param1",
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

        public RetornoServico<IEnumerable<Proposta>> Buscar()
        {
            try
            {
                var propostas = PrevisulUnitOfWork.Repositorio<Proposta>()
                       .Buscar(
                            include => include.PropostaGarantias,
                            include => include.PropostaJson
                        ).ToList();

                return RetornoServico<IEnumerable<Proposta>>.SucessoRetorno(propostas);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(new LogEventos
                {
                    Excecao = ex,
                    Mensagem = "Erro ao buscar propostas arquivo"
                });

                return RetornoServico<IEnumerable<Proposta>>.RetornoErro(ErroEnum.Excecao, ex.Message);
            }
        }

        public RetornoServico<IEnumerable<Proposta>> Buscar(Expression<Func<Proposta, bool>> filtroPesquisa)
        {
            var propostas = PrevisulUnitOfWork.Repositorio<Proposta>().Buscar(filtroPesquisa, 
                include => include.PropostaGarantias,include => include.Produto).ToList();

            return RetornoServico<IEnumerable<Proposta>>.SucessoRetorno(propostas);
        }

        public RetornoServico<string> GerarProposta(int idProposta)
        {
            try
            {
                SqlParameter[] parametros =
                {
                    new SqlParameter("@JSON_RESULT", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output },
                    new SqlParameter("@ID_PROPOSTA", idProposta)
                };

                PrevisulUnitOfWork.ExeceutarProcedure("exec COTA_MAIS.USP_JSON_PROPOSTA @ID_PROPOSTA, @JSON_RESULT OUTPUT", parametros);

                var propostaJson = parametros[0].Value?.ToString() ?? string.Empty;

                return RetornoServico<string>.SucessoRetorno(propostaJson);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(new LogEventos
                {
                    Excecao = ex,
                    Mensagem = "Erro ao gerar propostas"
                });

                return RetornoServico<string>.RetornoErro(ErroEnum.Excecao, ex.Message);
            }
        }

        public RetornoServico<Proposta> Atualizar(Proposta proposta)
        {
            PrevisulUnitOfWork.Repositorio<Proposta>().Alterar(proposta);

            var alteracaoRetorno = PrevisulUnitOfWork.Salvar();

            return alteracaoRetorno.Sucesso ? RetornoServico<Proposta>.SucessoRetorno(proposta) : RetornoServico<Proposta>.RetornoErro(ErroEnum.ErroAtualizacao, alteracaoRetorno.MensagemErro);
        }
    }
}
