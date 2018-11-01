using Application.Domain.Contratos;
using Application.Domain.Interfaces;
using Application.Domain.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Domain.Services
{
    public class OpcaoPlanoService : IOpcaoPlanoService
    {
        public IOpcaoPlanoRepository OpcaoPlanoRepository { get; }

        public OpcaoPlanoService(IOpcaoPlanoRepository opcaoPlanoRepository)
        {
            OpcaoPlanoRepository = opcaoPlanoRepository ?? throw new ArgumentNullException(nameof(opcaoPlanoRepository));
        }

        public async Task<RetornoServico<IEnumerable<PlanoOpcao>>> ListarOpcoesPlanos()
        {
            return await OpcaoPlanoRepository.ListarOpcoesPlanos();
        }
    }
}