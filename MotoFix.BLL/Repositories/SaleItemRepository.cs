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
	public class SaleItemRepository : GenericRepository<SaleItem> , ISaleItemRepository
	{
		public SaleItemRepository(ApplicationDbContext dbContext) : base(dbContext)
		{

		}
	}
}
