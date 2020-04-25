using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGA.ApplicationCore.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class // restrição do tipo generico...* TEntity.. você que escolhe
    {/* Ler mais sobre interfaces genericas */
        TEntity Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        IEnumerable<TEntity> ObterTodos();
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado);
        void Remover(TEntity entity);
    }
}
