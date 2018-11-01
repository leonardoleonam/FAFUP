using Previsul.Components.IntegracaoOdonto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Interface
{
    interface IObterArquivoPropostaService
    {
        ArquivoPropostaRetorno Obter(Dictionary<string, string> numeroProposta, bool isProduction);
    }
}
