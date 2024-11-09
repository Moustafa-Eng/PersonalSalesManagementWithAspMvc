using MotoFix.BLL.Interfaces;
using MotoFix.DAL.Context;
using MotoFix.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoFix.BLL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
           _dbContext = dbContext;
        }

        public IQueryable<Product> GetProductsByName(string SearchValue)
        {
           return _dbContext.Products.Where( P => P.Name.ToLower().Contains(SearchValue.ToLower()));
        }
    }
}
