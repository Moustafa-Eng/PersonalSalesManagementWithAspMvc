using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoFix.BLL.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		public IProductRepository ProductRepository { get; set; }
		public ISaleRepository SaleRepository { get; set; }
		public ICategoryRepository CategoryRepository { get; set; }
		public ISaleItemRepository SaleItemRepository { get; set; }
		public ICustomerAccountRepository CustomerAccountRepository { get; set; }
		public ISupplierRepository SupplierRepository { get; set; }


		Task<int> CompleteAsync();

	}
}
