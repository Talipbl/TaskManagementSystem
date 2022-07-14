using DataAccess.Abstracts;
using Entity.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFrameworks
{
    public class EfEntityRepositoryDal<TEntity, TContext> : IEntityRepositoryDal<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public bool Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry<TEntity>(entity).State = EntityState.Added;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry<TEntity>(entity).State = EntityState.Deleted;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public bool Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry<TEntity>(entity).State = EntityState.Modified;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
