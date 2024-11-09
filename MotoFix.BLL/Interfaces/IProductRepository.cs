using MotoFix.BLL.Repositories;
using MotoFix.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoFix.BLL.Interfaces
{
	public interface IProductRepository : IGenericRepository<Product>
	{
        IQueryable<Product> GetProductsByName(string SearchValue);
    }
}
