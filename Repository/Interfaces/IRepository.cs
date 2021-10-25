using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    // TODO: implementar IDisposable no IRepository?? Macoratti deixou sem.
    public interface IRepository<TEntity> /*: IDisposable*/ where TEntity : class
    {
        Task<TEntity> GetAsync(long? id);
        TEntity Get(long? id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void AddAsync(TEntity entity);
        void AddRangeAsync(IEnumerable<TEntity> entities);

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
