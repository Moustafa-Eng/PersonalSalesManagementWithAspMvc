using MotoFix.BLL.Interfaces;
using MotoFix.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoFix.BLL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _dbContext;

        public IProductRepository ProductRepository { get; set; }
        public ISaleRepository SaleRepository { get; set; }

        public ICategoryRepository CategoryRepository { get; set; }
        public ISaleItemRepository SaleItemRepository { get; set; }
        public ICustomerAccountRepository CustomerAccountRepository { get; set; }
        public ISupplierRepository SupplierRepository { get; set; }

		public UnitOfWork(ApplicationDbContext dbContext)
        {
			ProductRepository = new ProductRepository(dbContext);
			SaleRepository = new SaleRepository(dbContext);
			CategoryRepository = new CategoryRepository(dbContext);
			SaleItemRepository = new SaleItemRepository(dbContext);
			CustomerAccountRepository = new CustomerAccountRepository(dbContext);
			SupplierRepository = new SupplierRepository(dbContext);

			_dbContext = dbContext;
		}
		public Task<int> CompleteAsync()
		{
			return _dbContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}
	}
}
