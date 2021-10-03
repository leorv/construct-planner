using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // TODO: implementar IDisposable no IRepository??
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(long? id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        /* atualizar na memória?
         * na verdade, ele não vai atualizar informações na memória.
         * Ele vai servir apenas para fazer a implementação na classe concreta
         * e atualizar, persistir as informações no banco de dados.
         * Não temos um método save aqui.
         */
        void Update(TEntity entity);
        

    }
}
