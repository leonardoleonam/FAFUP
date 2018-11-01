using Application.Domain;
using Application.Domain.Entidades.Ods;
using Application.Domain.Interfaces.Infrastructure.Integrations.OdsPrevisul;
using Application.Domain.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Integration.OdsPrevisul
{
    public class CorretorService : ICorretorService
    {
        public IPrevisulOdsUnitOfWork PrevisulOdsUnitOfWork { get; }

        public CorretorService(IPrevisulOdsUnitOfWork previsulOdsUnitOfWork)
        {
            PrevisulOdsUnitOfWork = previsulOdsUnitOfWork ?? throw new ArgumentNullException(nameof(previsulOdsUnitOfWork));            
        }        

        public IQueryable<Corretor> Buscar()
        {
            var corretores = PrevisulOdsUnitOfWork.Repositorio<Corretor>().Buscar();

            return corretores;
        }
    }
}
