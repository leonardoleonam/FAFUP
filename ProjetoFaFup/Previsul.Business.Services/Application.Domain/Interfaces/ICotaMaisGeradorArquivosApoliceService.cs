using System.Collections.Generic;
using Application.Domain.Entidades.CotaMais;

namespace Application.Domain.Interfaces
{
    public interface ICotaMaisGeradorArquivosApoliceService
    {
        RetornoServicoBase GerarArquivosApolice(List<PropostaArquivo> propostas);
    }
}