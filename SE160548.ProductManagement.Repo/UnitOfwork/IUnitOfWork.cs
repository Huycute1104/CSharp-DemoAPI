using SE160548.ProductManagement.Repo.GenericRepository;
using SE160548.ProductManagement.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE160548.ProductManagement.Repo.UnitOfwork
{
    public interface IUnitOfwork : IDisposable
    {
        IGenericRepository<Product> ProductRepo { get; set; }
        IGenericRepository<Category> CategoryRepo { get; set; }
        IGenericRepository<Member> MemberRepo { get; set; }
        IGenericRepository<Order> OrderRepo { get; set; }
        IGenericRepository<OrderDetail> OrderDetailRepo { get; set; }

        void Save();
    }

}
