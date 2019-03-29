using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _contexto;

        protected Repository(DbContext contexto)
        {
            _contexto = contexto;
        }

        public DbContext DbContext
        {
            get { return _contexto; }
        }

        public void Add(TEntity obj)
        {
            DbContext.Set<TEntity>().Add(obj);
            DbContext.SaveChanges();
        }

        public void AddList(IEnumerable<TEntity> lstObj)
        {
            foreach (var obj in lstObj)
            {
                DbContext.Set<TEntity>().Add(obj);
            }
            DbContext.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            DbContext.Set<TEntity>().Remove(obj);
            DbContext.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            var entry = DbContext.Entry(obj);
            DbContext.Set<TEntity>().Attach(obj);
            entry.State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            IQueryable<TEntity> query = DbContext.Set<TEntity>();
            return query.Where(where).FirstOrDefault();
        }
        public IEnumerable<TEntity> GetList()
        {
            return DbContext.Set<TEntity>().ToArray();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where, bool asNoTracking)
        {
            IQueryable<TEntity> query = DbContext.Set<TEntity>();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return query.Where(where).ToArray();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> where)
        {
            return DbContext.Set<TEntity>().Where(where).Any();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where)
        {
            return DbContext.Set<TEntity>().ToArray();
        }
    }
}
