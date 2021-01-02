using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Repository.Repositories
{
    public interface IRepsitory<TEntity> where TEntity : class {
        TEntity GetByID(int id);
        IEnumerable<TEntity> GetAll();

        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);


        void Delete(TEntity entitry);
        void DeleteRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

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

        void IRepsitory<TEntity>.Update(TEntity entity)
        { 

            // base on business logic

        }
    }
}
