using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SE160548.ProductManagement.Repo.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = "",
                int? pageIndex = null,
                int? pageSize = null);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(int id);
    }
}
