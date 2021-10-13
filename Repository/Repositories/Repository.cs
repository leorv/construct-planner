using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        internal DbSet<TEntity> dbset;

        public Repository(DbContext context)
        {
            Context = context;
            dbset = context.Set<TEntity>();
        }        

        public async Task<TEntity> GetAsync(long? id)
        {
            return await dbset.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbset.ToListAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            // TODO: Estudar o funcionamento do método FindAsync do dbset.
            // Assim, verificar se a implementação abaixo seria boa, ou se
            // existe uma maneira melhor de implementar.
            return dbset.Where(predicate);
        }        

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbset.SingleOrDefaultAsync(predicate);
        }

        public async void AddAsync(TEntity entity)
        {
            await dbset.AddAsync(entity);
        }

        public async void AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbset.AddRangeAsync(entities);
        }

        public void Remove(TEntity entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbset.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            dbset.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
