using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Joole.Repository.Repositories
{
    public interface IRepsitory<TEntity> where TEntity : class {
        TEntity GetByID(int id);
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);

        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);


        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }

    public class BaseRepositroy<TEntity> : IRepsitory<TEntity> where TEntity : class{

        protected readonly DbContext Context;

        public BaseRepositroy(DbContext context) {
            Context = context;
        }

        public TEntity GetByID(int id) {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll() {
            return Context.Set<TEntity>().ToList();
        }

        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Delete(TEntity entity ){
            Context.Set<TEntity>().Remove(entity); 
        }

        public void DeleteRange(IEnumerable<TEntity> entities) {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        void IRepsitory<TEntity>.Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        void IRepsitory<TEntity>.InsertRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }
    }
}
