using SE160548.ProductManagement.Repo.GenericRepository;
using SE160548.ProductManagement.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE160548.ProductManagement.Repo.UnitOfwork
{
    public class UnitOfwork : IDisposable, IUnitOfwork
    {

        private IGenericRepository<Product> productRepo;
        private IGenericRepository<Category> categoryRepo;
        private IGenericRepository<Member> memberRepo;
        private IGenericRepository<Order> orderRepo;
        private IGenericRepository<OrderDetail> orderDetailRepo;
        private readonly FStoreDBContext context;
        private bool dispose = false;

        public UnitOfwork(FStoreDBContext context)
        {
            this.context = context;
        }

        public IGenericRepository<Product> ProductRepo
        {
            get
            {
                if (productRepo == null)
                {
                    productRepo = new GenericRepository<Product>(context);
                }
                return productRepo;

            }
            set => throw new NotImplementedException();
        }
        public IGenericRepository<Category> CategoryRepo
        {
            get
            {
                if (categoryRepo == null)
                {
                    categoryRepo = new GenericRepository<Category>(context);
                }
                return categoryRepo;

            }
            set => throw new NotImplementedException();
        }
        public IGenericRepository<Member> MemberRepo
        {
            get
            {
                if (memberRepo == null)
                {
                    memberRepo = new GenericRepository<Member>(context);
                }
                return memberRepo;

            }
            set => throw new NotImplementedException();
        }
        public IGenericRepository<Order> OrderRepo
        {
            get
            {
                if (orderRepo == null)
                {
                    orderRepo = new GenericRepository<Order>(context);
                }
                return orderRepo;

            }
            set => throw new NotImplementedException();
        }
        public IGenericRepository<OrderDetail> OrderDetailRepo
        {
            get
            {
                if (orderDetailRepo == null)
                {
                    orderDetailRepo = new GenericRepository<OrderDetail>(context);
                }
                return orderDetailRepo;

            }
            set => throw new NotImplementedException();
        }
        protected virtual void Dispose(bool dispose)
        {
            if (!dispose)
            {
                if (dispose)
                {
                    context.Dispose();

                }
                dispose = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

}
