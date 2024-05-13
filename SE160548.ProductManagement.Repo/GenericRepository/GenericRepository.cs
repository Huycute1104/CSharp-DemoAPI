using Microsoft.EntityFrameworkCore;
using SE160548.ProductManagement.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SE160548.ProductManagement.Repo.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FStoreDBContext dbContext;
        private readonly DbSet<T> dbSet;

        public GenericRepository(FStoreDBContext dBContext)
        {
            this.dbContext = dBContext;
            this.dbSet = dbContext.Set<T>(); 


        }
        void IGenericRepository<T>.Add(T item)
        {
            dbSet.Add(item);
            dbContext.SaveChanges();
        }

        void IGenericRepository<T>.Delete(T item)
        {
            dbSet.Remove(item);
            dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int? pageIndex = null, int? pageSize = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10;

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            return query.ToList();
        }

        T IGenericRepository<T>.GetById(int id)
        {
            T item = dbSet.Find(id);
            return item;
        }

        void IGenericRepository<T>.Update(T item)
        {
            dbSet.Update(item);
            dbContext.SaveChanges();
        }
    }
}
