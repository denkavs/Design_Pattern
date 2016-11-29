using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.UnitOfWork
{
    public class GenericRepository<TEntity> where TEntity : BaseEntity
    {
        internal SchoolContext context;
        internal List<BaseEntity> dbSet;

        public GenericRepository(SchoolContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<BaseEntity> Get( Expression<Func<BaseEntity, bool>> filter = null, Func<IQueryable<BaseEntity>, IOrderedQueryable<BaseEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<BaseEntity> query = dbSet.AsQueryable<BaseEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual BaseEntity GetByID(int id)
        {
            return dbSet.Find(s=> ((BaseEntity)s).ID == id);
        }

        public virtual void Insert(TEntity entity)
        {
            entity.ID = dbSet.Count + 1;
            dbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            BaseEntity entityToDelete = dbSet.Find(s => ((BaseEntity)s).ID == id);
            Delete(entityToDelete);
        }

        public virtual void Delete(BaseEntity entityToDelete)
        {
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(BaseEntity entityToUpdate)
        {
            BaseEntity dest = dbSet.Find(s => ((BaseEntity)s).ID == ((BaseEntity)entityToUpdate).ID);
            if(dest != null)
            {
                dest.Update(entityToUpdate);
            }
        }
    }
}
