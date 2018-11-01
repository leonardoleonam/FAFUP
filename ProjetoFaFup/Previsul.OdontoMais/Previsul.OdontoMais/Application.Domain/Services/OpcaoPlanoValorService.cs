using Application.Domain.Contratos;
using Application.Domain.Entidades;
using Application.Domain.Interfaces;
using Application.Domain.Interfaces.Infrastructure;
using Application.Domain.Repositories.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Domain.Services
{
    public class OpcaoPlanoValorService : IOpcaoPlanoValorService
    {
        public IOpcaoPlanoValorRepository OpcaoPlanoValorRepository { get; }

        public ICotacaoService CotacaoService { get; }

        public ILogHelper LogHelper { get; }

        public OpcaoPlanoValorService(
            IOpcaoPlanoValorRepository opcaoPlanoRepository, 
            ICotacaoService cotacaoService, 
            ILogHelper logHelper)
        {
            OpcaoPlanoValorRepository = opcaoPlanoRepository ?? throw new ArgumentNullException(nameof(opcaoPlanoRepository));
            CotacaoService = cotacaoService ?? throw new ArgumentNullException(nameof(cotacaoService));
            LogHelper = logHelper ?? throw new ArgumentNullException(nameof(logHelper));
        }
        
        public async Task<RetornoServico<ValorPlanoVida>> ObterValorComboPlano(
            Guid idCotacao, 
            List<ValorPlanoVidaRequisicao> planosVida)
        {
            var valorPlanoRetornoServico = await OpcaoPlanoValorRepository.ObterPorComboPlanos(planosVida);

            if (valorPlanoRetornoServico.Sucesso == false) return valorPlanoRetornoServico; 

            await AtualizarCotacaoComPlanos(idCotacao, planosVida, valorPlanoRetornoServico.ObjetoRetorno.ValorTotal1Ano);
                
            return valorPlanoRetornoServico;
        }

        private async Task AtualizarCotacaoComPlanos(
            Guid idCotacao,
            List<ValorPlanoVidaRequisicao> planosVida, 
            double valorTotalCotacao)
        {
            try
            {
                var cotacaoRetornoServico = await CotacaoService.Buscar(idCotacao);

                if (cotacaoRetornoServico.Sucesso)
                {
                    var cotacao = cotacaoRetornoServico.ObjetoRetorno;

                    cotacao.AdicionarHistorico();

                    var detalheCotacao = cotacao.DetalheCotacao;
                    detalheCotacao.Planos = new List<Planos>();

                    foreach (var plano in planosVida)
                    {
                        //detalheCotacao.Planos.Add(new Planos
                        //{
                        //    IdPlano = plano.IdPlano,
                        //    QtdadeVidas = plano.QuantidadeVida
                        //});
                    }
                    detalheCotacao.ValorCotacao = valorTotalCotacao;

                    cotacao.Json = JsonConvert.SerializeObject(detalheCotacao);

                    var atualizarCotacaoRetorno = await CotacaoService.Editar(cotacao);

                    if (atualizarCotacaoRetorno.Sucesso == false)
                    {
                        LogHelper.LogWarning(new LogEventos
                        {
                            Mensagem = $"{atualizarCotacaoRetorno.ErrosSerialized} : Método: ObterValorComboPlano",
                            RequisicaoId = idCotacao
                        });
                    }
                }
                else
                {
                    LogHelper.LogWarning(new LogEventos
                    {
                        Mensagem = $"{cotacaoRetornoServico.ErrosSerialized} : Método: ObterValorComboPlano",
                        RequisicaoId = idCotacao
                    });
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogWarning(new LogEventos
                {
                    Mensagem = "Ocorreu um erro ao atualizar os planos da cotação",
                    RequisicaoId = idCotacao,
                    Excecao = ex
                });
            }
        }
    }
}