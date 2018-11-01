using System.Threading.Tasks;

namespace Application.Domain.Repositories.Interface
{
    public interface IPrevisulUnitOfWork
    {
        IRepositorioGenerico<TEntidade> Repositorio<TEntidade>()
            where TEntidade : class;

        void ExeceutarProcedure(string procedure, params object[] parametros);

        Task<ResultadoOperacao> SalvarAsync();

        ResultadoOperacao Salvar();
    }
}
