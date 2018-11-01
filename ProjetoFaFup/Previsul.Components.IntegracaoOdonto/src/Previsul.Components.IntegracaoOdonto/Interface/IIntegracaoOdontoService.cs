using Previsul.Components.IntegracaoOdonto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Interface
{
    public interface IIntegracaoOdontoService
    {
        PlanosRetorno ListarPlanos();

        ProspectoRetorno IncluirProspecto(Prospecto Prospecto);

        DetalheProspectoRetorno DetalharProspecto(Dictionary<string, string> prospectoRequisicao);

        DiasVencimentoFaturaRetorno ListarDiasVencimentoFatura();

        OpcoesComissaoCorretorRetorno ListarOpcoesComissaoCorretor();

        ValorPlanoRetorno ObterValorPlano(Dictionary<string, string> valorPlanoRequisicao);

        LiConcordoRetorno ObterLiConcordo();

        ProspectoPesquisaRetorno PesquisarProspecto(ProspectoPesquisa prospectoPesquisa);

        ArquivoPropostaRetorno ObterArquivo(Dictionary<string, string> numeroProposta);

        ProspectoAlteracaoRetorno Alterar(ProspectoAlteracao prospectoAlteracao);
    }
}
