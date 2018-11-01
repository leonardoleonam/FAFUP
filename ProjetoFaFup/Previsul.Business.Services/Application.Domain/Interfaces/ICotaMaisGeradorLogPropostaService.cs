using Application.Domain.Entidades.CotaMais;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.Interfacesl
{
    public interface ICotaMaisGeradorLogPropostaService
    {
        RetornoServicoBase GerarLogsProposta(List<CarregarPropostasCotamais> propostas);
    }
}
