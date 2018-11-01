using Application.Domain.Entidades.Ods;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.OdsPrevisul
{
    public interface ICorretorService
    {        

        IQueryable<Corretor> Buscar();
    }
}
