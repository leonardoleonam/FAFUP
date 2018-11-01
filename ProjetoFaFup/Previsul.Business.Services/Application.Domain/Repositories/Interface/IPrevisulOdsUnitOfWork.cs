namespace Application.Domain.Repositories.Interface
{
    public interface IPrevisulOdsUnitOfWork
    {
        IRepositorioGenerico<TEntidade> Repositorio<TEntidade>()
           where TEntidade : class;         
    }
}
