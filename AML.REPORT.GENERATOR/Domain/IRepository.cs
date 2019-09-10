using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AML.REPORT.GENERATOR.Domain
{
        public interface IRepository<TEntity, in TKey> where TEntity : class
        {
            TEntity GetById(TKey id);

            IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
            IQueryable<TEntity> GetByAll();

            IEnumerable<TEntity> GetAll();

            IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

            TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

            TEntity Add(TEntity entity);

            void AddRange(IEnumerable<TEntity> entities);

            void Remove(TEntity entity);

            void Update(TEntity entity);

            void RemoveRange(IEnumerable<TEntity> entities);

            int Complete(out string error);
        }
}