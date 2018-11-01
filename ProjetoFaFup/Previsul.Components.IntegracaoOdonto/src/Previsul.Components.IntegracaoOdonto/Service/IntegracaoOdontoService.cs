using Previsul.Components.IntegracaoOdonto.Interface;
using Previsul.Components.IntegracaoOdonto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Service
{
    public class IntegracaoOdontoService : IIntegracaoOdontoService
    {
        IPlanoService PlanoService;
        IProspectoService ProspectoService;
        IDiasVencimentoFaturaService DiasVencimentoFaturaService;
        IComissaoCorretorService ComissaoCorretorService;
        ILiConcordoService LiConcordoService;
        IValorPlanoService ValorPlanoService;
        IDetalheProspectoService DetalheProspectoService;
        IPesquisaProspectoService PesquisaProspectoService;
        IObterArquivoPropostaService ObterArquivoPropostaService;
        IAlteracaoProspectoService AlteracaoProspectoService;

        public bool IsProduction { get; set; } = false;

        public IntegracaoOdontoService()
        {
            PlanoService = new PlanoService();
            ProspectoService = new ProspectoService();
            DiasVencimentoFaturaService = new DiasVencimentoFaturaService();
            ComissaoCorretorService = new ComissaoCorretorService();
            LiConcordoService = new LiConcordoService();
            ValorPlanoService = new ValorPlanoService();
            DetalheProspectoService = new DetalheProspectoService();
            PesquisaProspectoService = new PesquisaProspectoService();
            ObterArquivoPropostaService = new ObterArquivoPropostaService();
            AlteracaoProspectoService = new AlteracaoProspectoService();
            
    }

        public PlanosRetorno ListarPlanos()
        {
            return PlanoService.ListarPlanos(IsProduction);
        }

        public ProspectoRetorno IncluirProspecto(Prospecto Prospecto)
        {
            return ProspectoService.IncluirProspecto(Prospecto, IsProduction);
        }

        public DiasVencimentoFaturaRetorno ListarDiasVencimentoFatura()
        {
            return DiasVencimentoFaturaService.ListarDiasVencimentoFatura(IsProduction);
        }

        public OpcoesComissaoCorretorRetorno ListarOpcoesComissaoCorretor()
        {
            return ComissaoCorretorService.ListarOpcoesComissaoCorretor(IsProduction);
        }

        public ValorPlanoRetorno ObterValorPlano(Dictionary<string, string> valorPlanoRequisicao)
        {
            return ValorPlanoService.ObterValorPlano(valorPlanoRequisicao, IsProduction);
        }

        public LiConcordoRetorno ObterLiConcordo()
        {
            return LiConcordoService.ObterLiConcordo(IsProduction);
        }

        public DetalheProspectoRetorno DetalharProspecto(Dictionary<string, string> prospectoRequisicao)
        {
            return DetalheProspectoService.Detalhar(prospectoRequisicao, IsProduction);            
        }

        public ProspectoPesquisaRetorno PesquisarProspecto(ProspectoPesquisa prospectoPesquisa)
        {
            return PesquisaProspectoService.Pesquisar(prospectoPesquisa, IsProduction);
        }

        public ArquivoPropostaRetorno ObterArquivo(Dictionary<string, string> numeroProposta)
        {
            return ObterArquivoPropostaService.Obter(numeroProposta, IsProduction);
        }

        public ProspectoAlteracaoRetorno Alterar(ProspectoAlteracao prospectoAlteracao)
        {
            return AlteracaoProspectoService.Alterar(prospectoAlteracao, IsProduction);
        }

    }
}
