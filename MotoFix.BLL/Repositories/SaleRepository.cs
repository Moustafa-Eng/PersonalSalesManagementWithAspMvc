using Microsoft.EntityFrameworkCore;
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
	public class SaleRepository : GenericRepository<Sale> , ISaleRepository
	{
        private readonly ApplicationDbContext _dbContext;

        public SaleRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
            _dbContext = dbContext;
        }

        public IQueryable<Sale> GetByDate(DateTime date)
        {
            return _dbContext.Sales.Where(s => s.SaleDate.Date == date.Date).Include(s => s.SaleItems);
        }
    }
}
