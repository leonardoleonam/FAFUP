using System.Collections.Generic;
using Application.Domain.Entidades.CotaMais;

namespace Application.Domain.Interfaces
{
    public interface ICotaMaisEmissaoApoliceService
    {
        RetornoServicoBase EmitirApolice(List<Proposta> propostas);
    }
}