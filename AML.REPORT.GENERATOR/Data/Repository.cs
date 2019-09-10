using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AML.REPORT.GENERATOR.Domain;
using AML.REPORT.GENERATOR.Models;

namespace AML.REPORT.GENERATOR.Data
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DbContext _context;

        protected Repository(DbContext context)
        {
            _context = context;
        }

        public virtual TEntity GetById(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetByAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).SingleOrDefault();
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Added || entry.State == EntityState.Unchanged)
            {
                entry.State = EntityState.Detached;
            }
            //((IObjectContextAdapter)Context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            _context.Set<TEntity>().Attach(entity);
            entry.State = EntityState.Modified;

        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
        public int Complete(out string error)
        {
            error = "";
            try
            {
                return _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                        error += $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}";
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                error = ex.ToString();
            }
            return -99;
        }
    }
}