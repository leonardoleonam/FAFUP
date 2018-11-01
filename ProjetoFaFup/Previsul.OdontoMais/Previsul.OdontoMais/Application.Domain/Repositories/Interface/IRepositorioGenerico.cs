using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.Interface
{
    public interface IRepositorioGenerico<TEntidade>
        where TEntidade : class
    {
        IQueryable<TEntidade> Buscar();

        IQueryable<TEntidade> Buscar(params Expression<Func<TEntidade, object>>[] includes);

        IQueryable<TEntidade> Buscar(bool tracking);

        IQueryable<TEntidade> Buscar(bool tracking, params Expression<Func<TEntidade, object>>[] includes);

        Task<IEnumerable<TEntidade>> BuscarTodos();

        Task<IEnumerable<TEntidade>> BuscarPor(Expression<Func<TEntidade, bool>> filtro);

        Task<TEntidade> BuscarUnicoPor(Expression<Func<TEntidade, bool>> filtro);

        void Adicionar(TEntidade entidade);

        void Alterar(TEntidade entidade);

        void Excluir(TEntidade entidade);
    }
}