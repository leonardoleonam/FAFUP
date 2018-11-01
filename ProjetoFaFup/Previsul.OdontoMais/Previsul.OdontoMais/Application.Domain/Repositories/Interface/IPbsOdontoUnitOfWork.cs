using System.Threading.Tasks;

namespace Application.Domain.Repositories.Interface
{
    public interface IPbsOdontoUnitOfWork
    {
        IRepositorioGenerico<TEntidade> Repositorio<TEntidade>()
            where TEntidade : class;

        Task<ResultadoOperacao> SalvarAsync();

        ResultadoOperacao Salvar();
    }
}
