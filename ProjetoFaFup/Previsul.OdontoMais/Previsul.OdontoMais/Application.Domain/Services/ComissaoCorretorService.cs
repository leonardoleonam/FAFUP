using Application.Domain.Contratos;
using Application.Domain.Interfaces;
using Application.Domain.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Services
{
    public class ComissaoCorretorService : IComissaoCorretorService
    {

        public IPbsOdontoUnitOfWork PbsOdontoUnitOfWork { get; }

        public ComissaoCorretorService(IPbsOdontoUnitOfWork pbsOdontoUnitOfWork)
        {
            PbsOdontoUnitOfWork = pbsOdontoUnitOfWork ?? throw new ArgumentNullException(nameof(pbsOdontoUnitOfWork));
        }

        public Task<RetornoServico<ProspectoContratoComissaoOpcao>> ListarOpcoesComissaoCorretor()
        {
            throw new NotImplementedException();
        }

        //public async Task<RetornoServico<ProspectoContratoComissaoOpcao>> ListarOpcoesComissaoCorretor()
        //{
        //    var retorno = await PbsOdontoUnitOfWork.Repositorio<ProspectoContratoComissaoOpcao>().BuscarTodos();

        //    //return retorno == null ? RetornoServico<ProspectoContratoComissaoOpcao>.RetornoErro(ErroEnum.RecursoNaoEncontrado, "Prospecto Contrato Comissões não encontrado") : RetornoServico<ProspectoContratoComissaoOpcao>.SucessoRetorno(retorno);

        //    return new ProspectoContratoComissaoOpcao();
        //}
    }
}
