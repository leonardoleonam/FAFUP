using Application.Domain;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoI4PRO.Interfaces
{
    public interface IIntegracaoI4ProService
    {
        RetornoServico<I4ProToken> BuscarTokenAcesso();
    }
}
