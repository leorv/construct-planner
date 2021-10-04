using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public TEntity Get(long? id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbset.Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbset.ToList();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return dbset.SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            dbset.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbset.AddRange(entities);
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
